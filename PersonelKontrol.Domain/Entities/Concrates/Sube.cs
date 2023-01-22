using PersonelKontrol.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace PersonelKontrol.Domain.Entities.Concrates;

public partial class Sube:BaseEntity
{  

    public int? PersonelId { get; set; }

    public string SubeAdi { get; set; } 

    public string Aciklama { get; set; }    

    public virtual ICollection<Firma> Firmas { get; } = new List<Firma>();

    public virtual Personel? Personel { get; set; }
}
