namespace GoSupply.Application.Dtos;

public class StudentDto
{
    [JsonIgnore]
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

    [Required]
    public string Address { get; set; }

    public int DistrictId { get; set; }
}
