using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossvertiseExcercise.Models
{
    public partial class Appointment
    {
        public Appointment()
        {
            AppointmentAttendees = new HashSet<AppointmentAttendee>();
        }

        public Guid Id { get; set; }
        public string Subject { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid OrganizerId { get; set; }
        public DateTime Date { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<AppointmentAttendee> AppointmentAttendees { get; set; }
    }
}
