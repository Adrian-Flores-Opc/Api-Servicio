using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Api.Servicio.Comunes
{
    public static class GerenteLog
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetObtenerMetodo()
        {
            var st = new StackTrace(new StackFrame(1));
            return st.GetFrame(0).GetMethod().Name;
        }
    }
}
