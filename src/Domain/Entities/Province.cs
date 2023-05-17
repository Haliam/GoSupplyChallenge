namespace GoSupply.Domain.Entities;

public class Province
{
    [Key]
    public int Id { get; set; }


    [Required]
    public string Name { get; set; }
}
