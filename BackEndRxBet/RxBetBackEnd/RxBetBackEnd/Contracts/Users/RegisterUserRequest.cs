using System.ComponentModel.DataAnnotations;

namespace RxBetBackEnd.Contracts.Users;

public record RegisterUserRequest(
    [Required] string UserName,
    [Required] string Email,
    [Required] string Password);
