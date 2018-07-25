using AcceptHeaderRoutingDemo.Web.Data;

namespace AcceptHeaderRoutingDemo.Web.Models
{
    public class ExtendedUserModel
    {
        public const string ContentType = "application/vnd.mydemo.v2.user-extended";

        public ExtendedUserModel()
        {

        }
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

        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
    }
}
