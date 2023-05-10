namespace GoSupply.Domain.Entities
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }


        [Required]
        public string Name { get; set; }


        [Required]
        public string SurName { get; set; }


        [Required]
        public string Address { get; set; }


        [Required]
        public string MobileNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string grad_doc { get; set; }

        public int ProfessionId { get; set; }
    }
}
