using FAQ.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace FAQ.Repository
{
    public class FAQCRUDRepository
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["FAQcon"].ToString();
            con = new SqlConnection(constring);
        }

        #region AddQuestion
        internal int AddQuestion(FAQuestions question)
        {
            connection();
            var QuestionId = 0;
            SqlCommand cmd = new SqlCommand("AddQuestion", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@QuestionId", ParameterDirection.Output);
            cmd.Parameters.AddWithValue("@QuestionName", question.@QuestionName);
            cmd.Parameters.AddWithValue("@Answer", question.@Answer);
            cmd.Parameters.AddWithValue("@CategoryID", question.@CategoryID);
            cmd.Parameters.AddWithValue("@Tags", question.Tags);
            con.Open();
            QuestionId = (int)cmd.ExecuteScalar();
            con.Close();
            return QuestionId;
        }
        #endregion

        #region DeleteQuestion
        internal bool DeleteQuestion(int questionID)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteQuestion", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@QuestionID", questionID);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result > -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal void HideQuestion(int id,int val)
        {
            connection();
            SqlCommand cmd = new SqlCommand("HideQuestion", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@QuestionID", id);
            cmd.Parameters.AddWithValue("@value", val);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion


        internal void EditQuestion(FAQuestions question)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateQuestion", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@QuestionID", question.QuestionID);
            cmd.Parameters.AddWithValue("@QuestionName", question.@QuestionName);
            cmd.Parameters.AddWithValue("@Answer", question.@Answer);
            cmd.Parameters.AddWithValue("@CategoryID", question.@CategoryID);
            cmd.Parameters.AddWithValue("@Tags", question.Tags);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        internal FAQuestions GetQuestion(int id)
        {
            connection();
            FAQuestions question = new FAQuestions();

            SqlCommand cmd = new SqlCommand("GetQuestionDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                question.QuestionID = Convert.ToInt32(dr["QuestionID"]);
                question.QuestionName = Convert.ToString(dr["QuestionName"]);
                question.Answer = Convert.ToString(dr["Answer"]);
                question.Tags = Convert.ToString(dr["Tags"]);
                question.Hide = Convert.ToBoolean(dr["Hide"]);
                question.CategoryID = Convert.ToInt32(dr["CategoryId"]);
                question.CategoryName = Convert.ToString(dr["CategoryName"]);
                question.SiteCode = Convert.ToInt32(dr["SiteCode"]);
            }

            return question;

        }
    }
}