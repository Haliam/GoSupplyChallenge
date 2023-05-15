namespace GoSupply.Domain.Entities;

public class Profession
{
    [Key]
    public int Id { get; set; }


    [Required]
    public string Name { get; set; }
}
