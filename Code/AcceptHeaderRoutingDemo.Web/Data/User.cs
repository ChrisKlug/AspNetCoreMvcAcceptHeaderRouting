namespace AcceptHeaderRoutingDemo.Web.Data
{
    public class User
    {
        public User(int id, string username, string firstName, string lastName, int age)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Age = age;
        }

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Username { get; }
        public int Age { get; }
    }
}
