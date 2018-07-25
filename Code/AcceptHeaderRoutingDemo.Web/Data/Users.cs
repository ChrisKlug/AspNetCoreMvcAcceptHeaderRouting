using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcceptHeaderRoutingDemo.Web.Data
{
    public interface IUsers
    {
        Task<User[]> All();
        Task<User> WhereIdIs(int id);
    }

    public class Users : IUsers
    {
        private List<User> _users;

        public Users()
        {
            _users = new List<User> {
                new User(1, "ZeroKoll", "Chris", "Klug", 38),
                new User(2, "JohnnyBoy", "John", "Doe", 25),
                new User(3, "GeekyGal43", "Kirsty", "Holmes", 45),
                new User(4, "Terminatrix", "Sara", "Jensen", 17),
            };
        }

        public Task<User[]> All()
        {
            return Task.FromResult(_users.ToArray());
        }

        public Task<User> WhereIdIs(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(user);
        }
    }
}
