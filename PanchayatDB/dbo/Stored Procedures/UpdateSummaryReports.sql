CREATE PROCEDURE [dbo].[UpdateSummaryReports]
	@date DATE
	
	
AS
BEGIN

	DELETE FROM Form3 Where(PayDate = @date)
    INSERT INTO Form3(PayDate,Amount,LedgerID,SubLedgerID)
	SELECT PayDate,Amount,LedgerID,SubLedgerID
	from Form4
	where PayDate = @date

    INSERT INTO Form3(PayDate,Amount,LedgerID,SubLedgerID)
	SELECT PayDate,Amount,LedgerID,SubLedgerID
	from Voucher
	where PayDate = @date

	INSERT INTO Form1(LedgerID,SubLedgerID,EntryDate,Amount,Progressive,Total)
	SELECT LedgerID,SubLedgerID,PayDate,sum(Amount),null,null
	From Form3
	Where PayDate = @date
	Group By LedgerID,SubLedgerID,PayDate
	


	IF NOT EXISTS(Select Month from Form2 Where Month = DATEPART(mm,@date))
		Begin
			INSERT INTO Form2(Month,Year,LedgerID,SubLedgerID,Amount,Progressive,Total)
			Select DATEPART(MM,EntryDate),DATEPART(YYYY,EntryDate),LedgerID, SubLedgerID,Sum(Amount),null,null
			From Form1
			Where EntryDate = @date
			Group by LedgerID, SubLedgerID,DATEPART(MM,EntryDate),DATEPART(YYYY,EntryDate)
		End
	Else
		Begin
		Declare @Monthf1 int
		
		Update Form2
	    	SET  
	           LedgerID = Form1.LedgerID,
			   SubLedgerID = Form1.SubLedgerID,
			   Amount = Form2.Amount + Form1.Amount
			   From 
			   Form1
			   Where EntryDate = @date

		End
	

END
RETURN 0