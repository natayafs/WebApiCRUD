using System;
using System.Collections.Generic;

namespace WebApiCRUD.Models
{
    public partial class User
    {
        public int IdUser { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Dni { get; set; }
        public string Nick { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Telephone { get; set; }
        public DateTime? Birthday { get; set; }
        public decimal? BodyHeight { get; set; }
        public decimal? BodyWeight { get; set; }
        public string Talle { get; set; }
        public bool? MedicaCertificate { get; set; }
        public byte Tipo { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Token { get; set; }
        public bool? Active { get; set; }

        public virtual Competitor Competitor { get; set; }
    }
}
