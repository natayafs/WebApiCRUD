using System;
using System.Collections.Generic;

namespace WebApiCRUD.Models
{
    public partial class TimeMark
    {
        public int IdUser { get; set; }
        public int IdParade { get; set; }
        public DateTime ArrivalTime { get; set; }

        public virtual Parade IdParadeNavigation { get; set; }
        public virtual Competitor IdUserNavigation { get; set; }
    }
}
