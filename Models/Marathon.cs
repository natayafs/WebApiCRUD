using System;
using System.Collections.Generic;

namespace WebApiCRUD.Models
{
    public partial class Marathon
    {
        public Marathon()
        {
            Parade = new HashSet<Parade>();
            Result = new HashSet<Result>();
        }

        public int IdMarathon { get; set; }
        public string Title { get; set; }
        public DateTime RaceStartDate { get; set; }
        public DateTime RegistrationDeadline { get; set; }
        public DateTime RegistrationStartDate { get; set; }
        public string InitialLatitude { get; set; }
        public string InitialLongitude { get; set; }
        public string FinalLatitude { get; set; }
        public string FinalLongitude { get; set; }
        public int CompetitorsLimit { get; set; }
        public byte Category { get; set; }
        public string Detail { get; set; }
        public bool JsonUploaded { get; set; }

        public virtual ICollection<Parade> Parade { get; set; }
        public virtual ICollection<Result> Result { get; set; }
    }
}
