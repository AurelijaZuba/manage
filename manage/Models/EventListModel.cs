using manage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace manage.Models
{
    public class EventListModel
    {
        public IEnumerable<Events> Events { get; set; }
    }
}