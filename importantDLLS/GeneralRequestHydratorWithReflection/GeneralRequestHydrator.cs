using MessageParsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Hydrators
{
 public   class GeneralRequestHydrator : IEntityHydrator<object>
    {
         public string Root { get; set; }
         public object Obj;
         public GeneralRequestHydrator( string root, object obj)
        {
            this.Root = root;
            this.Obj = obj;
        }
        public object HydrateObject( Dictionary<string, string> kvp)
        {
            Type T = Obj.GetType();
            PropertyInfo [] mainprop  = T.GetProperties();
            object header = mainprop[0].GetValue(Obj);
            object body = mainprop[1].GetValue(Obj);
            Type Theader = header.GetType();
            Type Tbody = body.GetType();
            PropertyInfo[] headerpropes = Theader.GetProperties();
            PropertyInfo[] bodypropes = Tbody.GetProperties();
            foreach (var item in headerpropes)
            {
                item.SetValue(header, kvp[item.Name], null);
            }
            foreach (var item in bodypropes)
            {
                item.SetValue(body, kvp[item.Name], null);
            }
            return Obj;
        }

  
    }

}
