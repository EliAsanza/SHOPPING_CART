using SHOPPINGCART.Domain.Entities;
using SHOPPINGCART.Infrastructure.Repositories;
using System.Collections.Generic;

namespace SHOPPINGCART.Application.Services
{
    public class BrandService
    {
        private BrandRepository objShoppingCartInfrastructure = new BrandRepository();

        public List<Brand> Lists()
        {
            return objShoppingCartInfrastructure.Lists();
        }

        public int Register(Brand obj, out string Message)
        {
            Message = string.Empty;

            if (string.IsNullOrEmpty(obj.Description) || string.IsNullOrWhiteSpace(obj.Description))
            {
                Message = "Brand description cannot be empty";
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

        public bool Edit(Brand obj, out string Message)
        {
            Message = string.Empty;

            if (string.IsNullOrEmpty(obj.Description) || string.IsNullOrWhiteSpace(obj.Description))
            {
                Message = "Brand description cannot be empty";
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

        public bool Delete(int brandId, out string Message)
        {
            return objShoppingCartInfrastructure.Delete(brandId, out Message);
        }
    }
}
