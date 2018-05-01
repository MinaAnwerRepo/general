using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonHelper
{
    internal  class ExceptionWrapper
    {
        public T Execute<T>(Func<T> func ,ref Exception exception ,ref Logger log)
        {
            try
            {
                return func();
            }

            catch (Exception ex)
            {
                exception = ex;
                return default(T);
            }
        }

    }
}
