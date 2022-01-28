using CrossvertiseExcercise.Models;
using CrossvertiseExcercise.ViewModels;

namespace CrossvertiseExcercise.Services
{
    public interface ICalendarService
    {
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<IEnumerable<AppointmentListViewModel>> GetAppointmentListByMonthAsync(int month);
        Task<AppointmentDetailViewModel> GetAppointmentDetailAsync(Guid id);
    }
}