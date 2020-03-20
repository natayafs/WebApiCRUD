using System;
using System.Collections.Generic;

namespace WebApiCRUD.Models
{
    public partial class Alert
    {
        public Alert()
        {
            Alertnotification = new HashSet<Alertnotification>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Notifywhenarriving { get; set; }
        public bool? Notifywhenleaving { get; set; }
        public int? Enterpriseid { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Alertnotification> Alertnotification { get; set; }
    }
}
