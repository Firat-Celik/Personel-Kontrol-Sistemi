using PersonelKontrol.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace PersonelKontrol.Domain.Entities.Concrates;

public partial class Personel : BaseEntity
{

    public string KimlikNo { get; set; }

    public string Adi { get; set; }
    public string Sifre { get; set; }

    public string Soyadi { get; set; }

    public string Email { get; set; }

    public string Telefon { get; set; }
     
    public virtual ICollection<PersonelHareketleri> PersonelHareketleris { get; } = new List<PersonelHareketleri>();

    public virtual ICollection<Sube> Subes { get; } = new List<Sube>();
}
