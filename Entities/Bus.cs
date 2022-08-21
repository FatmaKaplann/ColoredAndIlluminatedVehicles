using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Bus: Vehicle
    {
        //Otobüslerin tekerlekleri ve farları var
        public virtual ICollection<Wheel> Wheels { get; set; } = new List<Wheel>();
        public bool AreHeadlightsOn { get; set; }
    }
}
