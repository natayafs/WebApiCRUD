﻿using System;
using System.Collections.Generic;

namespace WebApiCRUD.Models
{
    public partial class Gpsreporthistory
    {
        public int Id { get; set; }
        public DateTime? Timestamp { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? Vehicleid { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
