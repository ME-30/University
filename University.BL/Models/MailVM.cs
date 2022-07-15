using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.BL.Models
{
    public class MailVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = " Require")]
        public string Customer  { get; set; }

        [Required(ErrorMessage = "Title Require")]
        public string Title  { get; set; }

        [Required(ErrorMessage = "Message Require")]
        public string Message  { get; set; }
        public IFormFile Attach  { get; set; }
    }
}
