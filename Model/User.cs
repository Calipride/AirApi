namespace AirApi.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; } // Note: Plain text passwords are a bad practice, consider hashing.
        public string Email { get; set; }



    }
}
