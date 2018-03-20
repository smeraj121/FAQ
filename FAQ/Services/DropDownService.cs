using FAQ.Models;
using FAQ.Repository;
using System.Collections.Generic;

namespace FAQ.Services
{
    public class DropDownService
    {
        DropDownRepository dropDown = new DropDownRepository();
        public List<DropDownItems> GetItem()
        {
            List<DropDownItems> listItems = new List<DropDownItems>();
            try
            {
                listItems= dropDown.GetItems();
            }
            catch { }
            return listItems;
        }
    }
}