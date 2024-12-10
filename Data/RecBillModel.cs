using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace jtpjsapp.Data ;

//[Table("RecBillModels")]
[Index(nameof(TicketNumber), nameof(SubTicketNumber), IsUnique = true)]
public class RecBillModel
{

  public RecBillModel() {}

  public RecBillModel(DateTime dt, DateTime td, DateTime dd , DateTime addtime , DateTime modifytime) {
        this.RecDate = dt;
        this.TicketIssueDate = td;
        this.DueDate = dd;
	this.AddTime = addtime;
	this.ModifyTime = modifytime;
   }

   public int Id { get; set; }

   [Required]
   [Comment("收票日期")]
   public DateTime RecDate { get; set; }

    [Required]
    [StringLength(16,
        ErrorMessage = "Identifier too long (16 character limit).")]
    public string RecVoucher { get; set; }

    [Required]
    [MaxLength(100)]
    public string EntryName { get; set; }

    [Required]
        [StringLength(50,
        ErrorMessage = "Identifier too long (50 character limit).")]
    public string RecBillCategory { get; set; }

    [Required]
        [StringLength(50,
        ErrorMessage = "Identifier too long (50 character limit).")]
    public string FrontRela { get; set; }

    [Required]
        [StringLength(10,
        ErrorMessage = "Identifier too long (10 character limit).")]
    public string NewGeneration { get; set; }

    [Required]
        [StringLength(50,
        ErrorMessage = "Identifier too long (50 character limit).")]
    public string TicketNumber { get; set; }

    [Required]
        [StringLength(50,
        ErrorMessage = "Identifier too long (50 character limit).")]
    public string SubTicketNumber { get; set; }

    [Required]
        [StringLength(50,
        ErrorMessage = "Identifier too long (50 character limit).")]
    public string IssuingUnit { get; set; }

    [Required]
        [StringLength(50,
        ErrorMessage = "Identifier too long (50 character limit).")]
    public string AcceptorName { get; set; }

    [Required]
        [StringLength(10,
        ErrorMessage = "Identifier too long (10 character limit).")]
    public string Is69 { get; set; }

    [Required]
   // [Column(TypeName = "decimal(10, 2)")]
    [Precision(14, 2)]
   // [Range(0.00001, 999999999999, ErrorMessage = "承兑金额要大于0。")]
    public decimal AcceptAmount { get; set; }

    [Required]
    public DateTime TicketIssueDate { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    public bool Selected { get; set; }
   
    // user ID from AspNetUser table.
    public string OwnerID { get; set; }

    [Required]
    public RecbillStatus Status { get; set; }

    [Required]    
    public RecbillCompany Company { get; set; }
    
    public string? Endorser { get; set; } 

    [Required]   
    [Precision(14, 2)]    
    public decimal Balance { get; set; }
    
    [Precision(14, 2)]
    public decimal? TransferAmount { get; set; }

    [Required]
    public DateTime AddTime { get; set; }

    public DateTime? ModifyTime { get; set; }

    
    [StringLength(10,
    ErrorMessage = "Identifier too long (10 character limit).")]    
    public string IsMotherTicket { get; set; }

    /*
    [Range(1, 100000,
        ErrorMessage = "Accommodation invalid (1-100000).")]
    public int MaximumAccommodation { get; set; }


    [Required]
    [Range(typeof(bool), "true", "true",
        ErrorMessage = "This form disallows unapproved ships.")]
    public bool IsValidatedDesign { get; set; }

    [Required]
    public DateTime ProductionDate { get; set; }
    */
}

public enum RecbillStatus
{
    Submitted,
    Approved,
    Rejected
}

public enum RecbillCompany
{
   江特电机,
   江西江特,
   银锂新能源,
   杭州米格,
   天津华兴,
   宜丰锂业,
   泰昌矿业,
   江特电动车,
   江特客车厂,
   江特节能公司,
   江特高新装备公司,
   江特高新武汉分公司
}
