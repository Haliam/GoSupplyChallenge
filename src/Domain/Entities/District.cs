﻿namespace GoSupply.Domain.Entities;

public class District
{
    [Key]
    public int Id { get; set; }


    [Required]
    public string Name { get; set; }


    [Required]
    public int ProvinceId { get; set; }
}
