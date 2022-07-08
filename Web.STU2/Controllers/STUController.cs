using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using System.Data.SqlClient;
using Web.STU2.Models;

namespace Web.STU2.Controllers
{
    public class STUController : Controller
    {
        string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBSTU2;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        // GET: STU
        [HttpGet]
        public ActionResult Index()
        {
            DataTable STU2Table = new DataTable();
            using(SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * From STU2Table";
                SqlDataAdapter sqlData = new SqlDataAdapter(query, con);
                sqlData.Fill(STU2Table);
            }
            return View(STU2Table);
        }
        [HttpGet]
        public ActionResult Searching(string stsearch)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from STU2Table where Name like '%" + stsearch + "%'";
                //string query = "Select Max(StusentId)/*,Name,DOB */from STU2Table group by StusentId";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                sqlData.Fill(dataSet);
                List<StuModel> sm = new List<StuModel>();
                foreach (DataRow item in dataSet.Tables[0].Rows)
                {
                    sm.Add(new StuModel
                    {
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

        // GET: STU/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: STU/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: STU/Create
        [HttpPost]
        public ActionResult Create(StuModel stu)
        {
            using(SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Insert into STU2Table Values(@StudentId,@StudentId,@Name,@DOB)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StudentId", stu.StudentId);
                cmd.Parameters.AddWithValue("@Name", stu.Name);
                cmd.Parameters.AddWithValue("@DOB", stu.DOB);
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: STU/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            StuModel stu = new StuModel();
            DataTable STU2Table = new DataTable();
            using(SqlConnection con =new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * From STU2Table Where StusentId=@StudentId";
                SqlDataAdapter sqlData = new SqlDataAdapter(query, con);
                sqlData.SelectCommand.Parameters.AddWithValue("@StudentId", id);
                sqlData.Fill(STU2Table);
                if (STU2Table.Rows.Count == 1)
                {
                    stu.StudentId = Convert.ToInt32(STU2Table.Rows[0][1].ToString());
                    stu.Name = STU2Table.Rows[0][2].ToString();
                    stu.DOB = Convert.ToDateTime(STU2Table.Rows[0][3].ToString());
                    return View(stu);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            
        }

        // POST: STU/Edit/5
        [HttpPost]
        public ActionResult Edit(StuModel stu)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "UpDate STU2Table set  StusentId=@StudentId,Name=@Name,DOB=@DOB where StusentId=@StudentId ";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StudentId", stu.StudentId);
                cmd.Parameters.AddWithValue("@Name", stu.Name);
                cmd.Parameters.AddWithValue("@DOB", stu.DOB);
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }


        // GET: STU/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {

                sqlcon.Open();
                string quary = "Delete From STU2Table where /*Stusent*/Id=@StudentId  ";
                SqlCommand cmd = new SqlCommand(quary, sqlcon);
                cmd.Parameters.AddWithValue("@StudentId", id);

                cmd.ExecuteNonQuery();


            }
            return RedirectToAction("Index");
        }

        // POST: STU/Delete/5
        
        
    }
}
