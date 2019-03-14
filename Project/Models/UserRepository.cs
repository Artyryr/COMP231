//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Project.Models
//{
//    public class UserRepository : IUserRepository
//    {
//        private IdentityDbContext context;

//        public UserRepository(IdentityDbContext ctx)
//        {
//            context = ctx;
//        }
//        public IQueryable<GeneralUser> Users => context.Users;

//        public void AddUser(GeneralUser user)
//        {
//            if (user.Id == null || user.Id == "")
//            {
//                context.Users.Add(user);
//            }
//            else
//            {
//                GeneralUser dbEntry = context.Users
//                    .FirstOrDefault(p => p.Id == user.Id);

//                if (dbEntry != null)
//                {
//                    dbEntry.Id = user.Id;
//                    dbEntry.FirstName = user.FirstName;
//                    dbEntry.LastName = user.LastName;
//                    dbEntry.Province = user.Province;
//                    dbEntry.Street = user.Street;
//                    dbEntry.Telephone = user.Telephone;
//                    dbEntry.UserName = user.UserName;
//                    dbEntry.ZIP = user.ZIP;
//                }
//            }
//            context.SaveChanges();
//        }
//    }
//}
