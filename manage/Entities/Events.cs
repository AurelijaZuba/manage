using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace manage.Entities
{
    public class Events
    {
        [Key]
        public int EventID { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string EventName { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string Venue { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string Address { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.TimeSpan> Time { get; set; }
    }
}