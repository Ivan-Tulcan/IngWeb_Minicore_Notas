using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Minicore_Notas.Data;
using Minicore_Notas.Models;
using Minicore_Notas.Models.ViewModel;
using System.Diagnostics;

namespace Minicore_Notas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context,ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult Index()
        {
            
            //Para crear Grades
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Name");
            /*retrieve*/
            GradeVM gradeVm= new()
            {
                Grade = new Grade(),
                Student = new Student(_context),
                Period = new Period(),
                StudentsList = _context.Students.ToList(),
                PeriodsList = _context.Periods.ToList(),
                GradesList = _context.Grades.ToList()
            };
            return View(gradeVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStudent([Bind("Id,Name")] Student student)
        {

            _context.Add(student);
            await _context.SaveChangesAsync();
            return Redirect("."); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGrade([Bind("Id,Name,GradeValue,Date,StudentId")] Grade grade)
        {
            try
            {
                _context.Add(grade);
                await _context.SaveChangesAsync();
                return Redirect(".");
            }
            catch(Exception e)
            {
                ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Name", grade.StudentId);
                return Redirect(".");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePeriod([Bind("Id,Start,End,Weigh")] Period period)
        {
            try
            {
                _context.Add(period);
                await _context.SaveChangesAsync();
                
            }
            catch (Exception e)
            {
            }
            return Redirect(".");
        }

        /*ACTION FOR RETRIEVING ALL THE GRADES IN A RANGE OF dates*/
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DefineRange(DateOnly startDate, DateOnly endDate)
        {
            try
            {
                
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
            }
            return Redirect(".");
        }
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
