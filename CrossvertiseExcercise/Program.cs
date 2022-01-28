using CrossvertiseExcercise.Mapper;
using CrossvertiseExcercise.Models;
using CrossvertiseExcercise.Services;
using CrossvertiseExcercise.Util;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CalendarContext>(opt => opt.UseInMemoryDatabase("CalendarDB"));

builder.Services.AddScoped<CalendarContext>();

builder.Services.AddScoped<ICalendarService, CalendarService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<CalendarContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }
}
app.Run();

//public static class TestData
//{
//    public static void AddTestData(CalendarContext context)
//    {
//        var testUser = new User
//        {
//            Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
//            FullName = "Muhammed Ogur"
//        };

//        var attendeeUser = new User
//        {
//            Id = new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
//            FullName = "John Doe"
//        };

//        var attendeeUser2 = new User
//        {
//            Id = new Guid("c9dd7944-b1d8-4b5b-9670-3b40aea87930"),
//            FullName = "Elbert Doe"
//        };
//        var attendeeUser3 = new User
//        {
//            Id = new Guid("266b3800-c4af-4c54-9d74-be1cc03853c7"),
//            FullName = "CladuiusdDoe"
//        };

//        var appointment = new Appointment
//        {
//            Id = new Guid("32f2d615-d200-49c7-b6dd-cdf048a6380e"),
//            Date = DateTime.Now,
//            Description = "Project Meeting",
//            OrganizerId = testUser.Id,
//        };

//        var appointment1 = new Appointment
//        {
//            Id = new Guid("c2c61136-1087-4774-9791-2a74044bbc60"),
//            Date = Convert.ToDateTime("3/23/2021"),
//            Description = "Project Meeting",
//            OrganizerId = testUser.Id,
//        };
//        var appointment2 = new Appointment
//        {
//            Id = new Guid("c01012c2-0f69-47b2-8a81-4e69c878733d"),
//            Date = Convert.ToDateTime("6/18/2021"),
//            Description = "Lusty Men, The",
//            OrganizerId = attendeeUser3.Id,
//        };

//        var appointmentAttendee = new AppointmentAttendee
//        {
//            AppointmentId = appointment.Id,
//            UserId = attendeeUser.Id
//        };
//        var appointmentAttendee1 = new AppointmentAttendee
//        {
//            AppointmentId = appointment1.Id,
//            UserId = attendeeUser2.Id
//        };
//        var appointmentAttendee2 = new AppointmentAttendee
//        {
//            AppointmentId = appointment2.Id,
//            UserId = attendeeUser3.Id
//        };

//        context.AddRange(appointmentAttendee, appointment1, appointment2);
//        context.AddRange(appointment, appointment1, appointment2);
//        context.Users.AddRange(testUser, attendeeUser);

//        context.SaveChanges();
//    }

