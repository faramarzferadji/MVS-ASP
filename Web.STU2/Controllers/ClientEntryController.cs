using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Web.STU2.Models;
using System.Configuration;

namespace Web.STU2.Controllers
{
    public class ClientEntryController : Controller
    {
        string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBSTU2;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public ActionResult Index()
        {
            return View();

        }
        // GET: ClientEntry
        [HttpPost]
        public ActionResult Index(Client cl)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select UserName, Password From AdminTable where UserName = @UserName and Password = @Passwords";
                SqlCommand cmd = new SqlCommand(query, con);
              
                cmd.Parameters.AddWithValue("@UserName", cl.UserName);
                cmd.Parameters.AddWithValue("@Passwords", cl.Passwords);
                SqlDataReader sr = cmd.ExecuteReader();
                if(sr.Read())
                {
                    Session["Password"] = cl.Passwords.ToString();
                    Session["UserName"] = cl.UserName.ToString();
                    return RedirectToAction("Wellcome");
                }
                else
                {
                    ViewData["Massege"] ="Enter the correct data";
                }
                con.Close();
            }
                return View();
        }
        public ActionResult Wellcome()
        {
            return View();
        }
    }
}