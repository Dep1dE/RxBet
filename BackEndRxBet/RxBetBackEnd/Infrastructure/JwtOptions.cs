using Microsoft.Extensions.Configuration;
using RxBetAuthorization.Interfaces.Auth;

namespace Infrastructure
{
    public class JwtOptions : IJwtOptions
    {
        public JwtOptions(IConfiguration config)
        {
            SecretKey = config["JwtOptions:SecretKey"]!;
            ExpireHours = Convert.ToInt32(config["JwtOptions:ExpiresHours"]!);
        }
        public string SecretKey { get; set; } = string.Empty;
        public int ExpireHours { get; set; } //Minutes
    }
}
