using PersonelKontrol.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace PersonelKontrol.Domain.Entities.Concrates;

public partial class PersonelHareketleri : BaseEntity
{
  

    public int PersonelId { get; set; }

    public DateTime Tarih { get; set; }

    public DateTime GirisSaati { get; set; }

    public DateTime? CikisSaati { get; set; }   

    public virtual Personel Personel { get; set; } 
}
