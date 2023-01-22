using PersonelKontrol.Domain.Entities.Abstract;
using PersonelKontrol.Domain.Entities.Concrates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelKontrol.Application.DTOs
{
    public class EmployeeMovementsInfoDto:BaseEntity
    {
        public int PersonelId { get; set; }

        public DateTime Tarih { get; set; }

        public DateTime GirisSaati { get; set; }

        public DateTime? CikisSaati { get; set; }
         
    }
}
