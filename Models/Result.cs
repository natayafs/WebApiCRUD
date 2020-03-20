using System;
using System.Collections.Generic;

namespace WebApiCRUD.Models
{
    public partial class Result
    {
        public int IdUser { get; set; }
        public int IdMarathon { get; set; }
        public DateTime ArrivalTime { get; set; }

        public virtual Marathon IdMarathonNavigation { get; set; }
        public virtual Competitor IdUserNavigation { get; set; }
    }
}
