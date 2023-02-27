using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_II
{
    public class DniException:ApplicationException
    {
        public DniException() : base("El dni debe tener 7 u 8 dígitos") { }
        public DniException(string msj) : base(msj) { }
        public DniException(string msj, Exception inner) : base(msj, inner) { }
    }
}
