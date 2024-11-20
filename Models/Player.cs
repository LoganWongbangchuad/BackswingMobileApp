using SQLite;
using System.ComponentModel.DataAnnotations;

public class Player
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Required]
    public string Phone { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }


    [Required]
    public string Address { get; set; }


    [Required]
    public string Username { get; set; }


    [Required]
    [MinLength(6)]
    public string Password { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Score must be a positive number.")]
    public int? Score { get; set; }

    // Add the courseId property
    public int courseId { get; set; }
}