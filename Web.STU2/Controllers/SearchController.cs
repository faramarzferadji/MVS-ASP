using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Web.STU2.Models;

namespace Web.STU2.Controllers
{
    public class SearchController : Controller
    {
        string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBSTU2;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        // GET: Search
        public ActionResult Index(string stsearch)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from STU2Table where Name like '%" + stsearch + "%'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                sqlData.Fill(dataSet);
                List<SSModel> sm = new List<SSModel>();
                foreach (DataRow item in dataSet.Tables[0].Rows)
                {
                    sm.Add(new SSModel
                    {
                        Id=Convert.ToInt32(item["Id"]),
                        StudentId = Convert.ToInt32(item["StusentId"]),
                        Name = Convert.ToString(item["Name"]),
                        DOB = Convert.ToDateTime(item["DOB"])

                    });

                }
                con.Close();
                ModelState.Clear();
                return View(sm);

            }
        }
    }
}