
CREATE PROCEDURE [dbo].[NightlyRun]
	@date DATE
AS
Begin
	
	-- This sp that runs each night accomplishes the following:
	--	1. Bulk initializes DemandPeriod when the old period is over. Also set Budget OB
	--	2. At end of financial year, calculates arreas in DemandYear for demands that have not been stopped
	--	3. Each night:
		--	a. Updates DemandYear with the ReceiptNo's of the day
		--	b. Updates Form8 with receipt amounts recvd in the day
		--	c. Updates Form3, Form1, Form2 and Form10 with new summary values from receipts and vouchers
		--	d. Updates Form3, Form1, Form2 and Form10 with new summary values from corrections
		--	e. Calc Cash Book Running Totals
	
select 'start'
	--IMPLEMENTATION
	DECLARE @CurrPeriod INT, @CurrYr INT
	SELECT @CurrYr =  CASE WHEN  MONTH(@date) < 4 THEN YEAR(@date)-1 ELSE YEAR(@date) END
	SELECT @CurrPeriod = PeriodID FROM Period WHERE FromYr <= @CurrYr AND ToYr >= @CurrYr

	--	1. Set Budget OB and Bulk initializes DemandPeriod when the old period is over	 
	 if (Datepart(m,@date) = 3 and Datepart(d,@date)=31)--last day of year
	 begin
select 'DP'
		DECLARE @CurrPeriodToYr INT, @DemdIncPerc DECIMAL(18,2)
		SELECT @CurrPeriodToYr = ToYr FROM Period WHERE PeriodID=@CurrPeriod
		SELECT @DemdIncPerc = DemandIncPerc FROM Config WHERE ConfigID=1

		--Set Budget OB
		UPDATE Budget SET OpeningBalance = 0 WHERE BudgtFY = @CurrYr
		
		IF NOT EXISTS(Select * FROM Budget WHERE BudgtFY=@CurrYr+1)
		Begin
			INSERT INTO Budget(BudgtFY, OpeningBalance, SubLedgerID)
			SELECT @CurrYr+1, (OpeningBalance+BudgetAmount)-ActualAmount, SubLedgerID
			FROM Budget 
			WHERE BudgtFY = @CurrYr
		End	

		IF @CurrPeriodToYr=@CurrYr--and last day of period too
		Begin
select 'period end'
			DECLARE @NextPeriod INT
			SELECT @NextPeriod = PeriodID FROM Period WHERE FromYr <= (@CurrYr+1) AND ToYr >= (@CurrYr+1)
			
			INSERT INTO DemandPeriod(PeriodID,DDID, SysAmt)--initialize the SysAmt for the new year and new period
			SELECT @NextPeriod, DDID, COALESCE(Amount,  SysAmt) AS SysAmt FROM DemandPeriod
			WHERE PeriodID=@CurrPeriod

			--	2. At end of financial year, initialise DemandYear for demands that have not been stopped
			INSERT INTO DemandYear(DemandYear, DDID,Arrears, PeriodID)	
			SELECT @CurrYr+1, y.DDID,  (y.Arrears+COALESCE(Amount, SysAmt)-COALESCE(y.RecptAmt,0))*(@DemdIncPerc/100)  ,@NextPeriod--next period
				FROM DemandYear y, DemandPeriod dp, DemandDetails dd, Demand d
				WHERE y.PeriodID=dp.PeriodID
					AND y.DDID=dp.DDID
					AND dp.DDID=dd.DDID
					AND dd.DemandID=d.DemandID
					AND DemandYear=@CurrYr 
					AND d.StopDate>@date

		End ELSE--not last day of period but it is last day of year
		Begin
select 'mid period'
			--	2. At end of financial year, initialise DemandYear for demands that have not been stopped
			INSERT INTO DemandYear(DemandYear, DDID, Arrears,PeriodID)	
			SELECT @CurrYr+1, y.DDID, (y.Arrears+COALESCE(Amount, SysAmt)-COALESCE(y.RecptAmt,0))*(@DemdIncPerc/100)  ,@CurrPeriod --current period
				FROM DemandYear y, DemandPeriod dp, DemandDetails dd, Demand d
				WHERE y.PeriodID=dp.PeriodID
					AND y.DDID=dp.DDID
					AND dp.DDID=dd.DDID
					AND dd.DemandID=d.DemandID
					AND DemandYear=@CurrYr 
					AND d.StopDate>@date
		End
	 end 

	 
select 'after year inits: ' , @CurrYr


	 --	3. Each night:
		--	a. Updates DemandYear with the ReceiptNo's of the day		 
		UPDATE y SET y.RecieptNo = f.RecieptNo, y.RecptAmt=f.Amount , y.RecptDate=f.PayDate
			FROM DemandYear y, Form4 f, DemandPeriod dp, DemandDetails dd, Demand d
			WHERE y.PeriodID=dp.PeriodID
					AND y.DDID=dp.DDID
					AND dp.DDID=dd.DDID
					AND dd.DemandID=d.DemandID
					AND f.HouseNo=d.HouseNo
					AND y.DemandYear = @CurrYr
					AND d.CitizenID=f.CitizenID
					AND f.PayDate=@date
					AND f.SubLedgerID=dd.SubLedgerID


		--	c. Updates Form3, Form1, Form2 and Form10 with new summary values from receipts and vouchers
	
	DELETE FROM Form3 Where(PayDate = @date)--we clean before insert here but not for demands because if incorrectly run for a past date it would destroy user data
    
	--Form3: Receipts
	INSERT INTO Form3(PayDate,Amount,LedgerID,SubLedgerID, TransNo, TransPerson)
	SELECT PayDate,Amount,LedgerID,SubLedgerID, RecieptNo, COALESCE(RecvdFrom,c.Name)
	from Form4 r left join Citizen c on r.CitizenID=c.CitizenID
	where PayDate = @date

	-- Form 3: Vouchers
    INSERT INTO Form3(PayDate,Amount,LedgerID,SubLedgerID, TransNo, TransPerson)
	SELECT PayDate,Amount,LedgerID,SubLedgerID, VoucherID, PassedBy
	from Voucher
	where PayDate = @date

	--	d. Updates Form3 with new summary values from corrections: RECEIPTS
	INSERT INTO Form3(PayDate,Amount,LedgerID,SubLedgerID, TransNo, TransPerson)
	SELECT CorrectionDate, c.Amount,f.LedgerID,f.SubLedgerID, f.RecieptNo, COALESCE(f.RecvdFrom, z.Name)
	FROM Corrections c INNER JOIN Form4 f ON c.RecieptID=f.RecieptNo left Join Citizen z ON f.CitizenID=z.CitizenID
	WHERE c.CorrectionDate = @date and f.PayDate=@date

	--	d. Updates Form3 with new summary values from corrections: VOUCHERS	
	INSERT INTO Form3(PayDate,Amount,LedgerID,SubLedgerID, TransNo, TransPerson)
	SELECT CorrectionDate, c.Amount,f.LedgerID,f.SubLedgerID, f.VoucherID, f.PassedBy
	FROM Corrections c INNER JOIN Voucher f ON c.VoucherID=f.VoucherID
	WHERE c.CorrectionDate = @date and f.PayDate=@date

	-- Form 1
	DELETE FROM Form1 Where(EntryDate= @date)
	INSERT INTO Form1(LedgerID,SubLedgerID,EntryDate,Amount)
	SELECT LedgerID,SubLedgerID,PayDate,COALESCE(sum(Amount),0)
	From Form3
	Where PayDate = @date
	Group By LedgerID,SubLedgerID,PayDate

	UPDATE Form1 SET Particulars = (SELECT CONCAT('ID: ', MIN(TransNo) , ' to ' , MAX(TransNo), ' with ', COUNT(TransNo) , ' entries') FROM Form3 t WHERE Form1.LedgerID=t.LedgerID AND Form1.SubLedgerID=t.SubLedgerID AND  t.PayDate = @date GROUP BY t.LedgerID, t.SubLedgerID)
	WHERE EntryDate=@date

	--Form 2: We only calc for prev month (if not already calculated)
	DECLARE @LastOfPrevMonth Date
	SET @LastOfPrevMonth=DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,CONVERT(date, CONCAT(YEAR(@date) , '/' , Month(@date) ,'/01'),111)),0))
select 'Prevmon',@LastOfPrevMonth
	IF NOT EXISTS(SELECT * FROM Form2 WHERE [Month] = Month(@LastOfPrevMonth) and [Year]=YEAR(@LastOfPrevMonth))
	Begin
		INSERT INTO Form2(Month,Year,LedgerID,SubLedgerID,Amount)
		Select Month(@LastOfPrevMonth),Year(@LastOfPrevMonth),LedgerID, SubLedgerID,Sum(Amount)
		From Form1
		Where MONTH(EntryDate) = Month(@LastOfPrevMonth) and YEAR(EntryDate) = Year(@LastOfPrevMonth)
		Group by LedgerID, SubLedgerID,Year(EntryDate), Month(EntryDate)

		UPDATE Form2 SET ShortParticaulars = (SELECT CONCAT('ID: ', MIN(TransNo) , ' to ' , MAX(TransNo), ' with ', COUNT(TransNo) , ' entries') FROM Form3 t WHERE Form2.LedgerID=t.LedgerID AND Form2.SubLedgerID=t.SubLedgerID AND  MONTH(t.PayDate) =Month(@LastOfPrevMonth) GROUP BY t.LedgerID, t.SubLedgerID)
		WHERE [Month] = Month(@LastOfPrevMonth) and [Year] = Year(@LastOfPrevMonth)

	End		
	
	
	--	e. Calc Cash Book Running Totals	 
	DELETE from CBRunning WHERE EntryDate=@date
	INSERT INTO CBRunning(EntryDate)
	Values( @date)
		
	UPDATE CBRunning SET TotalInflow = (SELECT SUM(Amount) FROM Form4 WHERE PayDate=@date) 	--todays Receipts
	WHERE EntryDate=@date
		
	UPDATE CBRunning SET TotalOutflow = (SELECT SUM(Amount) FROM Voucher WHERE PayDate=@date) --todays Vouchers
	WHERE EntryDate=@date
		
	UPDATE CBRunning SET TotalInflow = COALESCE(TotalInflow,0) + (SELECT COALESCE(SUM(Amount),0) FROM Corrections WHERE CorrectionDate=@date AND RecieptID IS NOT Null) --Todays receipt corrections
	WHERE EntryDate=@date
	
	UPDATE CBRunning SET TotalOutflow = COALESCE(TotalOutflow,0) +(SELECT COALESCE(SUM(Amount),0) FROM Corrections WHERE CorrectionDate=@date AND VoucherID IS NOT Null) --Todays Voucher corrections
	WHERE EntryDate=@date

	DECLARE @YesterdaysTotal Decimal(18,2)
	SELECT @YesterdaysTotal=COALESCE(CBTotal,0) FROM CBRunning WHERE EntryDate = DATEADD(d,-1,@date)
	UPDATE CBRunning SET CBTotal = COALESCE(TotalInflow,0)-COALESCE(TotalOutflow,0)+COALESCE(@YesterdaysTotal,0) --Sum it all up and merge with yesterdays total
	WHERE EntryDate=@date
 END
