using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossvertiseExcercise.Models
{
    public class User
    {
        public User()
        {
            AppointmentAttendees = new HashSet<AppointmentAttendee>();
            Appointments = new HashSet<Appointment>();
        }

        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;

        public virtual ICollection<AppointmentAttendee> AppointmentAttendees { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
