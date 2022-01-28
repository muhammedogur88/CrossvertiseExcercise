using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CrossvertiseExcercise.Models
{
    public partial class AppointmentAttendee
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid AppointmentId { get; set; }

        public virtual Appointment Appointment { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
