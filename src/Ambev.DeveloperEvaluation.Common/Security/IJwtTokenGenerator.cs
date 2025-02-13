namespace Ambev.DeveloperEvaluation.Common.Security
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ISaleItem user);
    }
}
