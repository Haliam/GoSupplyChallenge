namespace GoSupply.Domain.Entities;

public class Student
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string SurName { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
    public DateTime BirthDate { get; set; }

    [Required]
    public string Gender { get; set; }

    public string Address { get; set; }

    public int tcol_est { get; set; }

    public int gins_est { get; set; }

    public int DistrictId { get; set; }
}