using System.Configuration;

namespace SHOPPINGCART.Infrastructure
{
    public class Connection
    {
        public static string cn = ConfigurationManager.ConnectionStrings["cadena"].ToString();
    }
}
