using PersonelKontrol.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelKontrol.Application.DTOs
{
    public class AddEmployeeMovementsDto:BaseEntity
    {
        public int PersonelId { get; set; }

        public DateTime Tarih { get; set; }

        public DateTime GirisSaati { get; set; }

        public DateTime? CikisSaati { get; set; }
    }
}
