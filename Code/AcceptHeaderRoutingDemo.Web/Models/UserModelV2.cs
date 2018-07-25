using AcceptHeaderRoutingDemo.Web.Data;

namespace AcceptHeaderRoutingDemo.Web.Models
{
    public class UserModelV2
    {
        public const string ContentType = "application/vnd.mydemo.v2.user";

        public UserModelV2()
        {

        }
        private UserModelV2(int id, string firstName, string lastName, int age)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public static UserModelV2 Create(User user)
        {
            return new UserModelV2(user.Id, user.FirstName, user.LastName, user.Age);
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
