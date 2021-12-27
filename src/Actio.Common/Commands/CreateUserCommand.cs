namespace Actio.Common.Commands
{
    public class CreateUserCommand : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}