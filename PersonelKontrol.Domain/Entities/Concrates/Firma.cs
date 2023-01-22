using PersonelKontrol.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace PersonelKontrol.Domain.Entities.Concrates;

public partial class Firma : BaseEntity
{ 

    public int? SubeId { get; set; }

    public string FirmaAdi { get; set; } 

    public string Aciklama { get; set; }

    public virtual Sube? Sube { get; set; }
   
}
