using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ProjectStudentSystem.Models;

public class AdminController : Controller
{
    private int page = 1;
    private readonly AddStudentRepository _repository;
    private readonly ActivityRepository _activityRepository;

    public AdminController(AddStudentRepository repository, ActivityRepository activityRepository)
    {
        _repository = repository;
        _activityRepository = activityRepository ?? throw new ArgumentNullException(nameof(activityRepository));

    }
    [HttpGet]
    public IActionResult Index(int pg = 1, int pageSize = 5, string sortColumn = "FullName", string sortOrder = "asc")
    {

        var students = _repository.GetAllStudents();

        if (pg < 1)
        {
            pg = 1;
        }
        if (page != 1)
        {
            String action = "PageSize";
            _activityRepository.AddActivity(action);
        }
        page++;
        HttpContext.Session.SetInt32("Page", page);
        students = _repository.SortStudents(students, sortColumn, sortOrder);

        int recsCount = students.Count();
        var pager = new Pager(recsCount, pg, pageSize);

        int recSkip = (pg - 1) * pageSize;
        var data = students.Skip(recSkip).Take(pager.PageSize).ToList();
        ViewBag.Pager = pager;

        return View(data);
    }

   


    public IActionResult Index1(int pg = 1, int pageSize = 5, string sortColumn = "FullName", string sortOrder = "asc")
    {
        var students = _repository.GetAllStudents();
        int page = HttpContext.Session.GetInt32("Page") ?? 1;

        if (pg < 1)
        {
            pg = 1;
        }
        if (page != 1)
        {
            String action = "PageSize";
            _activityRepository.AddActivity(action);
        }

        page++;
        HttpContext.Session.SetInt32("Page", page);
        students = _repository.SortStudents(students, sortColumn, sortOrder);

        int recsCount = students.Count();
        var pager = new Pager(recsCount, pg, pageSize);

        int recSkip = (pg - 1) * pageSize;
        var data = students.Skip(recSkip).Take(pager.PageSize).ToList();
        ViewBag.Pager = pager;

        return View(data);
    }

    public IActionResult DeleteStudent(int id)
    {
        var student = _repository.GetStudentById(id);
        if (student != null)
        {
            _repository.DeleteStudent(id);
        }
        String action = "Delete";
        _activityRepository.AddActivity(action);
        return RedirectToAction("Index", "Admin");
    }

    public IActionResult EditStudent(int id)
    {
        String action = "EditStudent";
        _activityRepository.AddActivity(action);
        var student = _repository.GetStudentById(id);
        return View(student);
    }



    [HttpPost]
    public IActionResult EditStudent(AddStudent student)
    {
        if (ModelState.IsValid)
        {
            _repository.UpdateStudent(student);
            return RedirectToAction("Index", "Admin");
        }

        return View(student);
    }


    

    public IActionResult ViewDetail(int id)
    {
        String action = "View";
        _activityRepository.AddActivity(action);
        var student = _repository.GetStudentById(id);
        return View(student);
    }

}
