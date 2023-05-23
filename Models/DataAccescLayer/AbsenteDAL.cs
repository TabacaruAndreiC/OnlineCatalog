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
    class AbsenteDAL
    {

        public ObservableCollection<Absente> GetAbs(Elev elev, Materie materie)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAbs", con);
                ObservableCollection<Absente> result = new ObservableCollection<Absente>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdElev = new SqlParameter("@ID", elev.ID);
                SqlParameter paramIdMaterie = new SqlParameter("@Denumire", materie.Denumire);

                cmd.Parameters.Add(paramIdElev);
                cmd.Parameters.Add(paramIdMaterie);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Absente p = new Absente();

                    p.Abs_Crt = (int)reader[0];
                    p.Tip = reader.GetString(1);
                    p.Data = reader.GetDateTime(2);

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

        public void AddAbsente(Absente abs, Elev elev, Materie materie)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddAbsenta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramAbs = new SqlParameter("@Tip", abs.Tip);
                SqlParameter paramData = new SqlParameter("@Data", abs.Data);

                SqlParameter paramMaterie = new SqlParameter("@Materie", materie.MaterieId);
                SqlParameter paramElev = new SqlParameter("@Elev", elev.ID);



                cmd.Parameters.Add(paramAbs);
                cmd.Parameters.Add(paramData);

                cmd.Parameters.Add(paramElev);
                cmd.Parameters.Add(paramMaterie);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteAbs(Absente abs)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteAbs", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdAbs = new SqlParameter("@AbsId", abs.Abs_Crt);
                cmd.Parameters.Add(paramIdAbs);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public int GetAbsNumber(Elev elev)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAbsNumber", con);
                int result = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdElev = new SqlParameter("@ID", elev.ID);
                SqlParameter paramAbsCount = new SqlParameter("@AbsCount", SqlDbType.Int);
                paramAbsCount.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(paramIdElev);
                cmd.Parameters.Add(paramAbsCount);

                con.Open();
                cmd.ExecuteNonQuery();

                result = (int)paramAbsCount.Value;
                return result;
            }
            finally
            {
                con.Close();
            }
        }

    }
}
