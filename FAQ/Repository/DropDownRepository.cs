using System;
using System.Collections.Generic;
using FAQ.Models;
using System.Data.SqlClient;
using System.Data;

namespace FAQ.Repository
{
    public class DropDownRepository
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["FAQcon"].ToString();
            con = new SqlConnection(constring);
        }
        internal List<DropDownItems> GetItems()
        {
            connection();
            List<DropDownItems> listItems = new List<DropDownItems>();

            SqlCommand cmd = new SqlCommand("GetDropDown", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                listItems.Add(
                    new DropDownItems
                    {
                        ItemID = Convert.ToInt32(dr["Id"]),
                        SiteCode = Convert.ToInt32(dr["SiteCode"]),
                        Category = Convert.ToString(dr["Category"])
                    });
            }
            return listItems;

        }
    }
}