namespace TestingSystem.Model
{
    public class Student
    {
        public Student()
        {
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}
