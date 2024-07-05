using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDevBP.Contract.APIConfiguration
{
  
    public class Http
    {
        public string? Port { get; set; }
    }

    public class Https
    {
        public string? Port { get; set; }
        public string? CertificatePath { get; set; }
        public string? CertificatePassword { get; set; }
    }

    public class APIConfiguration
    {
        public Http? Http { get; set; }
        public Https? Https { get; set; }
        public string[]? WhiteList { get; set; }
    }
}
