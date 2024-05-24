namespace RxBetAuthorization.Interfaces.Auth
{
    public interface IJwtOptions
    {
        int ExpireHours { get; set; }
        string SecretKey { get; set; }
    }
}