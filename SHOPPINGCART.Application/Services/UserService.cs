using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHOPPINGCART.Domain;
using SHOPPINGCART.Domain.Entities;
using SHOPPINGCART.Infrastructure;

namespace SHOPPINGCART.Application
{
    public class UserService
    {
        private UserRepository objShoppingCartInfrastructure = new UserRepository();

        public List<User> Lists() 
        {

                    
            return objShoppingCartInfrastructure.Lists();
        
        }



    }
}
