using System;
using System.Collections.Generic;
using FAQ.Models;
using System.Data.SqlClient;
using System.Data;

namespace FAQ.Repository
{
    public class CategoryRepository
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["FAQcon"].ToString();
            con = new SqlConnection(constring);
        }
        public List<Categories> GetCategories(int id)
        {
            connection();
            List<Categories> options = new List<Categories>();

            SqlCommand cmd = new SqlCommand("GetCategoryBySiteCode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                options.Add(
                    new Categories
                    {
                        CategoryID = Convert.ToInt32(dr["CategoryId"]),
                        CategoryName = Convert.ToString(dr["CategoryName"]),
                        SiteCode = Convert.ToInt32(dr["SiteCode"])
                    });
            }
            return options;
        }
        public Categories GetCategory(int id)
        {
            connection();
            Categories category = new Categories();

            SqlCommand cmd = new SqlCommand("GetCategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                category.CategoryID = Convert.ToInt32(dr["CategoryId"]);
                category.CategoryName = Convert.ToString(dr["CategoryName"]);
                category.SiteCode = Convert.ToInt32(dr["SiteCode"]);
            }
           
            return category;
        }
    }
}