using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspMvcCoreFull.App.Extensions
{
    public static class RazorExtension
    {
        public static string FormataDocumento(this RazorPage page,string documento, int tipoDocumento)
        {
            return (tipoDocumento == 1) ? Convert.ToUInt64(documento).ToString(@"000\.000\.000\-00") : Convert.ToUInt64(documento).ToString(@"00\.000\.000\/0000\-00");
        }
    }
}
