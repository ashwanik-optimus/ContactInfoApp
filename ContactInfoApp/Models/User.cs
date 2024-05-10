using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactInfoApp.Models
{
    [Table("users")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string MobileNumber { get; set; }

        public string ProfilePicture { get; set; }
    }
}
