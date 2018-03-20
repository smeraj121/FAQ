using FAQ.Models;
using FAQ.Repository;
using System;

namespace FAQ.Services
{
    public class FAQCRUDServices
    {
        FAQCRUDRepository crudRepository = new FAQCRUDRepository();

        internal FAQuestions GetQuestion(int id)
        {
            FAQuestions question = new FAQuestions();
            try
            {
                question = crudRepository.GetQuestion(id);
            }
            catch { }
            return question;
        }

        internal bool EditQuestion(FAQuestions question)
        {
            bool result = false;
            try
            {
                crudRepository.EditQuestion(question);
                result = true;
            }
            catch { }
            return result;
        }

        internal int AddFAQ(FAQuestions question)
        {
            try
            {
                int Questionid = crudRepository.AddQuestion(question);
                return Questionid;
            }
            catch { return 0; }
        }

        internal bool DeleteQuestion(int questionID)
        {
            bool result = false;
            try
            {
                crudRepository.DeleteQuestion(questionID);
                result = true;
            }
            catch(Exception ex)
            { }
            return result;
        }

        internal void HideQuestion(int id,int val)
        {
            try
            {
                crudRepository.HideQuestion(id,val);
            }
            catch { }
        }
    }
}