using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace manage.Models
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
        public DateTime? Date { get; set; }
        public TimeSpan? Time { get; set; }
    }
}