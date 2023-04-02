using System.Collections.Generic;
using SHOPPINGCART.Application.Resources;
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
                string password = Resource_Application.GeneratedPassword();
                string subject = "Account Creation";
                string message_email = "<h3>Your account was created successfully</h3></br><p>Your password to access is:!password!</p>";  //</br> salto de linea
                message_email = message_email.Replace("!password!", password);

                bool answer = Resource_Application.SendEmail(obj.Email, subject, message_email);
                if (answer)
                {
                    obj.Password = Resource_Application.ConvertSha256(password);//actualiza la clave con la encriptada
                    return objShoppingCartInfrastructure.Register(obj, out Message); // se registra el usuario
                }
                else
                {
                    Message = "Can't send mail";
                    return 0;
                }
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
