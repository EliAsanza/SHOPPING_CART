using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHOPPINGCART.Application.Resources;
using SHOPPINGCART.Domain;
using SHOPPINGCART.Domain.Entities;
using SHOPPINGCART.Infrastructure;

namespace SHOPPINGCART.Application
{
    public class UserService
    {
        //add some comment
        private UserRepository objShoppingCartInfrastructure = new UserRepository();

        public List<User> Lists() 
        {
            return objShoppingCartInfrastructure.Lists();
        }
        public int Register(User obj, out string Message)
        {
            Message = string.Empty;

            if (string.IsNullOrEmpty(obj.Name) || string.IsNullOrWhiteSpace(obj.Name))
            {
                Message = "Username cannot be empty";
            }
            else if (string.IsNullOrEmpty(obj.LastName) || string.IsNullOrWhiteSpace(obj.LastName))
            {
                Message = "User's last name cannot be empty";
            }
            else if (string.IsNullOrEmpty(obj.Email) || string.IsNullOrWhiteSpace(obj.Email))
            {
                Message = "User mail cannot be emptyy";
            }

            if (string.IsNullOrEmpty(Message))
            {


                string Password = "test123";
                obj.Password = Resource_Application.ConvertSha256(Password);

                return objShoppingCartInfrastructure.Register(obj, out Message);
            }
            else
            {
                return  0;
            }
        }

        public bool Edit(User obj, out string Message)
        {
            Message = string.Empty;

            if (string.IsNullOrEmpty(obj.Name) || string.IsNullOrWhiteSpace(obj.Name))
            {
                Message = "Username cannot be empty";
            }
            else if (string.IsNullOrEmpty(obj.LastName) || string.IsNullOrWhiteSpace(obj.LastName))
            {
                Message = "User's last name cannot be empty";
            }
            else if (string.IsNullOrEmpty(obj.Email) || string.IsNullOrWhiteSpace(obj.Email))
            {
                Message = "User mail cannot be emptyy";
            }

            if (string.IsNullOrEmpty(Message))
            {
                return objShoppingCartInfrastructure.Edit(obj, out Message);
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id, out string Message)
        { 
            return objShoppingCartInfrastructure.Delete(id, out Message);
        
        }


    }
}
