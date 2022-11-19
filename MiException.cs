using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_II
{
    internal class MiException:ApplicationException
    {
       public MiException():base("Error base"){}
       public MiException(string msj) : base(msj) { }
       public MiException(string msj,Exception inner) : base(msj,inner) { }
    }
}
