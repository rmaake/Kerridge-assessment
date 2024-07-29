using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerridgeAsessment.Models
{
    public class ServerResponse<T>
    {
        public T Data { get; set; }
        public GetMeta Meta { get; set; }
    }
}
