using AutoMapper;
using CrossvertiseExcercise.Models;
using CrossvertiseExcercise.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json;

namespace CrossvertiseExcercise.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly CalendarContext _context;
        private readonly IMapper _mapper;

        public CalendarService(CalendarContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await _context.Appointments.Include(a=>a.AppointmentAttendees).ToListAsync();
        }

        public async Task<IEnumerable<AppointmentListViewModel>> GetAppointmentListByMonthAsync(int month)
        {

            var list = await _context.Appointments.Where(mo => mo.Date.Month == month).ToListAsync();

            return _mapper.Map<List<Appointment>, List<AppointmentListViewModel>>(list);


        }

        public async Task<AppointmentDetailViewModel> GetAppointmentDetailAsync(Guid id)
        {
            var item = await _context.Appointments.Include(a => a.User).Include(a => a.AppointmentAttendees).ThenInclude(a => a.User).Where(a=>a.Id==id).FirstOrDefaultAsync();

            return _mapper.Map<AppointmentDetailViewModel>(item);
        }
    }
}
