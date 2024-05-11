namespace Entities.Exceptions.User
{
    public class RefreshTokenBadRequestException : BadRequestException
    {
        public RefreshTokenBadRequestException() : base("Token is not valid!")
        {
        }
    }
}
