using CrossvertiseExcercise.Models;

namespace CrossvertiseExcercise.ViewModels
{
    public class AppointmentDetailViewModel
    {
        public string Subject { get; set; } = string.Empty;
        public List<string> AppointmentAttendeesName { get; set; } = new List<string>();
        public string? Organizer { get; set; }
        public string? Date { get; set; }

    }
}
