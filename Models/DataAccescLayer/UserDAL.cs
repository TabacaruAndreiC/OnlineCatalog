using Platforma_Educationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platforma_Educationala.Models.DataAccescLayer
{
    class UserDAL
    {
        public ObservableCollection<Users> GetAllUsers()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllUsers", con);
                ObservableCollection<Users> result = new ObservableCollection<Users>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Users p = new Users();
                    p.ID = (int)(reader[0]);//reader.GetInt(0);
                    p.Username = reader.GetString(1);//reader[1].ToString();
                    p.Password = reader.IsDBNull(2) ? null : reader[2].ToString();
                    result.Add(p);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void AddUser(string username, string password)
        {
            int randomId;
            Random random = new Random();

            using (SqlConnection con = DALHelper.Connection)
            {
                con.Open();

                // Check if the generated ID already exists in the Users table
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE ID = @id", con);
                SqlParameter checkParamId = new SqlParameter("@id", SqlDbType.Int);
                do
                {
                    // Generate a random number between 5 and 25 (inclusive)
                    randomId = random.Next(5, 26);
                    checkParamId.Value = randomId;

                    checkCmd.Parameters.Clear();
                    checkCmd.Parameters.Add(checkParamId);

                    int existingCount = (int)checkCmd.ExecuteScalar();
                    if (existingCount == 0)
                        break; // Found a unique ID, exit the loop
                } while (true);

                // Insert the user with the unique ID
                SqlCommand insertCmd = new SqlCommand("AddUser", con);
                insertCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@id", randomId);
                SqlParameter paramUsername = new SqlParameter("@username", username);
                SqlParameter paramPassword = new SqlParameter("@password", password);

                insertCmd.Parameters.Add(paramId);
                insertCmd.Parameters.Add(paramUsername);
                insertCmd.Parameters.Add(paramPassword);

                insertCmd.ExecuteNonQuery();
            }
        }


        public void AddElev(string nume, string clasa)
        {
            int randomId;
            Random random = new Random();

            // Generate a random number between 5 and 25 (inclusive)
            randomId = random.Next(5, 26);

            int clasaId = int.Parse(clasa); // Convert clasa to int

            using (SqlConnection con = DALHelper.Connection)
            {
                con.Open();

                // Check if the generated ID already exists in the Users table
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE ID = @id", con);
                SqlParameter checkParamId = new SqlParameter("@id", SqlDbType.Int);
                do
                {
                    checkParamId.Value = randomId;

                    checkCmd.Parameters.Clear();
                    checkCmd.Parameters.Add(checkParamId);

                    int existingCount = (int)checkCmd.ExecuteScalar();
                    if (existingCount == 0)
                        break; // Found a unique ID, exit the loop
                    else
                        randomId = random.Next(5, 26); // Generate a new random ID
                } while (true);

                // Insert the user with the unique ID
                SqlCommand insertCmd = new SqlCommand("AddElev", con);
                insertCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@ID", randomId); // Use correct parameter name
                SqlParameter paramNume = new SqlParameter("@Nume", nume);
                SqlParameter paramClasa = new SqlParameter("@Clasa", clasaId);
                insertCmd.Parameters.Add(paramId);
                insertCmd.Parameters.Add(paramNume);
                insertCmd.Parameters.Add(paramClasa);

                insertCmd.ExecuteNonQuery();
            }
        }



        public void AddProfesor(string nume, string clasa)
        {
            int clasaId = int.Parse(clasa); // Convert clasa to int

            int randomId;
            Random random = new Random();

            // Generate a random number between 5 and 25 (inclusive)
            randomId = random.Next(5, 26);

            using (SqlConnection con = DALHelper.Connection)
            {
                con.Open();

                // Check if the generated ID already exists in the Users table
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE ID = @id", con);
                SqlParameter checkParamId = new SqlParameter("@id", SqlDbType.Int);
                do
                {
                    checkParamId.Value = randomId;

                    checkCmd.Parameters.Clear();
                    checkCmd.Parameters.Add(checkParamId);

                    int existingCount = (int)checkCmd.ExecuteScalar();
                    if (existingCount == 0)
                        break; // Found a unique ID, exit the loop
                    else
                        randomId = random.Next(5, 26); // Generate a new random ID
                } while (true);

                // Insert the user with the unique ID
                SqlCommand insertCmd = new SqlCommand("AddProfesor", con);
                insertCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@ID", randomId); // Use correct parameter name
                SqlParameter paramNume = new SqlParameter("@Nume", nume);
                SqlParameter paramClasa = new SqlParameter("@Clasa", clasaId);
                insertCmd.Parameters.Add(paramId);
                insertCmd.Parameters.Add(paramNume);
                insertCmd.Parameters.Add(paramClasa);

                insertCmd.ExecuteNonQuery();
            }
        }



        public void AddDiriginte(string nume, string clasa)
        {
            int clasaId = int.Parse(clasa); // Convert clasa to int

            int randomId;
            Random random = new Random();

            // Generate a random number between 5 and 25 (inclusive)
            randomId = random.Next(5, 26);

            using (SqlConnection con = DALHelper.Connection)
            {
                con.Open();

                // Check if the generated ID already exists in the Users table
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE ID = @id", con);
                SqlParameter checkParamId = new SqlParameter("@id", SqlDbType.Int);
                do
                {
                    checkParamId.Value = randomId;

                    checkCmd.Parameters.Clear();
                    checkCmd.Parameters.Add(checkParamId);

                    int existingCount = (int)checkCmd.ExecuteScalar();
                    if (existingCount == 0)
                        break; // Found a unique ID, exit the loop
                    else
                        randomId = random.Next(5, 26); // Generate a new random ID
                } while (true);

                // Insert the user with the unique ID
                SqlCommand insertCmd = new SqlCommand("AddDiriginte", con);
                insertCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@ID", randomId); // Use correct parameter name
                SqlParameter paramNume = new SqlParameter("@Nume", nume);
                SqlParameter paramClasa = new SqlParameter("@Clasa", clasaId);
                insertCmd.Parameters.Add(paramId);
                insertCmd.Parameters.Add(paramNume);
                insertCmd.Parameters.Add(paramClasa);

                insertCmd.ExecuteNonQuery();
            }
        }


        public int GetUserIDByUsername(string username)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetUserIDByUsername", con);
                int result = new int();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramUsername = new SqlParameter("@username", username);
                cmd.Parameters.Add(paramUsername);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = (int)(reader[0]);//reader.GetInt(0);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void ModifyUser(string username, string password, int id, string nume, string clasa,string tip)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                Console.WriteLine(clasa);
                SqlCommand cmd = new SqlCommand("ModifyUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramUsername = new SqlParameter("@username", username);
                SqlParameter paramPassword = new SqlParameter("@password", password);
                SqlParameter paramId = new SqlParameter("@id", id);
                SqlParameter paramNume = new SqlParameter("@Nume", nume);
                SqlParameter paramClasa = new SqlParameter("@clasa", clasa);
                SqlParameter paramTip = new SqlParameter("@tip", tip);
                cmd.Parameters.Add(paramUsername);
                cmd.Parameters.Add(paramPassword);
                cmd.Parameters.Add(paramId);
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramClasa);
                cmd.Parameters.Add(paramTip);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteUser(int id)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@id", id);
                cmd.Parameters.Add(paramId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Users GetUserById(int id)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetUserById", con);
                Users result = new Users();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter("@id", id);
                cmd.Parameters.Add(paramId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.ID = (int)(reader[0]);//reader.GetInt(0);
                    result.Username = reader.GetString(1);//reader[1].ToString();
                    result.Password = reader.IsDBNull(2) ? null : reader[2].ToString();
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
