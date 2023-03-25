using System;
using System.Collections.Generic;
using SHOPPINGCART.Domain.Entities;
using System.Data.SqlClient;
using System.Data;

namespace SHOPPINGCART.Infrastructure
{
    public class UserRepository
    {
        public List<User> Lists()
        {
            List<User> Listuser = new List<User>();
            try
            {
                using (SqlConnection oconnection = new SqlConnection(Connection.cn))
                {
                    string query = "select UserId,[Name],Lastname,Email,[Password],[Reset],Active from [USER]";

                    SqlCommand cmd = new SqlCommand(query, oconnection);
                    cmd.CommandType = CommandType.Text;
                    oconnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader()) //poara poder leer lo que esta dentro del query
                    {
                        while (dr.Read()) //mientras estas leyendo los datos, guarda esos datos en la lista
                        {
                            Listuser.Add(new User()
                            {
                                UserId = Convert.ToInt32(dr["UserId"]), //dr es que pueda leer
                                Name = dr["Name"].ToString(),
                                LastName = dr["LastName"].ToString(),
                                Email = dr["email"].ToString(),
                                Password = dr["Password"].ToString(),
                                Reset = Convert.ToBoolean(dr["Reset"]),
                                Active = Convert.ToBoolean(dr["Active"]),
                            }
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                Listuser = new List<User>();
            }
            return Listuser;
        }
    }
}
