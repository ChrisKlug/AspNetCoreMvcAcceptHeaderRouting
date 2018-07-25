using AcceptHeaderRoutingDemo.Web.Data;

namespace AcceptHeaderRoutingDemo.Web.Models
{
    public class ExtendedUserModel
    {
        public const string ContentType = "application/vnd.mydemo.v2.user-extended";

        private ExtendedUserModel(int id, string username, string firstName, string lastName, int age)
        {
            Id = id;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            FullName = $"{firstName} {lastName}";
            Age = age;
        }

        public static ExtendedUserModel Create(User user)
        {
            return new ExtendedUserModel(user.Id, user.Username, user.FirstName, user.LastName, user.Age);
        }

        public int Id { get; }
        public string Username { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string FullName { get; }
        public int Age { get; }
    }
}
