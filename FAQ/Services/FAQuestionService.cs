using System;
using System.Collections.Generic;
using FAQ.Models;
using FAQ.Repository;

namespace FAQ.Services
{
    public class FAQuestionService
    {
        FAQuestionRepository questionRepository = new FAQuestionRepository();
        internal List<FAQuestions> GetFAQListOnCategory(int id)
        {
            List<FAQuestions> questions = new List<FAQuestions>();
            try
            {
                questions=questionRepository.GetFAQListOnCategory(id);
            }
            catch(Exception ex) { }
            return questions;
        }

        internal bool ShiftUP(int id,int categoryid)
        {
            bool result = false;
            try
            {
                questionRepository.ShiftUp(id, categoryid);
                result = true;
            }
            catch { }
            return result;
        }

        internal bool ShiftDown(int id,int categoryid)
        {
            bool result = false;
            try {
                questionRepository.ShiftDown(id, categoryid);
                result = true;
            }
            catch{
            }
            return result;
        }

    }
}