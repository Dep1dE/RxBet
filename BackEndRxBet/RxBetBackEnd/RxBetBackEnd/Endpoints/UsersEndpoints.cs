using RxBetAuthorization.Services;
using RxBetBackEnd.Contracts.Users;
using System.Runtime.CompilerServices;

namespace RxBetBackEnd.Endpoints
{
    public static class UsersEndpoints
    {
        public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder builder)
        {
            builder.MapPost("register", Register);
            builder.MapPost("login", Login);

            return builder; 
        }

        private static async Task<IResult> Register(RegisterUserRequest request, UsersService usersService)
        {
            await usersService.Register(request.UserName, request.Email, request.Password);

            return Results.Ok();
        }

        private static async Task<IResult> Login(LoginUserRequest request, UsersService usersService)
        {
            var token= await usersService.Login(request.Email, request.Password);

            return Results.Ok(token);    
        }
    }
}
