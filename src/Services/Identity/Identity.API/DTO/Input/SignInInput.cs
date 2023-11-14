namespace Identity.API.DTO.Input
{
    public class SignInInput
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
