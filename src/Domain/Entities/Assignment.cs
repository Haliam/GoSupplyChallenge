namespace GoSupply.Domain.Entities;

public class Assignment
{
    [Key]
    public int Id { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
    public DateTime AssignmentDate { get; set; }


    [Required]
    public int CourseId { get; set; }


    [Required]
    public int TeacherId { get; set; }
}
