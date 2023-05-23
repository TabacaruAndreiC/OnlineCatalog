using Platforma_Educationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Platforma_Educationala.Models.DataAccescLayer;

namespace Platforma_Educationala.Models.DataAccesLayer
{
    class MaterieDAL
    {
        public ObservableCollection<Materie> GetSubjectsForStudent(Elev elev)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetSubjectsForStudent", con);
                ObservableCollection<Materie> result = new ObservableCollection<Materie>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdElev = new SqlParameter("@ID", elev.ID);
                cmd.Parameters.Add(paramIdElev);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Materie p=new Materie();
                    p.MaterieId = (int)(reader[0]);//reader.GetInt(0);
                    p.Denumire= reader.GetString(1);//reader[1].ToString();
                    
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
        public ObservableCollection<Materie> GetSubjectsWithTeza(Elev elev)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetSubjectsWithTeza", con);
                ObservableCollection<Materie> result = new ObservableCollection<Materie>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdElev = new SqlParameter("@ID", elev.ID);
                cmd.Parameters.Add(paramIdElev);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Materie p = new Materie();

                    p.MaterieId = (int)(reader[0]);//reader.GetInt(0);
                    p.Denumire = reader.GetString(1);//reader[1].ToString();

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
        public ObservableCollection<Materie> GetSubjectForClass(Class cls,Profesor p)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetSubjectsForClass", con);
                ObservableCollection<Materie> result = new ObservableCollection<Materie>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdProfesor = new SqlParameter("@ID", p.ID);
                SqlParameter paramIdClasa = new SqlParameter("@ClasaID", cls.ID);


                cmd.Parameters.Add(paramIdProfesor);
                cmd.Parameters.Add(paramIdClasa);
                
                
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Materie p1 = new Materie
                    {
                        MaterieId = (int)(reader[0]),//reader.GetInt(0);
                        Denumire = reader.GetString(1)//reader[1].ToString();
                    };

                    result.Add(p1);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public ObservableCollection<Materie> GetAllSubjectsForClass(Class cls)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllSubjectsForClass", con);
                ObservableCollection<Materie> result = new ObservableCollection<Materie>();
                cmd.CommandType = CommandType.StoredProcedure;
            
                SqlParameter paramIdClasa = new SqlParameter("@clasaId", cls.ID);

                cmd.Parameters.Add(paramIdClasa);


                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Materie p1 = new Materie
                    {
                        MaterieId = (int)(reader[0]),//reader.GetInt(0);
                        Denumire = reader.GetString(1)//reader[1].ToString();
                    };

                    result.Add(p1);
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
