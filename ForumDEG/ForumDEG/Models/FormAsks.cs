using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumDEG.Models
{
    public class FormAsks
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey (typeof(Form))]
        public int FormId { get; set; }
    }
}
