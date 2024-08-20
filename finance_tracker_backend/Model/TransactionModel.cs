using System;
using System.ComponentModel.DataAnnotations;

public class Transaction
{
    public int Id { get; set; }

    [Required]
    public int Amount { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public string? Description { get; set; }

    [Required]
    public string? Category { get; set; }

    public string? UserId { get; set; }
}
