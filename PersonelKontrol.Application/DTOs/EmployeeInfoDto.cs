using PersonelKontrol.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelKontrol.Application.Dtos
{
    public class EmployeeInfoDto : BaseEntity
    {
        public string KimlikNo { get; set; }

        public string Adi { get; set; }

        public string Soyadi { get; set; }

        public string Email { get; set; }

        public string Telefon { get; set; }

    }
}
