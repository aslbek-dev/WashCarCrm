using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WashCarCrm.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}