using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.locations.Dto
{
    public class CreateLocationDto
    {
        public string Name { get; set; }
        public int ParentId { get; set; }
        public LocationType LocationType { get; set; }
    }
}
