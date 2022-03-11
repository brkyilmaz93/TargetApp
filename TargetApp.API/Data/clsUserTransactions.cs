using System;
using System.Linq;
using TargetApp.Entities.Concreate;
using TargetApp.Entities.General;

namespace TargetApp.API.Data
{
    public class clsUserTransactions:EFEntityRepository<User, TargetAppContext>
    {
        public Messages<User> CheckUser(string userName, string password)
        {
            Messages<User> m = new Messages<User>();

            try
            {
                using (TargetAppContext cnt = new TargetAppContext())
                {
                    var ns = cnt.Set<User>();

                    m.Record = ns.SingleOrDefault(x => x.IsDelete == true && (x.UserName == userName || x.UserName == userName) && x.Password == password);
                    if (m.Record !=null)
                    {
                        m.Status = true;
                        m.Message = "User found.";
                    }
                    else
                    {
                        m.Status = false;
                        m.Message = "User not found.";
                    }
                }
           
            }
            catch (Exception ex)
            {
                m.Status = false;
                m.Message = ex.Message;
            }

            return m;
        }
    }
}
