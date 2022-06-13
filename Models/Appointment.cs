using System;
using System.Collections.Generic;

namespace AppointmentWPFDotNet6.Models
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public DateTime DateHour { get; set; }
        public string Subject { get; set; } = null!;
        public int IdCustomer { get; set; }
        public int IdBroker { get; set; }

        public virtual Broker IdBrokerNavigation { get; set; } = null!;
        public virtual Customer IdCustomerNavigation { get; set; } = null!;
    }
}
