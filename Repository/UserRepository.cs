using UserMicroservice.Context;
using UserMicroservice.Models;
using UserMicroservice.Repository.Interfaces;

namespace UserMicroservice.Repository
{
    public class UserRepository : IDataRepository<User>
    {
        readonly UserContext _userContext;
        public UserRepository(UserContext context)
        {
            _userContext = context;
        }
        public void Add(User entity)
        {
            _userContext.users.Add(entity);
            _userContext.SaveChanges();
        }

        public void Delete(User entity)
        {
            _userContext.users.Remove(entity);
            _userContext.SaveChanges();
        }

        public User Get(long id)
        {
            return _userContext.users
                   .FirstOrDefault(e => e.UserId == id);
        }

        public User Get(string username, string password)
        {
            return _userContext.users
                   .FirstOrDefault(e => e.UserName == username && e.Password==password);
        }

        public IEnumerable<User> GetAll()
        {
            return _userContext.users.ToList();
        }

        public void Update(User dbEntity, User entity)
        {
            dbEntity.FirstName = entity.FirstName;
            dbEntity.LastName = entity.LastName;
            dbEntity.Email = entity.Email;
            dbEntity.Mobile = entity.Mobile;
            dbEntity.UserName = entity.UserName;
            dbEntity.Password = entity.Password;
            _userContext.SaveChanges();
        }
    }
}
