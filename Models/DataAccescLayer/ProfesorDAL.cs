using Platforma_Educationala.Models.DataAccescLayer;
using Platforma_Educationala.Models.EntityLayer;
using System.Data;
using System.Data.SqlClient;

namespace Platforma_Educationala.Models.DataAccesLayer
{
    class ProfesorDAL
    {
        public EntityLayer.Profesor GetProfesorByUsername(string username)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetProfesorByUsername", con);
                EntityLayer.Profesor result = new EntityLayer.Profesor();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDUser = new SqlParameter("@Username", username);
                cmd.Parameters.Add(paramIDUser);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Profesor result1 = new Profesor();
                    result.ID = (int)reader[0];
                    result.Nume = reader.GetString(1);
                   
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public Profesor GetDiriginteByUsername(string username)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetDiriginteByUsername", con);
                EntityLayer.Profesor result = new EntityLayer.Profesor();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDUser = new SqlParameter("@Username", username);
                cmd.Parameters.Add(paramIDUser);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Profesor result1 = new Profesor();
                    result.ID = (int)reader[0];
                    result.Nume = reader.GetString(1);

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
