using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_Client.Areas.Admin.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Information { get; set; }
        public int Status { get; set; }
        public string CategoryId { get; set; }
    }
}