
// This file was automatically generated by the PetaPoco T4 Template
// Do not make changes directly to this file - edit the template instead
// 
// The following connection settings were used to generate this file
// 
//     Connection String Name: `DefaultConnection`
//     Provider:               `System.Data.SqlClient`
//     Connection String:      `Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=PanchayatNew;Integrated Security=True`
//     Schema:                 ``
//     Include Views:          `False`

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace PanchayatWebPortal
{
	public partial class Repository : Database
	{
		public Repository() 
			: base("DefaultConnection")
		{
			CommonConstruct();
		}

		public Repository(string connectionStringName) 
			: base(connectionStringName)
		{
			CommonConstruct();
		}
		
		partial void CommonConstruct();
		
		public interface IFactory
		{
			Repository GetInstance();
		}
		
		public static IFactory Factory { get; set; }
        public static Repository GetInstance()
        {
			if (_instance!=null)
				return _instance;
				
			if (Factory!=null)
				return Factory.GetInstance();
			else
				return new Repository();
        }

		[ThreadStatic] static Repository _instance;
		
		public override void OnBeginTransaction()
		{
			if (_instance==null)
				_instance=this;
		}
		
		public override void OnEndTransaction()
		{
			if (_instance==this)
				_instance=null;
		}
        
	}
	

    
	[TableName("dbo.__MigrationHistory")]
	[PrimaryKey("MigrationId", AutoIncrement=false)]
	[ExplicitColumns]
    public partial class __MigrationHistory  
    {
		[Column] public string MigrationId { get; set; }
		[Column] public string ContextKey { get; set; }
		[Column] public byte[] Model { get; set; }
		[Column] public string ProductVersion { get; set; }
	}
    
	[TableName("dbo.__RefactorLog")]
	[PrimaryKey("OperationKey", AutoIncrement=false)]
	[ExplicitColumns]
    public partial class __RefactorLog  
    {
		[Column] public Guid OperationKey { get; set; }
	}
    
	[TableName("dbo.AspNetRoles")]
	[PrimaryKey("Id", AutoIncrement=false)]
	[ExplicitColumns]
    public partial class AspNetRole  
    {
		[Column] public string Id { get; set; }
		[Column] public string Name { get; set; }
	}
    
	[TableName("dbo.AspNetUserClaims")]
	[PrimaryKey("Id")]
	[ExplicitColumns]
    public partial class AspNetUserClaim  
    {
		[Column] public int Id { get; set; }
		[Column] public string UserId { get; set; }
		[Column] public string ClaimType { get; set; }
		[Column] public string ClaimValue { get; set; }
	}
    
	[TableName("dbo.AspNetUserLogins")]
	[PrimaryKey("LoginProvider", AutoIncrement=false)]
	[ExplicitColumns]
    public partial class AspNetUserLogin  
    {
		[Column] public string LoginProvider { get; set; }
		[Column] public string ProviderKey { get; set; }
		[Column] public string UserId { get; set; }
	}
    
	[TableName("dbo.AspNetUserRoles")]
	[PrimaryKey("UserId", AutoIncrement=false)]
	[ExplicitColumns]
    public partial class AspNetUserRole  
    {
		[Column] public string UserId { get; set; }
		[Column] public string RoleId { get; set; }
	}
    
	[TableName("dbo.AspNetUsers")]
	[PrimaryKey("Id", AutoIncrement=false)]
	[ExplicitColumns]
    public partial class AspNetUser  
    {
		[Column] public string Id { get; set; }
		[Column] public string Email { get; set; }
		[Column] public bool EmailConfirmed { get; set; }
		[Column] public string PasswordHash { get; set; }
		[Column] public string SecurityStamp { get; set; }
		[Column] public string PhoneNumber { get; set; }
		[Column] public bool PhoneNumberConfirmed { get; set; }
		[Column] public bool TwoFactorEnabled { get; set; }
		[Column] public DateTime? LockoutEndDateUtc { get; set; }
		[Column] public bool LockoutEnabled { get; set; }
		[Column] public int AccessFailedCount { get; set; }
		[Column] public string UserName { get; set; }
	}
    
	[TableName("dbo.Audit")]
	[PrimaryKey("AuditID")]
	[ExplicitColumns]
    public partial class Audit  
    {
		[Column] public int AuditID { get; set; }
		[Column] public int? AuditNo { get; set; }
		[Column] public string ListOfAuditObjection { get; set; }
		[Column] public string ActionsTaken { get; set; }
		[Column] public int? Year { get; set; }
	}
    
	[TableName("dbo.BND")]
	[PrimaryKey("BNDID")]
	[ExplicitColumns]
    public partial class BND  
    {
		[Column] public int BNDID { get; set; }
		[Column] public string ChildName { get; set; }
		[Column] public string Gender { get; set; }
		[Column] public DateTime? DateOfBirth { get; set; }
		[Column] public DateTime? TDate { get; set; }
		[Column] public string PlaceOfBirth { get; set; }
		[Column] public string PlaceOfBirthHouse { get; set; }
		[Column] public string NameOfMother { get; set; }
		[Column] public int? UIDmother { get; set; }
		[Column] public string NameOfFather { get; set; }
		[Column] public int? UIDfather { get; set; }
		[Column] public string GrandFather { get; set; }
		[Column] public string GrandMother { get; set; }
		[Column] public string AddressParentsBirth { get; set; }
		[Column] public string PermAddress { get; set; }
		[Column] public string InformantsName { get; set; }
		[Column] public string InformantAddress { get; set; }
		[Column] public string NameOfTown { get; set; }
		[Column] public bool? TownOrVillage { get; set; }
		[Column] public string NameOfDistrict { get; set; }
		[Column] public string NameOfState { get; set; }
		[Column] public string ReligionOfFamily { get; set; }
		[Column] public string AnyOtherReligion { get; set; }
		[Column] public string FEduc { get; set; }
		[Column] public string MEduc { get; set; }
		[Column] public string FOccup { get; set; }
		[Column] public string MOccup { get; set; }
		[Column] public int? AgeOfMotherMarraige { get; set; }
		[Column] public int? AgeOfMotherBirth { get; set; }
		[Column] public int? NoOfChild { get; set; }
		[Column] public string AttentionType { get; set; }
		[Column] public string DeliveryMethod { get; set; }
		[Column] public int? BirthWeight { get; set; }
		[Column] public string DurationOfPregnancy { get; set; }
		[Column] public string UserID { get; set; }
		[Column] public int? WEBstatusID { get; set; }
		[Column] public int? RegisterTypeID { get; set; }
	}
    
	[TableName("dbo.Budget")]
	[PrimaryKey("BudgetID")]
	[ExplicitColumns]
    public partial class Budget  
    {
		[Column] public int BudgetID { get; set; }
		[Column] public int? BudgtFY { get; set; }
		[Column] public int SubLedgerID { get; set; }
		[Column] public decimal BudgetAmount { get; set; }
		[Column] public decimal ActualAmount { get; set; }
		[Column] public decimal OpeningBalance { get; set; }
	}
    
	[TableName("dbo.Building")]
	[PrimaryKey("BuildingID")]
	[ExplicitColumns]
    public partial class Building  
    {
		[Column] public int BuildingID { get; set; }
		[Column] public string WardNo { get; set; }
		[Column("House No")] public string House_No { get; set; }
		[Column] public string OwnerName { get; set; }
		[Column] public string NameOfConstructioin { get; set; }
		[Column] public DateTime? DateOfAppl { get; set; }
		[Column] public string NoOfRes { get; set; }
		[Column] public DateTime? DateOfRes { get; set; }
		[Column] public DateTime? DateOfPermision { get; set; }
		[Column] public decimal? EstimatedCost { get; set; }
		[Column] public decimal? AmountPaid { get; set; }
		[Column] public DateTime? DateOfCompletion { get; set; }
		[Column] public DateTime? DateOfOcccp { get; set; }
		[Column] public DateTime? DateOfAsses { get; set; }
		[Column] public decimal? HouseTax { get; set; }
		[Column] public string Remarks { get; set; }
		[Column] public int? ReceiptNo { get; set; }
	}
    
	[TableName("dbo.CashInHandReg")]
	[PrimaryKey("CashInHandRegID")]
	[ExplicitColumns]
    public partial class CashInHandReg  
    {
		[Column] public int CashInHandRegID { get; set; }
		[Column] public DateTime? Tdate { get; set; }
		[Column] public string NameAndDesg { get; set; }
		[Column] public decimal? CashToDeclareStart { get; set; }
		[Column] public string DetailsOfCashExp { get; set; }
		[Column] public decimal? CashToDeclareEnd { get; set; }
		[Column] public string Remarks { get; set; }
	}
    
	[TableName("dbo.CBRunning")]
	[PrimaryKey("EntryDate", AutoIncrement=false)]
	[ExplicitColumns]
    public partial class CBRunning  
    {
		[Column] public DateTime EntryDate { get; set; }
		[Column] public decimal? TotalInflow { get; set; }
		[Column] public decimal? TotalOutflow { get; set; }
		[Column] public decimal? CBTotal { get; set; }
	}
    
	[TableName("dbo.CertificateRequirements")]
	[PrimaryKey("CertificateRequirementID")]
	[ExplicitColumns]
    public partial class CertificateRequirement  
    {
		[Column] public int CertificateRequirementID { get; set; }
		[Column] public int? RegisterTypeID { get; set; }
		[Column] public string CertificateName { get; set; }
	}
    
	[TableName("dbo.CertSupportDocs")]
	[PrimaryKey("CertSupportDocsID")]
	[ExplicitColumns]
    public partial class CertSupportDoc  
    {
		[Column] public int CertSupportDocsID { get; set; }
		[Column] public int? CertificateRequirementID { get; set; }
		[Column] public int? RegisterTypeID { get; set; }
		[Column] public int? CertificateID { get; set; }
		[Column] public string DocumentName { get; set; }
	}
    
	[TableName("dbo.CharacterCertificate")]
	[PrimaryKey("CharacterID")]
	[ExplicitColumns]
    public partial class CharacterCertificate  
    {
		[Column] public int CharacterID { get; set; }
		[Column] public string PersonName { get; set; }
		[Column] public int? Age { get; set; }
		[Column] public DateTime? Tdate { get; set; }
		[Column] public string FatherName { get; set; }
		[Column] public string MotherName { get; set; }
		[Column] public string Village { get; set; }
		[Column] public string Place { get; set; }
		[Column] public string Address { get; set; }
		[Column] public string WardOf { get; set; }
		[Column] public int? KnownYears { get; set; }
		[Column] public string PurposeOf { get; set; }
		[Column] public string UserID { get; set; }
		[Column] public int? WEBstatusID { get; set; }
		[Column] public int? RegisterTypeID { get; set; }
	}
    
	[TableName("dbo.Citizen")]
	[PrimaryKey("CitizenID")]
	[ExplicitColumns]
    public partial class Citizen  
    {
		[Column] public int CitizenID { get; set; }
		[Column] public string Name { get; set; }
		[Column] public string Mobile { get; set; }
		[Column] public string Email { get; set; }
		[Column] public string ResAddress { get; set; }
	}
    
	[TableName("dbo.Config")]
	[PrimaryKey("ConfigID")]
	[ExplicitColumns]
    public partial class Config  
    {
		[Column] public int ConfigID { get; set; }
		[Column] public string VP { get; set; }
		[Column] public decimal? DemandIncPerc { get; set; }
		[Column] public decimal? ArrearsPerc { get; set; }
		[Column] public int? RowsPerPage { get; set; }
		[Column] public string PanchHead { get; set; }
		[Column] public string PanchSeceretary { get; set; }
	}
    
	[TableName("dbo.ConstLicenseCert")]
	[PrimaryKey("ConstLicenseID")]
	[ExplicitColumns]
    public partial class ConstLicenseCert  
    {
		[Column] public int ConstLicenseID { get; set; }
		[Column] public string OwnersOfHouse { get; set; }
		[Column] public string OwnwersAddress { get; set; }
		[Column] public DateTime? MeetingDated { get; set; }
		[Column("BuildingType ")] public string BuildingType_ { get; set; }
		[Column] public string PropertyZone { get; set; }
		[Column] public string SurveyNo { get; set; }
		[Column] public string SubDivision { get; set; }
		[Column] public string OrderNo { get; set; }
		[Column] public DateTime? Tdate { get; set; }
		[Column] public string RefNo { get; set; }
		[Column] public DateTime? RefDate { get; set; }
		[Column] public DateTime? ValidUpTo { get; set; }
		[Column] public string RecieptNo { get; set; }
		[Column] public DateTime? RecieptDate { get; set; }
		[Column] public string DeveloperName { get; set; }
		[Column] public string DeveloperAddress { get; set; }
		[Column] public decimal? ConstFees { get; set; }
		[Column] public decimal? SanitationFees { get; set; }
		[Column] public int? RegisterTypeID { get; set; }
		[Column] public int? WEBstatusID { get; set; }
		[Column] public string UserID { get; set; }
	}
    
	[TableName("dbo.Corrections")]
	[PrimaryKey("CorrectionID")]
	[ExplicitColumns]
    public partial class Correction  
    {
		[Column] public int CorrectionID { get; set; }
		[Column] public DateTime? CorrectionDate { get; set; }
		[Column] public int? RecieptID { get; set; }
		[Column] public int? VoucherID { get; set; }
		[Column] public decimal? Amount { get; set; }
		[Column] public string Remark { get; set; }
	}
    
	[TableName("dbo.DeathCorrCertificate")]
	[PrimaryKey("DeathCorrCertificateID")]
	[ExplicitColumns]
    public partial class DeathCorrCertificate  
    {
		[Column] public int DeathCorrCertificateID { get; set; }
		[Column] public string FromName { get; set; }
		[Column] public string FromAddress { get; set; }
		[Column] public DateTime? TDate { get; set; }
		[Column] public string BirthOf { get; set; }
		[Column] public DateTime? BornOn { get; set; }
		[Column] public string BirthPlace { get; set; }
		[Column] public string FromWrongName { get; set; }
		[Column] public string InsteadFWN { get; set; }
		[Column] public string NameOfFather { get; set; }
		[Column] public string InsteadNF { get; set; }
		[Column] public string NameOfMother { get; set; }
		[Column] public string InsteadNM { get; set; }
		[Column] public string NameOfGrandMother { get; set; }
		[Column] public string InsteadNGM { get; set; }
		[Column] public string NameOfGrandFather { get; set; }
		[Column] public string InsteadNGF { get; set; }
		[Column] public string BirthDeathName { get; set; }
		[Column] public string UserID { get; set; }
		[Column] public int? RegisterTypeID { get; set; }
		[Column] public int? WEBstatusID { get; set; }
	}
    
	[TableName("dbo.Demand")]
	[PrimaryKey("DemandID")]
	[ExplicitColumns]
    public partial class Demand  
    {
		[Column] public int DemandID { get; set; }
		[Column] public int? CitizenID { get; set; }
		[Column] public string HouseNo { get; set; }
		[Column] public DateTime CreatedOn { get; set; }
		[Column] public DateTime StopDate { get; set; }
		[Column] public string Remarks { get; set; }
	}
    
	[TableName("dbo.DemandDetails")]
	[PrimaryKey("DDID")]
	[ExplicitColumns]
    public partial class DemandDetail  
    {
		[Column] public int DDID { get; set; }
		[Column] public int DemandID { get; set; }
		[Column] public int SubLedgerID { get; set; }
	}
    
	[TableName("dbo.DemandLedgerDetails")]
	[PrimaryKey("DemandLedgerDetailsID")]
	[ExplicitColumns]
    public partial class DemandLedgerDetail  
    {
		[Column] public int DemandLedgerDetailsID { get; set; }
		[Column] public int? DDID { get; set; }
		[Column] public int? LedgerDetailID { get; set; }
		[Column("DemandLedgerDetail")] public string _DemandLedgerDetail { get; set; }
	}
    
	[TableName("dbo.DemandPeriod")]
	[PrimaryKey("DDID", AutoIncrement=false)]
	[ExplicitColumns]
    public partial class DemandPeriod  
    {
		[Column] public int DDID { get; set; }
		[Column] public int PeriodID { get; set; }
		[Column] public decimal? Amount { get; set; }
		[Column] public decimal? SysAmt { get; set; }
	}
    
	[TableName("dbo.DemandYear")]
	[PrimaryKey("DemandYear", AutoIncrement=false)]
	[ExplicitColumns]
    public partial class DemandYear  
    {
		[Column("DemandYear")] public int _DemandYear { get; set; }
		[Column] public int DDID { get; set; }
		[Column] public int PeriodID { get; set; }
		[Column] public decimal? Arrears { get; set; }
		[Column] public int? RecieptNo { get; set; }
		[Column] public decimal? RecptAmt { get; set; }
		[Column] public DateTime? RecptDate { get; set; }
	}
    
	[TableName("dbo.Form1")]
	[PrimaryKey("Form1ID")]
	[ExplicitColumns]
    public partial class Form1  
    {
		[Column] public int Form1ID { get; set; }
		[Column] public int? LedgerID { get; set; }
		[Column] public int? SubLedgerID { get; set; }
		[Column] public DateTime? EntryDate { get; set; }
		[Column] public string Particulars { get; set; }
		[Column] public decimal? Amount { get; set; }
		[Column] public decimal? Progressive { get; set; }
		[Column] public decimal? Total { get; set; }
	}
    
	[TableName("dbo.Form2")]
	[PrimaryKey("Form2ID")]
	[ExplicitColumns]
    public partial class Form2  
    {
		[Column] public int Form2ID { get; set; }
		[Column] public int? Month { get; set; }
		[Column] public int? Year { get; set; }
		[Column] public int? LedgerID { get; set; }
		[Column] public int? SubLedgerID { get; set; }
		[Column] public string ShortParticaulars { get; set; }
		[Column] public decimal? Amount { get; set; }
		[Column] public decimal? Progressive { get; set; }
		[Column] public decimal? Total { get; set; }
	}
    
	[TableName("dbo.Form3")]
	[PrimaryKey("CashBookID")]
	[ExplicitColumns]
    public partial class Form3  
    {
		[Column] public int CashBookID { get; set; }
		[Column] public DateTime? PayDate { get; set; }
		[Column] public decimal? Amount { get; set; }
		[Column] public int? LedgerID { get; set; }
		[Column] public int? SubLedgerID { get; set; }
		[Column] public int? TransNo { get; set; }
		[Column] public string TransPerson { get; set; }
	}
    
	[TableName("dbo.Form4")]
	[PrimaryKey("RecieptNo")]
	[ExplicitColumns]
    public partial class Form4  
    {
		[Column] public int RecieptNo { get; set; }
		[Column] public int? CitizenID { get; set; }
		[Column] public decimal? Amount { get; set; }
		[Column] public DateTime? PayDate { get; set; }
		[Column] public int? LedgerID { get; set; }
		[Column] public int? SubLedgerID { get; set; }
		[Column] public string RecvdFrom { get; set; }
		[Column] public string HouseNo { get; set; }
	}
    
	[TableName("dbo.HouseTaxCert")]
	[PrimaryKey("HouseTaxCertID")]
	[ExplicitColumns]
    public partial class HouseTaxCert  
    {
		[Column] public int HouseTaxCertID { get; set; }
		[Column] public string PersonName { get; set; }
		[Column] public string WardNo { get; set; }
		[Column] public string PersonAddress { get; set; }
		[Column] public DateTime? Tdate { get; set; }
		[Column] public DateTime? MeetingDate { get; set; }
		[Column] public string PrevPersonName { get; set; }
		[Column] public int? Fees { get; set; }
		[Column] public string DeveloperName { get; set; }
		[Column] public string DeveloperAddress { get; set; }
		[Column] public string UserID { get; set; }
		[Column] public int? RegisterTypeID { get; set; }
		[Column] public int? WEBstatusID { get; set; }
	}
    
	[TableName("dbo.IllegalConstruction")]
	[PrimaryKey("IllegalConID")]
	[ExplicitColumns]
    public partial class IllegalConstruction  
    {
		[Column] public int IllegalConID { get; set; }
		[Column] public DateTime? DateOfComp { get; set; }
		[Column] public string NameOfPr { get; set; }
		[Column] public string AddressOfPr { get; set; }
		[Column] public string NatOfCon { get; set; }
		[Column] public string OccasOfCons { get; set; }
		[Column] public string ActionTaken { get; set; }
		[Column] public string Remarks { get; set; }
		[Column] public int? WEBstatusID { get; set; }
		[Column] public string UserID { get; set; }
		[Column] public int RegisterTypeID { get; set; }
	}
    
	[TableName("dbo.IncomeCertificate")]
	[PrimaryKey("IncomeCertificateID")]
	[ExplicitColumns]
    public partial class IncomeCertificate  
    {
		[Column] public int IncomeCertificateID { get; set; }
		[Column] public string PersonName { get; set; }
		[Column] public string RelationName { get; set; }
		[Column] public string Address { get; set; }
		[Column] public decimal? IncomeAmt { get; set; }
		[Column] public string YearOf { get; set; }
		[Column] public string OfficeName { get; set; }
		[Column] public string PurposeOf { get; set; }
		[Column] public string Inquiry { get; set; }
		[Column] public string ReportNo { get; set; }
		[Column] public DateTime? InquiryDate { get; set; }
		[Column] public string Place { get; set; }
		[Column] public DateTime? PrintDate { get; set; }
		[Column] public string UserID { get; set; }
		[Column] public int? RegisterTypeID { get; set; }
		[Column] public int? WEBstatusID { get; set; }
	}
    
	[TableName("dbo.InOutRegsIssue")]
	[PrimaryKey("IOissueID")]
	[ExplicitColumns]
    public partial class InOutRegsIssue  
    {
		[Column] public int IOissueID { get; set; }
		[Column] public int? IORecptID { get; set; }
		[Column] public int? RegisterTypeID { get; set; }
		[Column] public DateTime? TDate { get; set; }
		[Column] public int? ItemID { get; set; }
		[Column] public int? Qty { get; set; }
		[Column] public decimal? Value { get; set; }
		[Column] public string IssuedTo { get; set; }
		[Column] public decimal? Balance { get; set; }
		[Column] public string Remarks { get; set; }
		[Column] public int? RVno { get; set; }
		[Column] public string RefundReason { get; set; }
	}
    
	[TableName("dbo.InOutRegsRecpt")]
	[PrimaryKey("IORecptID")]
	[ExplicitColumns]
    public partial class InOutRegsRecpt  
    {
		[Column] public int IORecptID { get; set; }
		[Column] public int? RegisterTypeID { get; set; }
		[Column] public DateTime? TDate { get; set; }
		[Column] public int? ItemID { get; set; }
		[Column] public int? Qty { get; set; }
		[Column] public decimal? Value { get; set; }
		[Column] public int? RVno { get; set; }
		[Column] public string PropertyParticulars { get; set; }
		[Column] public string SituatedWhere { get; set; }
		[Column] public string DepositPurpose { get; set; }
		[Column] public string ValuationDetails { get; set; }
		[Column] public string SanctionDateNo { get; set; }
		[Column] public string SanctionByWhom { get; set; }
		[Column] public byte? PeriodToSpendYrs { get; set; }
		[Column] public string TreasureVoucherDetails { get; set; }
	}
    
	[TableName("dbo.Inventory")]
	[PrimaryKey("ItemID", AutoIncrement=false)]
	[ExplicitColumns]
    public partial class Inventory  
    {
		[Column] public int ItemID { get; set; }
		[Column] public decimal Qty { get; set; }
	}
    
	[TableName("dbo.InvItems")]
	[PrimaryKey("ItemID")]
	[ExplicitColumns]
    public partial class InvItem  
    {
		[Column] public int ItemID { get; set; }
		[Column] public string Item { get; set; }
		[Column] public int RegisterTypeID { get; set; }
	}
    
	[TableName("dbo.Inward")]
	[PrimaryKey("InwardID")]
	[ExplicitColumns]
    public partial class Inward  
    {
		[Column] public int InwardID { get; set; }
		[Column] public DateTime? DateOfReciept { get; set; }
		[Column] public string FromWhereRec { get; set; }
		[Column] public string NoOfLett { get; set; }
		[Column] public DateTime? DateOfLett { get; set; }
		[Column] public string FileNo { get; set; }
		[Column] public string SubjectMatter { get; set; }
		[Column] public DateTime? ActionTaken { get; set; }
		[Column] public string Remark { get; set; }
		[Column] public int RegisterTypeID { get; set; }
	}
    
	[TableName("dbo.LedgerDetails")]
	[PrimaryKey("LedgerDetailID")]
	[ExplicitColumns]
    public partial class LedgerDetail  
    {
		[Column] public int LedgerDetailID { get; set; }
		[Column] public int? SubLedgerID { get; set; }
		[Column("LedgerDetail")] public string _LedgerDetail { get; set; }
	}
    
	[TableName("dbo.Ledgers")]
	[PrimaryKey("LedgerID")]
	[ExplicitColumns]
    public partial class Ledger  
    {
		[Column] public int LedgerID { get; set; }
		[Column("Ledger")] public string _Ledger { get; set; }
		[Column] public bool IsIncome { get; set; }
	}
    
	[TableName("dbo.Meeting")]
	[PrimaryKey("MeetingID")]
	[ExplicitColumns]
    public partial class Meeting  
    {
		[Column] public int MeetingID { get; set; }
		[Column] public string Subject { get; set; }
		[Column] public string ProposerName { get; set; }
		[Column] public bool? PropOrAmend { get; set; }
		[Column] public int? For { get; set; }
		[Column] public int? Against { get; set; }
		[Column] public DateTime? MeetingDate { get; set; }
		[Column] public string Resolution { get; set; }
		[Column] public string Remark { get; set; }
		[Column] public int RegisterTypeID { get; set; }
	}
    
	[TableName("dbo.MovementReg")]
	[PrimaryKey("MovementRegID")]
	[ExplicitColumns]
    public partial class MovementReg  
    {
		[Column] public int MovementRegID { get; set; }
		[Column] public string NameAndDes { get; set; }
		[Column] public DateTime? TimeOfDeparture { get; set; }
		[Column] public DateTime? TimeOfReturn { get; set; }
		[Column] public string PlaceAndPurpose { get; set; }
	}
    
	[TableName("dbo.Noc")]
	[PrimaryKey("NocID")]
	[ExplicitColumns]
    public partial class Noc  
    {
		[Column] public int NocID { get; set; }
		[Column] public DateTime? DateOfReciept { get; set; }
		[Column] public string NameAndAdressAppl { get; set; }
		[Column] public string NatOfNoc { get; set; }
		[Column] public DateTime? DateOfVp { get; set; }
		[Column] public int? NoOfResolution { get; set; }
		[Column] public bool? IssueOrReject { get; set; }
		[Column] public string RejectedReason { get; set; }
		[Column] public DateTime? DateOfComm { get; set; }
		[Column] public string Remarks { get; set; }
		[Column] public int? RegisterTypeID { get; set; }
	}
    
	[TableName("dbo.NocCertifictes")]
	[PrimaryKey("NocID")]
	[ExplicitColumns]
    public partial class NocCertificte  
    {
		[Column] public int NocID { get; set; }
		[Column] public string Hno { get; set; }
		[Column] public string No { get; set; }
		[Column] public DateTime? AprovedDate { get; set; }
		[Column] public DateTime? PrintDate { get; set; }
		[Column] public string Address { get; set; }
		[Column] public string PersonName { get; set; }
		[Column] public string ElectDeptAdd { get; set; }
		[Column] public string UserID { get; set; }
		[Column] public int? WEBstatusID { get; set; }
		[Column] public int? RegisterTypeID { get; set; }
	}
    
	[TableName("dbo.OccupationCertDetails")]
	[PrimaryKey("OccupationCertDetailsID")]
	[ExplicitColumns]
    public partial class OccupationCertDetail  
    {
		[Column] public int OccupationCertDetailsID { get; set; }
		[Column] public int? OccupationCertificateID { get; set; }
		[Column] public string NameOfTheOwner { get; set; }
		[Column] public string FlatNo { get; set; }
		[Column] public string HouseNo { get; set; }
		[Column] public decimal? HouseTax { get; set; }
		[Column] public decimal? GarbageTax { get; set; }
	}
    
	[TableName("dbo.OccupationCertificate")]
	[PrimaryKey("OccupationCertificateID")]
	[ExplicitColumns]
    public partial class OccupationCertificate  
    {
		[Column] public int OccupationCertificateID { get; set; }
		[Column] public string PersonName { get; set; }
		[Column] public string PersonAddress { get; set; }
		[Column] public DateTime? MeetingDated { get; set; }
		[Column] public string ConstLicNo { get; set; }
		[Column] public string BuildingDetails { get; set; }
		[Column] public DateTime? ConstLicDate { get; set; }
		[Column] public DateTime? Tdate { get; set; }
		[Column] public string SurveyNo { get; set; }
		[Column] public string PlotNumber { get; set; }
		[Column] public string RefNo { get; set; }
		[Column] public DateTime? RefDate { get; set; }
		[Column] public string HSref { get; set; }
		[Column] public DateTime? HSrefdate { get; set; }
		[Column] public int? RegisterTypeID { get; set; }
		[Column] public int? WEBstatusID { get; set; }
		[Column] public string UserID { get; set; }
	}
    
	[TableName("dbo.Outward")]
	[PrimaryKey("OutwardID")]
	[ExplicitColumns]
    public partial class Outward  
    {
		[Column] public int OutwardID { get; set; }
		[Column] public DateTime? DateOfDisp { get; set; }
		[Column] public string ToWhom { get; set; }
		[Column] public string FileReferenceNo { get; set; }
		[Column] public DateTime? FileReferenceDate { get; set; }
		[Column] public string SubjectMatter { get; set; }
		[Column] public decimal? PostageDrawn { get; set; }
		[Column] public decimal? PostageExtended { get; set; }
		[Column] public string Remark { get; set; }
		[Column] public int RegisterTypeID { get; set; }
	}
    
	[TableName("dbo.Period")]
	[PrimaryKey("PeriodID")]
	[ExplicitColumns]
    public partial class Period  
    {
		[Column] public int PeriodID { get; set; }
		[Column] public int FromYr { get; set; }
		[Column] public int ToYr { get; set; }
	}
    
	[TableName("dbo.PovertyCertificate")]
	[PrimaryKey("PovertyCertificateID")]
	[ExplicitColumns]
    public partial class PovertyCertificate  
    {
		[Column] public int PovertyCertificateID { get; set; }
		[Column] public int? RegisterTypeID { get; set; }
		[Column] public string PersonName { get; set; }
		[Column] public string OtherName { get; set; }
		[Column] public string PersonAddress { get; set; }
		[Column] public string RequestedBy { get; set; }
		[Column] public string AddOfPerReqBy { get; set; }
		[Column] public string UserID { get; set; }
		[Column] public int? WEBstatusID { get; set; }
	}
    
	[TableName("dbo.Property")]
	[PrimaryKey("PropertyID")]
	[ExplicitColumns]
    public partial class Property  
    {
		[Column] public int PropertyID { get; set; }
		[Column] public string PropertyName { get; set; }
		[Column] public string Remarks { get; set; }
	}
    
	[TableName("dbo.PropertyBooking")]
	[PrimaryKey("PropertyBookingID")]
	[ExplicitColumns]
    public partial class PropertyBooking  
    {
		[Column] public int PropertyBookingID { get; set; }
		[Column] public int PropertyID { get; set; }
		[Column("Inward No")] public string Inward_No { get; set; }
		[Column] public DateTime? TDate { get; set; }
		[Column] public string NameOfApplicant { get; set; }
		[Column] public string PhoneNo { get; set; }
		[Column] public DateTime? HDate { get; set; }
		[Column] public int? AdvReceiptNo { get; set; }
		[Column] public decimal? AdvAmount { get; set; }
		[Column] public int? SecurityDepositAmt { get; set; }
		[Column] public string ApplForSDRefund { get; set; }
		[Column] public int? FullPayReceiptNo { get; set; }
		[Column] public decimal? FullPayAmount { get; set; }
		[Column] public int? LuxTaxReceiptNo { get; set; }
		[Column] public int? RefundSDVoucherNo { get; set; }
		[Column] public decimal? PaymentOfLuxTax { get; set; }
		[Column] public string Remarks { get; set; }
	}
    
	[TableName("dbo.RegisterTypes")]
	[PrimaryKey("RegisterTypeID")]
	[ExplicitColumns]
    public partial class RegisterType  
    {
		[Column] public int RegisterTypeID { get; set; }
		[Column("RegisterType")] public string _RegisterType { get; set; }
	}
    
	[TableName("dbo.ResidenceCertificate")]
	[PrimaryKey("ResidenceCertificateID")]
	[ExplicitColumns]
    public partial class ResidenceCertificate  
    {
		[Column] public int ResidenceCertificateID { get; set; }
		[Column] public string PersonName { get; set; }
		[Column] public DateTime? BirthDate { get; set; }
		[Column] public string BirthPlace { get; set; }
		[Column] public string NameOfMother { get; set; }
		[Column] public string NameOfFather { get; set; }
		[Column] public string Address { get; set; }
		[Column] public DateTime? TDate { get; set; }
		[Column] public int? Since { get; set; }
		[Column] public bool? IsDead { get; set; }
		[Column] public string UserID { get; set; }
		[Column] public int? RegisterTypeID { get; set; }
		[Column] public int? WebStatusID { get; set; }
	}
    
	[TableName("dbo.RVdetails")]
	[PrimaryKey("RVdetailID")]
	[ExplicitColumns]
    public partial class RVdetail  
    {
		[Column] public int RVdetailID { get; set; }
		[Column] public int? ReceiptNo { get; set; }
		[Column] public int? VoucherID { get; set; }
		[Column] public int LedgerDetailID { get; set; }
		[Column] public string RVDetail { get; set; }
	}
    
	[TableName("dbo.SubLedgers")]
	[PrimaryKey("SubLedgerID")]
	[ExplicitColumns]
    public partial class SubLedger  
    {
		[Column] public int SubLedgerID { get; set; }
		[Column] public int? LedgerID { get; set; }
		[Column] public int? SubLedgerTypeID { get; set; }
		[Column] public string Ledger { get; set; }
		[Column] public bool HasDemand { get; set; }
	}
    
	[TableName("dbo.SubLedgerType")]
	[PrimaryKey("SubLedgerTypeID")]
	[ExplicitColumns]
    public partial class SubLedgerType  
    {
		[Column] public int SubLedgerTypeID { get; set; }
		[Column("SubLedgerType")] public string _SubLedgerType { get; set; }
	}
    
	[TableName("dbo.Voucher")]
	[PrimaryKey("VoucherID")]
	[ExplicitColumns]
    public partial class Voucher  
    {
		[Column] public int VoucherID { get; set; }
		[Column] public string PassedBy { get; set; }
		[Column] public string of { get; set; }
		[Column] public decimal? Amount { get; set; }
		[Column] public decimal? ActualAmount { get; set; }
		[Column] public string For { get; set; }
		[Column] public DateTime? PayDate { get; set; }
		[Column] public int? CBfolio { get; set; }
		[Column] public string ResNo { get; set; }
		[Column] public DateTime? HeldOn { get; set; }
		[Column] public string Meeting { get; set; }
		[Column] public int? LedgerID { get; set; }
		[Column] public int? SubLedgerID { get; set; }
	}
    
	[TableName("dbo.VPRent")]
	[PrimaryKey("VPRentID")]
	[ExplicitColumns]
    public partial class VPRent  
    {
		[Column] public int VPRentID { get; set; }
		[Column] public int RentYear { get; set; }
		[Column] public string RentPayerName { get; set; }
		[Column] public string RentedPropertyName { get; set; }
	}
    
	[TableName("dbo.VPRentDetails")]
	[PrimaryKey("VPRentID", AutoIncrement=false)]
	[ExplicitColumns]
    public partial class VPRentDetail  
    {
		[Column] public int VPRentID { get; set; }
		[Column] public int Month { get; set; }
		[Column] public decimal Arrears { get; set; }
		[Column] public decimal Current { get; set; }
		[Column] public decimal RecoveryAmt { get; set; }
		[Column] public DateTime RecoveryDate { get; set; }
		[Column] public decimal BalanceArrears { get; set; }
		[Column] public decimal BalanceCurrent { get; set; }
		[Column] public int ReceiptNo { get; set; }
	}
    
	[TableName("dbo.WEBstatus")]
	[PrimaryKey("WebStatusID")]
	[ExplicitColumns]
    public partial class WEBstatus  
    {
		[Column] public int WebStatusID { get; set; }
		[Column] public string Status { get; set; }
	}
    
	[TableName("dbo.Works")]
	[PrimaryKey("WorksID")]
	[ExplicitColumns]
    public partial class Work  
    {
		[Column] public int WorksID { get; set; }
		[Column] public string NameOfWork { get; set; }
		[Column] public string TechSanctionNo { get; set; }
		[Column] public string ContractorName { get; set; }
		[Column] public string PercentageAccepted { get; set; }
		[Column] public int? EMDIOrecptID { get; set; }
		[Column] public int? SDIOrecptID { get; set; }
		[Column] public int? ITrecptNo { get; set; }
		[Column] public int? RoyaltyDeposit { get; set; }
		[Column] public string TimeLimit { get; set; }
		[Column] public string ExtentionTime { get; set; }
		[Column] public decimal? EstimatedCost { get; set; }
		[Column] public decimal? TenderedCost { get; set; }
		[Column] public decimal? FinalValue { get; set; }
		[Column] public decimal? NetPaymentToContractor { get; set; }
		[Column] public DateTime? CommenceDate { get; set; }
		[Column] public DateTime? CompletionDate { get; set; }
		[Column] public decimal? GrantsRecieved { get; set; }
		[Column] public decimal? GrantsUtilized { get; set; }
		[Column] public string MBNo { get; set; }
	}
}
