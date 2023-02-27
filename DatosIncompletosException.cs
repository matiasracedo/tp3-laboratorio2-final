using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_II
{
    public class DatosIncompletosException:ApplicationException
    {
        public DatosIncompletosException() : base("Falta completar campos") { }
        public DatosIncompletosException(string msj) : base(msj) { }
        public DatosIncompletosException(string msj, Exception inner) : base(msj, inner) { }
    }
}
