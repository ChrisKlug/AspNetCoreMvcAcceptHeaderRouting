using AcceptHeaderRoutingDemo.Web.Data;

namespace AcceptHeaderRoutingDemo.Web.Models
{
    public class UserModel
    {
        public const string ContentType = "application/vnd.mydemo.v1.user";

        private UserModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static UserModel Create(User user)
        {
            return new UserModel(user.Id, $"{user.FirstName} {user.LastName}");
        }

        public int Id { get; }
        public string Name { get; }
    }
}
