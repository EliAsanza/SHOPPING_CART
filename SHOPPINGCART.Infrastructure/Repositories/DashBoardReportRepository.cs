using SHOPPINGCART.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace SHOPPINGCART.Infrastructure.Repositories
{
    public class DashBoardReportRepository
    {
        public List<Reports> Sales(string startDate, string endingDate, string transactionId)
        {
            List<Reports> list = new List<Reports>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Connection.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_SalesReport", oconexion);
                    cmd.Parameters.AddWithValue("startdate", startDate);
                    cmd.Parameters.AddWithValue("endingdate", endingDate);
                    cmd.Parameters.AddWithValue("transactionId", transactionId);
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(
                            new Reports() //Damos valor y accedemos a sus propiedades 
                            {
                                Saledate = dr["Saledate"].ToString(),
                                Customer = dr["Customer"].ToString(),
                                Product = dr["Product"].ToString(),
                                Price = Convert.ToDecimal(dr["Price"]), 
                                Quantity = Convert.ToInt32(dr["Quantity"].ToString()),
                                Subtotal = Convert.ToDecimal(dr["Subtotal"]),
                                TotalAmount = Convert.ToDecimal(dr["TotalAmount"]),
                                TransactionId = dr["TransactionId"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                list = new List<Reports>();
            }

            return list;
        }

        public DashBoard ViewDashBoard()
        {
            DashBoard objeto = new DashBoard();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Connection.cn))
                {

                    SqlCommand cmd = new SqlCommand("sp_ReportDashboard", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            objeto = new DashBoard() //Damos valor y accedemos a sus propiedades 
                            {
                                TotalCustomer = Convert.ToInt32(dr["TotalCustomer"]),
                                TotalSale = Convert.ToDecimal(dr["TotalSale"]),
                                TotalProduct = Convert.ToInt32(dr["ToTalProduct"]),
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objeto = new DashBoard();

            }
            return objeto;
        }

    }
}
