using CrossvertiseExcercise.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossvertiseExcercise.Util
{
    public class DbInitializer
    {
        public static void Initialize(CalendarContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            var testUser = new User
            {
                Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                FullName = "Muhammed Ogur"
            };

            var attendeeUser = new User
            {
                Id = new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                FullName = "John Doe"
            };

            var attendeeUser2 = new User
            {
                Id = new Guid("4b675494-7af0-4f6b-9ed0-0ebe44403136"),
                FullName = "Elbert Doe"
            };
            var attendeeUser3 = new User
            {
                Id = new Guid("266b3800-c4af-4c54-9d74-be1cc03853c7"),
                FullName = "CladuiusdDoe"
            };

            var appointment = new Appointment
            {
                Id = new Guid("32f2d615-d200-49c7-b6dd-cdf048a6380e"),
                Date = DateTime.Now,
                Subject ="Meeting",
                Description = "Meeting",
                OrganizerId = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
            };

            var appointment1 = new Appointment
            {
                Id = new Guid("c2c61136-1087-4774-9791-2a74044bbc60"),
                Date = Convert.ToDateTime("3/2/2021"),
                Description = "Scrum Meeting",
                OrganizerId = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                Subject = "New Project",
            };
            var appointment2 = new Appointment
            {
                Id = new Guid("c01012c2-0f69-47b2-8a81-4e69c878733d"),
                Date = Convert.ToDateTime("6/3/2021"),
                Description = "Lusty Men, The",
                OrganizerId = attendeeUser3.Id,
                Subject = "samething"
            };

            var appointmentAttendee = new AppointmentAttendee
            {
                Id = new Guid("285f40ee-b1f3-4f32-ba45-0e417d166a42"),
                UserId = new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                AppointmentId = new Guid("32f2d615-d200-49c7-b6dd-cdf048a6380e"),
            };
            var appointmentAttendee1 = new AppointmentAttendee
            {
                Id = new Guid("c43b22e7-c533-426c-8ed7-60fb8e0279cf"),
                UserId = new Guid("4b675494-7af0-4f6b-9ed0-0ebe44403136"),
                AppointmentId = new Guid("32f2d615-d200-49c7-b6dd-cdf048a6380e"),
            };
            var appointmentAttendee2 = new AppointmentAttendee
            {
                Id = new Guid("b2c02a68-cd73-4547-9a0f-d37ac3311a18"),
                UserId = new Guid("32f2d615-d200-49c7-b6dd-cdf048a6380e"),
                AppointmentId = appointment1.Id,
            };
            var appointmentAttendee3 = new AppointmentAttendee
            {
                Id = new Guid("285f40ee-b1f3-4f32-ba45-0e417d166a41"),
                UserId = new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                AppointmentId = new Guid("c2c61136-1087-4774-9791-2a74044bbc60"),
            };
            var appointmentAttendee4 = new AppointmentAttendee
            {
                Id = new Guid("c43b22e7-c533-426c-8ed7-60fb8e0279c1"),
                UserId = new Guid("4b675494-7af0-4f6b-9ed0-0ebe44403136"),
                AppointmentId = new Guid("c2c61136-1087-4774-9791-2a74044bbc60"),
            };
            var appointmentAttendee5 = new AppointmentAttendee
            {
                Id = new Guid("b2c02a68-cd73-4547-9a0f-d37ac3311a11"),
                UserId = new Guid("266b3800-c4af-4c54-9d74-be1cc03853c7"),
                AppointmentId = new Guid("c2c61136-1087-4774-9791-2a74044bbc60"),
            };
            var appointmentAttendee6 = new AppointmentAttendee
            {
                Id = new Guid("b2c02a68-cd73-4547-9a0f-d37ac3311a12"),
                UserId = new Guid("4b675494-7af0-4f6b-9ed0-0ebe44403136"),
                AppointmentId = new Guid("c01012c2-0f69-47b2-8a81-4e69c878733d"),
            };

            context.AppointmentAttendees.AddRange(appointmentAttendee, appointmentAttendee1, appointmentAttendee2, appointmentAttendee3, appointmentAttendee4, appointmentAttendee5, appointmentAttendee6);
            context.Appointments.AddRange(appointment, appointment1, appointment2);
            context.Users.AddRange(testUser, attendeeUser, attendeeUser2,attendeeUser3);

            context.SaveChanges();
        }
    }
}
