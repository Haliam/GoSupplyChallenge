﻿namespace GoSupply.Domain.Entities
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }


        [Required]
        public string Name { get; set; }


        [Required]
        public decimal Price { get; set; }


        [Required]
        public int Duration { get; set; }
    }
}
