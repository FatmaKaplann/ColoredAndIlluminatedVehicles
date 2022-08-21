using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class BoatDto
    {
        //Her bir teknenin IDsi, rengi, farlarının açık/kapalı olma durumu var.
        public int ID { get; set; }
        public string Color { get; set; }
        public bool AreHeadlightsOn { get; set; }

    }
}
