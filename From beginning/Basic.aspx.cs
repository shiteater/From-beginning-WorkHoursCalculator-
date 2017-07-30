using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace From_beginning
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnSaveChanges_Click(object sender, EventArgs e)
        {
            //promijenite con

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K1I0JMC\SQLEXPRESS;Initial Catalog=WorkHours;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@V1", Convert.ToDateTime(Calendar1.SelectedDate));
            //trenutno ovo '1' je id korisnika koji trebamo povezati sa loginom
            cmd.CommandText = $"insert into dbo.Kalkulacije values( '1' , @V1, Null, Null,'{TbxWorkedHouresOnThisDay.Text}', '{TbxHourPrice.Text}')";
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Fak yea it is saved :D');</script>");
            con.Close();
        }
        //upisivanje nema problema

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K1I0JMC\SQLEXPRESS;Initial Catalog=WorkHours;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string datum = Calendar1.SelectedDate.ToShortDateString();

            // try cach
            string converted = DateTime.ParseExact(datum, "dd.M.yyyy.", CultureInfo.InvariantCulture)
                              .ToString("yyyy-MM-dd");


            cmd.Parameters.AddWithValue("@V1", converted);
            cmd.CommandText = "select * from Kalkulacije where Datum LIKE @V1";
            
            using (SqlDataReader read = cmd.ExecuteReader())
            {
                while (read.Read())
                {
                    TbxTotalHours.Text = (read["Ukupno_odradeno_sati"].ToString());

                }
            }
            con.Close();
           // Response.Write("<script>alert('Uspješno ste dodali seminar');</script>");

            //    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K1I0JMC\SQLEXPRESS;Initial Catalog=WorkHours;Integrated Security=True;Pooling=False");

            //    // vađenje podataka iz sql i upisivanje u textboxeve
            //    string datum = Calendar1.SelectedDate.ToShortDateString();


            //    string converted = DateTime.ParseExact(datum, "dd.MM.yyyy.", CultureInfo.InvariantCulture)
            //                      .ToString("yyyyMMdd");
            //    //DateTime datum = Calendar1.SelectedDate;
            //    //  string date = datum.ToString();
            //    string selectSql = "select * from Kalkulacije where Datum LIKE '22.7.2017.'";

            //    SqlCommand cmd = new SqlCommand(selectSql, con);

            //    //cmd.Parameters.AddWithValue("@datum", TbxTotalHours.Text);

            //    try
            //    {
            //        con.Open();

            //        using (SqlDataReader read = cmd.ExecuteReader())
            //        {
            //            while (read.Read())
            //            {
            //                TbxTotalHours.Text = (read["Ukupno_odradeno_sati"].ToString());

            //            }
            //        }
            //    }
            //    finally
            //    {
            //        con.Close();
            //    }
        }

    }
}