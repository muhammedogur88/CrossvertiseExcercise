using CrossvertiseExcercise.Models;
using CrossvertiseExcercise.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CrossvertiseExcercise.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ICalendarService _calendarService;

        public CalendarController(ICalendarService calendarService)
        {
            _calendarService = calendarService ?? throw new ArgumentNullException(nameof(calendarService));
        }

        public async Task<IActionResult> Index()
        {
            var list = await _calendarService.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ShowAppointmentByMonth(int month)
        {
            var list = await _calendarService.GetAppointmentListByMonthAsync(month);
            return PartialView(list);
        }

        [HttpPost]
        public async Task<IActionResult> ShowAppointmentDetail(string id)
        {
            Guid guid = new Guid(id);
            var appointmentDetail = await _calendarService.GetAppointmentDetailAsync(guid);

            return PartialView(appointmentDetail);
        }
    }
}
