using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class UserInfo
    {
        public static string GetSex(bool isMale)
        {
            if (isMale)
            {
                return "Male";
            }
            else
            {
                return "Female";
            }
        }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Sex { get; set; }
        public string Skype { get; set; }
        public string Icq { get; set; }
        public string Phone { get; set; }
    }
}