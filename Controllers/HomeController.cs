using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scarpe.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ScarpeDB"].ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from ScarpeTab where Visibile=1";
            cmd.Connection = con;
            SqlDataReader r = cmd.ExecuteReader();
            List<Scarpa> ListaScarpe = new List<Scarpa>();
            if (r.HasRows)
            {
                while (r.Read())
                {
                    Scarpa s = new Scarpa();
                    s.Id = Convert.ToInt32(r["IdScarpa"]);
                    s.Nome = r["Nome"].ToString();
                    s.Prezzo = Convert.ToDecimal(r["Prezzo"]);
                    s.Descrizione = r["Descrizione"].ToString();
                    s.Copertina = r["ImgCopertina"].ToString();
                    s.Dettaglio1 = r["ImgDettaglio1"].ToString();
                    s.Dettaglio2 = r["ImgDettaglio2"].ToString();
                    ListaScarpe.Add(s);
                }
            }
            con.Close();
            return View(ListaScarpe);
        }
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult About(int id)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ScarpeDB"].ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from ScarpeTab where IdScarpa = @id";
            cmd.Parameters.AddWithValue("id", id);
            cmd.Connection = con;
            SqlDataReader r = cmd.ExecuteReader();
            Scarpa s = new Scarpa();
            if (r.HasRows)
            {
                while (r.Read())
                {
                    s.Id = Convert.ToInt32(r["IdScarpa"]);
                    s.Nome = r["Nome"].ToString();
                    s.Prezzo = Convert.ToDecimal(r["Prezzo"]);
                    s.Descrizione = r["Descrizione"].ToString();
                    s.Copertina = r["ImgCopertina"].ToString();
                    s.Dettaglio1 = r["ImgDettaglio1"].ToString();
                    s.Dettaglio2 = r["ImgDettaglio2"].ToString();
                }
            }
            con.Close();
            return View(s);
        }
        public ActionResult Nascondi(int id)
        {
            string visibile = "";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ScarpeDB"].ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from ScarpeTab where IdScarpa = @id";
            cmd.Parameters.AddWithValue("id", id);
            cmd.Connection = con;
            SqlDataReader r = cmd.ExecuteReader();
            Scarpa s = new Scarpa();
            while(r.Read())
            {
                s.Visibile = Convert.ToBoolean(r["Visibile"]);
            }
            r.Close();
            SqlCommand cmd2 = new SqlCommand();
            if(s.Visibile == true)
            {
                visibile = "0";
            }
            else
            {
                visibile= "1";
            }
            cmd2.CommandText = "update ScarpeTab set Visibile = @Vis where IdScarpa = @id";
            cmd2.Parameters.AddWithValue("id", id);
            cmd2.Parameters.AddWithValue("Vis", visibile);
            cmd2.Connection= con;
            cmd2.ExecuteNonQuery();

            con.Close();
            return RedirectToAction("Index");
        }
        public ActionResult ArticoliNascosti() 
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ScarpeDB"].ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from ScarpeTab where Visibile=0";
            cmd.Connection = con;
            SqlDataReader r = cmd.ExecuteReader();
            List<Scarpa> ListaScarpe = new List<Scarpa>();
            if (r.HasRows)
            {
                while (r.Read())
                {
                    Scarpa s = new Scarpa();
                    s.Id = Convert.ToInt32(r["IdScarpa"]);
                    s.Nome = r["Nome"].ToString();
                    s.Prezzo = Convert.ToDecimal(r["Prezzo"]);
                    s.Descrizione = r["Descrizione"].ToString();
                    s.Copertina = r["ImgCopertina"].ToString();
                    s.Dettaglio1 = r["ImgDettaglio1"].ToString();
                    s.Dettaglio2 = r["ImgDettaglio2"].ToString();
                    ListaScarpe.Add(s);
                }
            }
            con.Close();
            return View(ListaScarpe); 
        }


        
    }
}