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
    class ClassesDAL
    {
        public ObservableCollection<Class> GetAllClasses()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllClasses", con);
                ObservableCollection<Class> result = new ObservableCollection<Class>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Class c = new Class();
                    c.ID = (int)(reader[0]);//reader.GetInt(0);
                    c.Denumire = reader.GetString(1);//reader[1].ToString();
                    c.Diriginte = reader[2].ToString();
                    result.Add(c);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public Class GetClass(Elev elev)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetClass", con);
                Class result = new Class();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdElev = new SqlParameter("@ID", elev.ID);
                cmd.Parameters.Add(paramIdElev);


                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.ID = (int)reader[0];
                    result.Denumire = reader.GetString(1);

                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public Class GetClassByName(string denumire)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetClassByName", con);
                Class result = new Class();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdClasa = new SqlParameter("@Denumire", denumire);
                cmd.Parameters.Add(paramIdClasa);


                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.ID = (int)reader[0];
                    result.Denumire = reader.GetString(1);

                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public ObservableCollection<Class> GetClassForProfesor(Profesor profesor)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetClassesForProfesor", con);
                ObservableCollection<Class> result = new ObservableCollection<Class>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdProfesor = new SqlParameter("@ID_profesor", profesor.ID);

                cmd.Parameters.Add(paramIdProfesor);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Class c = new Class();

                    c.ID = (int)reader[0];
                    c.Denumire = reader.GetString(1);
                    result.Add(c);

                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public Class GetClassForDiriginte(Profesor profesor)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetClassForDiriginte", con);
                Class result = new Class();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdProfesor = new SqlParameter("@ID_profesor", profesor.ID);
                cmd.Parameters.Add(paramIdProfesor);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {


                    result.ID = (int)reader[0];
                    result.Denumire = reader.GetString(1);


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
