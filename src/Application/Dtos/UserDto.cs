namespace GoSupply.Application.Dtos
{
    public class UserDto
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime BirthDate { get; set; }

        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public int Role { get; set; }

        public string RoleName
        {
            get
            {
                switch (Role)
                {
                    case 1:
                        return RoleName = "Admin";
                    case 2:
                        return RoleName = "User";
                    case 3:
                        return RoleName = "Manager";
                    default:
                        return RoleName = "Guest";
                }
            }
            set { }
        }


        [JsonIgnore]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
