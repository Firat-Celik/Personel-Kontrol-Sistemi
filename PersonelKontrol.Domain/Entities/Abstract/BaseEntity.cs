using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelKontrol.Domain.Entities.Abstract
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool AktifMi { get; set; }

        public DateTime OlusturulmaZamani { get; set; }

        public DateTime? DuzenlenmeZamani { get; set; }

        public bool? SilindiMi { get; set; }
    }
}
