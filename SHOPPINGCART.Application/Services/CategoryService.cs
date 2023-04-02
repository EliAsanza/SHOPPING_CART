using SHOPPINGCART.Application.Resources;
using SHOPPINGCART.Domain.Entities;
using SHOPPINGCART.Infrastructure.Repositories;
using System.Collections.Generic;

namespace SHOPPINGCART.Application.Services
{
    public class CategoryService
    {
        private CategoryRepository objShoppingCartInfrastructure = new CategoryRepository();

        public List<Category> Lists()
        {
            return objShoppingCartInfrastructure.Lists();
        }

        public int Register(Category obj, out string Message)
        {
            Message = string.Empty;

            if (string.IsNullOrEmpty(obj.Description) || string.IsNullOrWhiteSpace(obj.Description))
            {
                Message = "Category description cannot be empty";
            }

            if (string.IsNullOrEmpty(Message))
            {
               return objShoppingCartInfrastructure.Register(obj, out Message); 
               
            }
            else
            {
                return 0;
            }
        }

        public bool Edit(Category obj, out string Message)
        {
            Message = string.Empty;

            if (string.IsNullOrEmpty(obj.Description) || string.IsNullOrWhiteSpace(obj.Description))
            {
                Message = "Category description cannot be empty";
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
