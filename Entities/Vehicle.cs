using Entities.Dto;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class BaseEntity
    {
        //Her aracın IDsi olmak zorunda, o yüzden ID tanımlayıp sonrasında da BaseEntityi miras verdim.
        [Key]
        public int ID { get; set; }
    }

    public class Vehicle : BaseEntity
    {
        //Tüm araçların rengi olmalıdır.
        public VehicleColor Color { get; set; }
    }
}
