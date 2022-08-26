namespace Model.DtoModels
{
    public class CreateUserDto
    {
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public PinnedFile PinnedFile { get; set; }
    }
}
