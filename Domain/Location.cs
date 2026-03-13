using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; } 
        public Location Parent { get; set; }
        public LocationType LocationType { get; set; }
    }
}
