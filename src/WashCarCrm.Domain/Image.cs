using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WashCarCrm.Domain
{
    public class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string ContentType { get; set; }

        // ef relations
        public Washer Washer { get; set; }
        public WashCompany WashCompany { get; set; }
    }
}