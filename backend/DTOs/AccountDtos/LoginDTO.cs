using System.ComponentModel.DataAnnotations;

namespace schoolApi.DTOs.AccountDtos;

public class LoginDTO
{
    [Required]
    public string Username { get; set; } = String.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}
