using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace ForumDEG.Models
{
    public class Forum
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Room { get; set; }

        public string Building { get; set; }

        public string ForumTheme { get; set; }

        [ForeignKey(typeof(Form))]
        public int FormId { get; set; }

        [OneToOne]
        public Form Form { get; set; }
    }
}
