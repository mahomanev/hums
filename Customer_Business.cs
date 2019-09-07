using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p.data;
using System.Data.Entity;
using KFP.DATA;

namespace KFP.BUSINESS
{
  public  class Customer_Business
    {


        private KFG_Db db = new KFG_Db();

        public List<Customer> all()
        {
            return db.Customers.ToList();
        }
        public bool add(Customer model)
        {
            try
            {
                db.Customers.Add(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public bool edit(Customer model)
        {
            try
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public Customer find_by_id(int? id)
        {
            return db.Customers.Find(id);
        }

        public string getGender(string id_num)
        {
            if (Convert.ToInt16(id_num.Substring(7, 1)) >= 5)
                return "Male";
            else
                return "Female";
        }
    }
}
