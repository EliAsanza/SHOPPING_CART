﻿using SHOPPINGCART.Domain.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace SHOPPINGCART.Infrastructure.Repositories
{
    public class CategoryRepository
    {
        public List<Category> Lists()
        {
            List<Category> ListCategory = new List<Category>();
            try
            {
                using (SqlConnection oconnection = new SqlConnection(Connection.cn))//Ado.Net
                {
                    string query = "select CategoryId,[Description],Active from CATEGORY";

                    SqlCommand cmd = new SqlCommand(query, oconnection);
                    cmd.CommandType = CommandType.Text;
                    oconnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader()) //para poder leer lo que esta dentro del query
                    {
                        while (dr.Read()) //mientras estas leyendo los datos, guarda esos datos en la lista
                        {
                            ListCategory.Add(new Category()
                            {
                                CategoryId = Convert.ToInt32(dr["CategoryId"]), //dr es que pueda leer
                                Description = dr["Description"].ToString(),
                                Active = Convert.ToBoolean(dr["Active"]),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ListCategory = new List<Category>();
            }
            return ListCategory;
        }

        public int Register(Category obj, out string Message)
        {
            int autogeneratedId = 0;
            Message = string.Empty;
            try
            {
                using (SqlConnection oconnection = new SqlConnection(Connection.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrationCategory", oconnection);
                    cmd.Parameters.AddWithValue("Description", obj.Description);
                    cmd.Parameters.AddWithValue("Active", obj.Active);
                    cmd.Parameters.Add("Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Message", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconnection.Open();
                    cmd.ExecuteNonQuery();
                    autogeneratedId = (int)cmd.Parameters["Result"].Value;
                    Message = cmd.Parameters["Message"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                autogeneratedId = 0;
                Message = ex.Message;
            }
            return autogeneratedId;
        }

        public bool Edit(Category obj, out string Message)
        {
            bool result = false;
            Message = string.Empty;

            try
            {
                using (SqlConnection oconnection = new SqlConnection(Connection.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditCategory", oconnection);
                    cmd.Parameters.AddWithValue("CategoryId", obj.CategoryId);
                    cmd.Parameters.AddWithValue("Description", obj.Description);
                    cmd.Parameters.AddWithValue("Active", obj.Active);
                    cmd.Parameters.Add("Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Message", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconnection.Open();
                    cmd.ExecuteNonQuery();
                    result = Convert.ToBoolean(cmd.Parameters["Result"].Value);
                    Message = cmd.Parameters["Message"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                result = false;
                Message = ex.Message;
            }
            return result;
        }

        public bool Delete(int categoryId, out string Message)
        {
            bool result = false;
            Message = string.Empty;
            try
            {
                using (SqlConnection oconnection = new SqlConnection(Connection.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_DeleteCategory", oconnection);
                    cmd.Parameters.AddWithValue("CategoryId", categoryId);
                    cmd.Parameters.Add("Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Message", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconnection.Open();
                    cmd.ExecuteNonQuery();
                    result = Convert.ToBoolean(cmd.Parameters["Result"].Value);
                    Message = cmd.Parameters["Message"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                result = false;
                Message = ex.Message;
            }
            return result;
        }
    }
}
