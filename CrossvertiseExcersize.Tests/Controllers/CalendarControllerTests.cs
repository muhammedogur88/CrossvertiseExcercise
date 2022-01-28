using CrossvertiseExcercise.Controllers;
using CrossvertiseExcercise.Services;
using CrossvertiseExcercise.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace CrossvertiseExcersize.Tests.Controllers
{
    [TestFixture]
    public class CalendarControllerTests
    {
        [Test]
        public async Task Index_ReturnsAViewResult()
        {
            //Arrange
            var _calendarService = new Mock<ICalendarService>();
            var _calendarController = new CalendarController(_calendarService.Object);
            // Act
            var result = await _calendarController.Index();

            // Assert
            Assert.IsTrue(result.GetType() == typeof(ViewResult));

        }

        [Test]
        [TestCase(3)]
        public async Task ShowAppointmentByMonth_ReturnsAPartialViewResult_WithAppointmentData(int month)
        {

            //Arrange

            var IdTest = new Guid("32f2d615-d200-49c7-b6dd-cdf048a6380e");
            var DateTest = Convert.ToDateTime("14/3/2021").ToString("MM/dd/yyyy h:mm tt", CultureInfo.GetCultureInfo("en-US"));
            var DescriptionTest = "Project Meeting";

            var list = new List<AppointmentListViewModel>();
            AppointmentListViewModel data = new AppointmentListViewModel
            {
                Id = new Guid("32f2d615-d200-49c7-b6dd-cdf048a6380e"),
                Date = Convert.ToDateTime("14/3/2021").ToString("MM/dd/yyyy h:mm tt", CultureInfo.GetCultureInfo("en-US")),
                Description = "Project Meeting",
            };

            list.Add(data);

            var _calendarService = new Mock<ICalendarService>();
            _calendarService.SetupSequence(data => data.GetAppointmentListByMonthAsync(month))
                .ReturnsAsync(list);

            var _calendarController = new CalendarController(_calendarService.Object);

            // Act
            var result = await _calendarController.ShowAppointmentByMonth(month) as PartialViewResult;
            var model = result?.ViewData.Model as List<AppointmentListViewModel>;
            // Assert
            Assert.IsTrue(result?.GetType() == typeof(PartialViewResult));

            Assert.AreEqual(model?.Count, list.Count);
            Assert.AreEqual(model?[0].Id, IdTest);
            Assert.AreEqual(model?[0].Date, DateTest);
            Assert.AreEqual(model?[0].Description, DescriptionTest);

        }

        [Test]
        [TestCase("32f2d615-d200-49c7-b6dd-cdf048a6380e")]
        public async Task ShowAppointmentDetailById_ReturnsAPartialViewResult_WithAppointmentDetailData(string id)
        {

            //Arrange

            var IdTest = new Guid("32f2d615-d200-49c7-b6dd-cdf048a6380e");
            var OrganizerTest = "Muhammed Ogur";
            var DateTest = "01/27/2022 12:53 PM";
            var SubjectTest = "Meeting";
            var AppointmentAttendeesNameTest = new List<string>() { "John Doe", "Jane Doe" };

            AppointmentDetailViewModel data = new AppointmentDetailViewModel
            {
                Organizer = "Muhammed Ogur",
                Date = "01/27/2022 12:53 PM",
                Subject = "Meeting",
                AppointmentAttendeesName = new List<string>() { "John Doe", "Jane Doe" },
            };

            var _calendarService = new Mock<ICalendarService>();
            _calendarService.SetupSequence(data => data.GetAppointmentDetailAsync(IdTest))
                .ReturnsAsync(data);

            var _calendarController = new CalendarController(_calendarService.Object);

            // Act
            var result = await _calendarController.ShowAppointmentDetail(IdTest.ToString()) as PartialViewResult;
            var model = result?.ViewData.Model as AppointmentDetailViewModel;
            // Assert
            Assert.IsTrue(result?.GetType() == typeof(PartialViewResult));

            Assert.AreEqual(model?.Organizer, OrganizerTest);
            Assert.AreEqual(model?.Subject, SubjectTest);
            Assert.AreEqual(model?.Date, DateTest);
            Assert.AreEqual(model?.AppointmentAttendeesName.Count, data.AppointmentAttendeesName.Count);

        }

    }
}

