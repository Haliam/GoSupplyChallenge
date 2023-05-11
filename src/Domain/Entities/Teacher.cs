namespace GoSupply.Domain.Entities
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string SurName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string MobileNumber { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string Graduate { get; set; }

        [Required]
        public int ProfessionId { get; set; }
    }
}
