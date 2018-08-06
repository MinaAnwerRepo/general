using DomainModel.DataBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class InOutRep
    {
        private AttaindanceEntities context;


        public bool IsLogin { get; } 



        public InOutRep()
        {
            context = new AttaindanceEntities();
            IsLogin = CheckIsLogin();
        }

        public void LogIn(DateTime loginTime)
        {
            InOut Record = context.InOuts.FirstOrDefault(x => x.Date == loginTime.Date);
          if (Record != null)
          {
                Record.InTime = loginTime;              
                context.SaveChanges();
          }
          else
          {
                var inout = new InOut() { Date = DateTime.Now.Date , InTime = loginTime  };
                context.InOuts.Add(inout);
                context.SaveChanges();
          }
        }


        public void Logout(DateTime logoutTime)
        {
            InOut Record = context.InOuts.FirstOrDefault(x => x.Date == logoutTime.Date);
            if (Record != null)
            {
                Record.outTime = logoutTime;
                context.SaveChanges();
            }
            else
            {
                var inout = new InOut() { Date = DateTime.Now.Date, outTime = logoutTime };
                context.InOuts.Add(inout);
                context.SaveChanges();
            }
        }

        public DateTime? GetLoginTime()
        {
            DateTime today = DateTime.Now;
            InOut Record  = context.InOuts.FirstOrDefault(x => x.Date == today.Date);
            if (Record != null) return Record.InTime;
            else return null;
        }

        public bool  CheckIsLogin()
        {
            var today = DateTime.Now.Date;
            var item = context.InOuts.FirstOrDefault(x => x.Date == today);
            if (item != null && item.InTime.HasValue && item.InTime.Value.Date != null)
                return true;
            else
                return false;
        }

    }
}
