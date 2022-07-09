using Data.Context;
using Data.Entities.Contractors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class UserRepository<TEntity> : GenericRepository<TEntity> where TEntity : class, IUserName
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public virtual TEntity GetByUserName(string userName)
        {
            return (from e in base.context.Set<TEntity>()
                    where e.UserName == userName
                    select e).SingleOrDefault();
        }

    }
}
