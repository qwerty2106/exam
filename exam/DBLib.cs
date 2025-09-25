using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam
{
    public static class DBLib
    {
        static string connectionString = "Server=ADCLG1;Database=Пробник_Асессорова;Trusted_Connection=True";

        //SELECT PARTNERS
        public static List<Partner> GetData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Partners";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<Partner> partnersList = new List<Partner>();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Partner partner = new Partner();
                                    partner.IDPartner = reader.GetInt32(0);
                                    partner.PartnerType = reader.GetString(1);
                                    partner.Name = reader.GetString(2);
                                    partner.Director = reader.GetString(3);
                                    partner.Email = reader.GetString(4);
                                    partner.Phone = reader.GetString(5);
                                    partner.Address = reader.GetString(6);
                                    partner.Inn = reader.GetString(7);
                                    partner.Rating = reader.GetInt32(8);
                                    partnersList.Add(partner);
                                }
                            }
                            return partnersList;
                        } 
                    }
                }
            }
            catch (SqlException)
            {
                return new List<Partner>();
            }
        }

        //INSERT
        public static int CreateData(Partner partner)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Partners(PartnerType, Name, Director, Email, Phone, Address, Inn, Rating) " +
                        "VALUES(@PartnerType, @Name, @Director, @Email, @Phone, @Address, @Inn, @Rating)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PartnerType", partner.PartnerType);
                        command.Parameters.AddWithValue("@Name", partner.Name);
                        command.Parameters.AddWithValue("@Director", partner.Director);
                        command.Parameters.AddWithValue("@Email", partner.Email);
                        command.Parameters.AddWithValue("@Phone", partner.Phone);
                        command.Parameters.AddWithValue("@Address", partner.Address);
                        command.Parameters.AddWithValue("@Inn", partner.PartnerType);
                        command.Parameters.AddWithValue("@Rating", partner.Rating);

                        int result = command.ExecuteNonQuery();
                        return result;
                    }
                }
            }
            catch (SqlException)
            {
                return 0;
            }
        }

        //UPDATE
        public static int UpdateData(Partner partner)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Partners SET PartnerType=@PartnerType, Name=@Name, Director=@Director, Email=@Email, Phone=@Phone, Address=@Address, Inn=@Inn, Rating=@Rating WHERE IDPartner=@IDPartner";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDPartner", partner.IDPartner);
                        command.Parameters.AddWithValue("@PartnerType", partner.PartnerType);
                        command.Parameters.AddWithValue("@Name", partner.Name);
                        command.Parameters.AddWithValue("@Director", partner.Director);
                        command.Parameters.AddWithValue("@Email", partner.Email);
                        command.Parameters.AddWithValue("@Phone", partner.Phone);
                        command.Parameters.AddWithValue("@Address", partner.Address);
                        command.Parameters.AddWithValue("@Inn", partner.Inn);
                        command.Parameters.AddWithValue("@Rating", partner.Rating);

                        int result = command.ExecuteNonQuery();
                        return result;
                    }
                }
            }
            catch (SqlException)
            {
                return 0;
            }
        }

        //DELETE
        public static int DeleteData(Partner partner)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Partners WHERE IDPartner=@IDPartner";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDPartner", partner.IDPartner);

                        int result = command.ExecuteNonQuery();
                        return result;
                    }
                }
            }
            catch (SqlException)
            {
                return 0;
            }
        }

        //SELECT TYPES
        public static List<string> GetTypes()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM PartnerTypes";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<string> typesList = new List<string>();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    typesList.Add(reader.GetString(0));
                                }
                            }
                            return typesList;
                        }
                    }
                }
            }
            catch (SqlException)
            {
                return new List<string>();
            }
        }

    }
}
