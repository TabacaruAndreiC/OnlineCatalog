using Platforma_Educationala.Models.DataAccescLayer;
using Platforma_Educationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Platforma_Educationala.Models.DataAccesLayer
{
    class ElevDAL
    {
        public Elev GetStudentByUsername(string username)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetStudentByUsername", con);
                Elev result = new Elev();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDUser = new SqlParameter("@Username", username);
                cmd.Parameters.Add(paramIDUser);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
              
                if(reader.Read())
                {
                    
                    result.ID = (int)reader[0];
                    result.Nume = reader.GetString(1);//reader[1].ToString();
                    
                    
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public ObservableCollection<Elev> GetStudentFromClass(Class cls)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetStudentFromClass", con);
                ObservableCollection<Elev> result = new ObservableCollection<Elev>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDUser = new SqlParameter("@ClasaID", cls.ID);
                cmd.Parameters.Add(paramIDUser);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    Elev e = new Elev();
                    e.ID = (int)reader[0];
                    e.Nume = reader.GetString(1);//reader[1].ToString();
                    
                    result.Add(e);

                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }

        }
        public Elev GetStudentByName(string name)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetStudentByName", con);
                Elev result = new Elev();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIDUser = new SqlParameter("@Name", name);
                cmd.Parameters.Add(paramIDUser);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    result.ID = (int)reader[0];
                    result.Nume = reader.GetString(1);//reader[1].ToString();
                    

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
