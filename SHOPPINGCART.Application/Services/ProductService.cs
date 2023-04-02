using SHOPPINGCART.Domain.Entities;
using SHOPPINGCART.Infrastructure.Repositories;
using System.Collections.Generic;

namespace SHOPPINGCART.Application.Services
{
    public class ProductService
    {
        private ProductRepository objShoppingCartInfrastructure = new ProductRepository();

        public List<Product> Lists()
        {
            return objShoppingCartInfrastructure.Lists();
        }

        public int Register(Product obj, out string Message)
        {
            Message = string.Empty;

            if (string.IsNullOrEmpty(obj.Name) || string.IsNullOrWhiteSpace(obj.Name))
            {
                Message = "Product name cannot be empty";
            }
            else if (string.IsNullOrEmpty(obj.Description) || string.IsNullOrWhiteSpace(obj.Description))
            {
                Message = "Product description cannot be empty";
            }
            else if (obj.oBrandId.BrandId == 0)
            {
                Message = "You must select a Brand";
            }
            else if (obj.oCategoryId.CategoryId == 0)
            {
                Message = "You must select a Category";
            }
            else if (obj.Price == 0)
            {
                Message = "You must enter the Price of the product";
            }
            else if (obj.Stock == 0)
            {
                Message = "You must enter the Stock of the product";
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

        public bool Edit(Product obj, out string Message)
        {
            Message = string.Empty;

            if (string.IsNullOrEmpty(obj.Name) || string.IsNullOrWhiteSpace(obj.Name))
            {
                Message = "Product name cannot be empty";
            }
            else if (string.IsNullOrEmpty(obj.Description) || string.IsNullOrWhiteSpace(obj.Description))
            {
                Message = "Product description cannot be empty";
            }
            else if (obj.oBrandId.BrandId == 0)
            {
                Message = "You must select a Brand";
            }
            else if (obj.oCategoryId.CategoryId == 0)
            {
                Message = "You must select a Category";
            }
            else if (obj.Price == 0)
            {
                Message = "You must enter the Price of the product";
            }
            else if (obj.Stock == 0)
            {
                Message = "You must enter the Stock of the product";
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

        public bool SaveImageData(Product oProduct, out string Message)
        {
            return objShoppingCartInfrastructure.SaveImageData(oProduct, out Message);
        }

        public bool Delete(int ProductId, out string Message)
        {
            return objShoppingCartInfrastructure.Delete(ProductId, out Message);
        }


    }
}
