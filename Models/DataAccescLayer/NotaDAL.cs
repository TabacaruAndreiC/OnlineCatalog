using Platforma_Educationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Platforma_Educationala.Models.DataAccescLayer;

namespace Platforma_Educationala.Models.DataAccesLayer
{
    class NotaDAL
    {
        public ObservableCollection<Note> GetGrades(Elev elev,string materie)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetGrade", con);
                ObservableCollection<Note> result = new ObservableCollection<Note>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdElev = new SqlParameter("@ID", elev.ID);
                SqlParameter paramIdMaterie = new SqlParameter("@Denumire", materie);

                cmd.Parameters.Add(paramIdElev);
                cmd.Parameters.Add(paramIdMaterie);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Note p=new Note();
                    p.Nota_Crt = (int)(reader[0]);
                    p.Nota = (int)(reader[1]);
                    p.Data = reader.GetDateTime(2);
                    p.Teza = reader.GetString(3);

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

        public void ModifyGrade(Note nota)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyGrade", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdNota = new SqlParameter("@NotaID", nota.Nota_Crt);
                SqlParameter paramNume = new SqlParameter("@Nota", nota.Nota);
               
                cmd.Parameters.Add(paramIdNota);
                cmd.Parameters.Add(paramNume);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddNota(Note nota,Elev elev,Materie materie)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddGrades", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramNota= new SqlParameter("@Nota", nota.Nota);
                SqlParameter paramData = new SqlParameter("@Data", nota.Data);
                SqlParameter paramTeza;
                SqlParameter paramMaterie = new SqlParameter("@Materie", materie.MaterieId);
                SqlParameter paramElev = new SqlParameter("@Elev", elev.ID);

                if (String.IsNullOrEmpty(nota.Teza))
                {
                    paramTeza = new SqlParameter("@teza", "nu");
                }
                else
                {
                    paramTeza = new SqlParameter("@teza",nota.Teza);
                }

                cmd.Parameters.Add(paramNota);
                cmd.Parameters.Add(paramData);
                cmd.Parameters.Add(paramTeza);
                cmd.Parameters.Add(paramElev);
                cmd.Parameters.Add(paramMaterie);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteNota(Note nota)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteGrade", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdNota = new SqlParameter("@NotaId", nota.Nota_Crt);
                cmd.Parameters.Add(paramIdNota);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


    }
}
