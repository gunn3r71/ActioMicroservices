namespace Actio.Common.Commands
{
    public class AuthenticateUserCommand : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}