using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.BL.Models
{
    public class UserInRoleVM
    {
        public string UserId { get; set; }
        public string EmailUser { get; set; }
        public bool IsSelected { get; set; }
    }
}
