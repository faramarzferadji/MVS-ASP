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
    public class AdminController : Controller
    {
        string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBSTU2;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // GET: Admin
        public ActionResult Index()
        {
            DataTable AdminTable1 = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
               
                con.Open();
                string query = "Select * from AdminTable";
                SqlDataAdapter sqlData = new SqlDataAdapter(query, con);
                sqlData.Fill(AdminTable1);
            }
                return View(AdminTable1);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(AdminModel ad)
        {
            using(SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "insert into AdminTable values(@UserName,@Password)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserName", ad.UaerName);
                cmd.Parameters.AddWithValue("@Password", ad.Password);
               
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
