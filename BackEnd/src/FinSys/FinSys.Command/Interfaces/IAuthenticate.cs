namespace FinSys.Command.Interfaces
{
    public interface IAuthenticate
    {
        Task<bool> AuthenticateAsync(string email, string senha);
        Task<bool> UserExists(string email);
        public string GenerateToken(Guid id, string email);
        Task<Guid> GetUserByEmail(string email);
    }
}
