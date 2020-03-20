using System;
using System.Collections.Generic;

namespace WebApiCRUD.Models
{
    public partial class Competitor
    {
        public Competitor()
        {
            Result = new HashSet<Result>();
            TimeMark = new HashSet<TimeMark>();
        }

        public int IdUser { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<Result> Result { get; set; }
        public virtual ICollection<TimeMark> TimeMark { get; set; }
    }
}
