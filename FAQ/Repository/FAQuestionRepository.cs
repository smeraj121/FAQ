using System;
using System.Collections.Generic;
using FAQ.Models;
using System.Data.SqlClient;
using System.Data;

namespace FAQ.Repository
{
    public class FAQuestionRepository
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["FAQcon"].ToString();
            con = new SqlConnection(constring);
        }
        internal List<FAQuestions> GetFAQListOnCategory(int id)
        {
            connection();
            List<FAQuestions> questions = new List<FAQuestions>();

            SqlCommand cmd = new SqlCommand("GetData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                questions.Add(
                    new FAQuestions
                    {
                        QuestionID = Convert.ToInt32(dr["QuestionID"]),
                        QuestionName = Convert.ToString(dr["QuestionName"]),
                        Answer = Convert.ToString(dr["Answer"]),
                        Tags = Convert.ToString(dr["Tags"]),
                        Hide = Convert.ToBoolean(dr["Hide"]),
                        CategoryID = Convert.ToInt32(dr["CategoryId"]),
                        CategoryName = Convert.ToString(dr["CategoryName"]),
                        SiteCode = Convert.ToInt32(dr["SiteCode"])
                    });
            }
            return questions;
        }

        internal void ShiftDown(int id,int categoryid)
        {
            connection();
            SqlCommand cmd = new SqlCommand("shiftdown", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@categoryid", categoryid);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        internal void ShiftUp(int id,int categoryid)
        {
            connection();
            SqlCommand cmd = new SqlCommand("shiftup", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@categoryid", categoryid);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}