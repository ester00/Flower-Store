using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class OrderItemRepository<TEntity> : GenericRepository<TEntity> where TEntity : class
    {
        public OrderItemRepository(DataContext context) : base(context)
        {
        }
    }
}
