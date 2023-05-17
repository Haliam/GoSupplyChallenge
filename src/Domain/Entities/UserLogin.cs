namespace GoSupply.Domain.Entities;

public class UserLogin
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public string? UserName { get; set; }

    [Required]
    public string? Password { get; set; }
}
