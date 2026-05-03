using System.ComponentModel.DataAnnotations;

namespace schoolApi.DTOs.AccountDtos;

public class RegisterDTO
{
    [Required]
    public string? Username { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    public bool EmailConfirmed { get; set; }
    [Required]
    public string? Password { get; set; }

}
