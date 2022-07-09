﻿using Data.Entities.Contractors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class User : BaseEntity, IUserName
    {
        public User()
        {
            this.Orders = new HashSet<Order>();
        } 

        public string UserName { get; set; }

        public string Password { get; set; }
       
        public virtual ICollection<Order> Orders { get; set; }
    }
}
