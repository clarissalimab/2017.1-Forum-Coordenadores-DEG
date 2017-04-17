using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumDEG.Models
{
    public class Form
    {
        [PrimaryKey]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        [OneToMany]
        public List<FormAsks> FormAsks { get; set; }
    }
}
