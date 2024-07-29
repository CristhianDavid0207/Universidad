using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using inscription.Models;
using ClosedXML.Excel;
using inscription.Infraestructures.Contexts;

namespace inscription.Controllers;

public class HomeController : Controller
{
    private readonly InscriptionsContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(InscriptionsContext context, ILogger<HomeController> logger)
    {
        _logger = logger;
        _context = context;

    }

    public IActionResult Index()
    {
        return View();
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


    //Carrers
    [HttpPost]
    

    public async Task<IActionResult> ImportDocExcel(IFormFile excel)    
    {
        
        var workbook = new XLWorkbook(excel.OpenReadStream());

        var hoja = workbook.Worksheet(1);

        var primeraFilaUsada = hoja.FirstRowUsed().RangeAddress.FirstAddress.RowNumber;
        var ultimaFilaUsada = hoja.LastRowUsed().RangeAddress.FirstAddress.RowNumber;

        var careers = new List<Career>();
        var universities = new List<University>();
        var professors = new List<Professor>();
        var subjects = new List<Subject>();
        var semesters = new List<Semester>();

        for (int i = primeraFilaUsada + 1; i <= ultimaFilaUsada; i++)
        {
            var fila = hoja.Row(i);
            var career = new Career();
            var university = new University();
            var professor = new Professor();
            var subject = new Subject();
            var semester = new Semester();

            //career.Id = fila.Cell(1).GetValue<int>();
            career.NameCareer = fila.Cell(14).GetString();

            //University
            university.NameUniversity = fila.Cell(15).GetString();

            //Professor
            professor.NameProfessor = fila.Cell(9).GetString();
            professor.LastNameProfessor = fila.Cell(10).GetString();
            professor.PhoneProfessor = fila.Cell(11).GetString();
            professor.EmailProfessor = fila.Cell(12).GetString();

            //Subject
            subject.NameSubject = fila.Cell(6).GetString();

            //Semester
            semester.NameSemester = fila.Cell(7).GetString();

            careers.Add(career);
            universities.Add(university);
            professors.Add(professor);
            subjects.Add(subject);
            semesters.Add(semester);
        }

        await _context.AddRangeAsync(careers);
        await _context.AddRangeAsync(universities);
        await _context.AddRangeAsync(professors);
        await _context.AddRangeAsync(subjects);
        await _context.AddRangeAsync(semesters);
        await _context.SaveChangesAsync();

//------------------------------ Logica para Entidades con Forenring Key ------------------------------------------------------------------
        
        
        var semesterDict = new Dictionary<string, int>();
        var universityDict = new Dictionary<string, int>();
        var careerDict = new Dictionary<string, int>();
        var subjectDict = new Dictionary<string, int>();
  
        
       foreach (var semester in _context.Semesters)
        {
            if (!semesterDict.ContainsKey(semester.NameSemester))
            {
                semesterDict[semester.NameSemester] = semester.Id;
            }
        }

        foreach (var university in _context.Universities)
        {
            if (!universityDict.ContainsKey(university.NameUniversity))
            {
                universityDict[university.NameUniversity] = university.Id;
            }
        }

        foreach (var career in _context.Careers)
        {
            if (!careerDict.ContainsKey(career.NameCareer))
            {
                careerDict[career.NameCareer] = career.Id;
            }
            
        }

        foreach (var subject in _context.Subjects)
        {
            if (!subjectDict.ContainsKey(subject.NameSubject))
            {
                subjectDict[subject.NameSubject] = subject.Id;
            }
            
        }
        
        var inscriptions = new List<Inscription>();
        var students = new List<Student>();
        var universitiesDeans = new List<UniversityDean>();
        var careersHasSubjects = new List<CareerHasSubject>();
        
        for (int i = primeraFilaUsada + 1; i <= ultimaFilaUsada; i++)
        {
            var fila = hoja.Row(i);
            var inscription = new Inscription();
            var student = new Student();
            var universityDean = new UniversityDean();
            var careerHasSubject = new CareerHasSubject();

            //Inscription
            //-------------------inscription.Id = fila.Cell(1).GetValue<int>();
            inscription.Status = fila.Cell(16).GetString();

            //Studen
            student.NameStudent = fila.Cell(2).GetString();
            student.LastNameStudent = fila.Cell(3).GetString();
            student.EmailStudent = fila.Cell(4).GetString();
            student.PhoneStudent = fila.Cell(5).GetString();

            //University Dean
            universityDean.NameDean = fila.Cell(13).GetString();


            // Buscar el semestre correspondiente por nombre y asignar el ID
            var semesterName = fila.Cell(7).GetString();
            if (semesterDict.TryGetValue(semesterName, out var semesterId))
            {
                inscription.SemesterId = semesterId;                  
                student.SemesterId = semesterId;                  
            }  

            // Buscar la universidad correspondiente por nombre y asignar el ID
            var universityName = fila.Cell(15).GetString();
            if (universityDict.TryGetValue(universityName, out var universityId))
            {
                universityDean.UniversityId = universityId;
            }

            // // Buscar la carrera correspondiente por nombre y asignar el ID
            // var careerName = fila.Cell(14).GetString();
            // if (careerDict.TryGetValue(careerName, out var careerId))
            // {
            //     careerHasSubject.CareerId = careerId;
            // }

            // // Buscar la carrera correspondiente por nombre y asignar el ID
            // var subjectName = fila.Cell(7).GetString();
            // if (subjectDict.TryGetValue(subjectName, out var subjectId))
            // {
            //     careerHasSubject.SubjectId = subjectId;
            // }
        
            
            
            inscriptions.Add(inscription);
            students.Add(student);
            universitiesDeans.Add(universityDean);
            // careersHasSubjects.Add(careerHasSubject);
        }


            await _context.AddRangeAsync(inscriptions);
            await _context.AddRangeAsync(students);
            await _context.AddRangeAsync(universitiesDeans);
            // await _context.AddRangeAsync(careersHasSubjects);
            await _context.SaveChangesAsync();



//------------------------------ Logica para Entidades Débiles------------------------------------------------------------------

            // // Directorios para entidades pivotes
            // var carersHasSubjects = new List<CareerHasSubject>();


            // for (int i = primeraFilaUsada + 1; i <= ultimaFilaUsada; i++)
            // {
            //     var fila = hoja.Row(i);
            //     var careerHasSubject = new CareerHasSubject();


            //     // Buscar el profesor correspondiente por nombre y asignar el ID
            //     var careerName = fila.Cell(9).GetString();
            //     if (careerDict.TryGetValue(careerName, out var careerId))
            //     {
            //         careerHasSubject.CareerId = careerId;                    
            //     }

            //     // Buscar la universidad correspondiente por nombre y asignar el ID
            //     var subjectName = fila.Cell(15).GetString();
            //     if (subjectDict.TryGetValue(subjectName, out var subjectId))
            //     {
            //         careerHasSubject.SubjectId = subjectId;
            //     }


            //     carersHasSubjects.Add(careerHasSubject);

            // }

            //     await _context.AddRangeAsync(carersHasSubjects);
            //     await _context.SaveChangesAsync();
        
        
 
        return RedirectToAction("Index", "GetCareer");
    }

}
