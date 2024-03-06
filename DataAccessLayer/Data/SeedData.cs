using Bogus;
using EntityLayer.Entity;

namespace DataAccessLayer.Data
{
    public class SeedData
    {
        private static List<User> _users;
        public static List<User> GetUser(int number)
        {
            if (_users == null)
            {
                _users = new Faker<User>()
                    .RuleFor(u => u.id, f => f.IndexFaker)
                    .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                    .RuleFor(u => u.LastName, f => f.Name.LastName())
                    .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                    .RuleFor(u => u.EMailAdress, f => f.Internet.Email())
                    .Generate(number);
            }
            return _users;
        }
    }
}
