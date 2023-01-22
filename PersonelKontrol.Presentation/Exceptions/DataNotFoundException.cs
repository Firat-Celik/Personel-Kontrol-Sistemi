using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelKontrol.Presentation.Exceptions
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(string type, object id)
            : base($"{type} türündeki {id} id değerine sahip olan obje bulunamadı! ") { }
    }
}
