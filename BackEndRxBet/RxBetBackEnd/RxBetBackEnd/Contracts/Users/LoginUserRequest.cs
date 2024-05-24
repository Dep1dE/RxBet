using System.ComponentModel.DataAnnotations;

namespace RxBetBackEnd.Contracts.Users;

public record LoginUserRequest(
    [Required] string Email,
    [Required] string Password);