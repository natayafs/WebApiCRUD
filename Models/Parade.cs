using System;
using System.Collections.Generic;

namespace WebApiCRUD.Models
{
    public partial class Parade
    {
        public Parade()
        {
            TimeMark = new HashSet<TimeMark>();
        }

        public int IdParade { get; set; }
        public int IdMarathon { get; set; }
        public int Ordernumber { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public virtual Marathon IdMarathonNavigation { get; set; }
        public virtual ICollection<TimeMark> TimeMark { get; set; }
    }
}
