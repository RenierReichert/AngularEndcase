using CoursesDBProject.Entities;
using CoursesDBProject.Shared;
using CoursesDBProject.Tables;
using Microsoft.AspNetCore.Mvc;

namespace CoursesDBProject.Controllers;

[Route("api/upload")]
[ApiController]
public class UploadController : Controller
{

    private InfoSupportDbContext _db;
    private CourseDBControl DBC;

    public UploadController(InfoSupportDbContext db)
    {
        _db = db;
        this.DBC = new CourseDBControl(db);
    }

    [HttpPost]
    public async Task<IActionResult> UploadFile()
    {
        Console.WriteLine("FILE RECIEVED IN BACKEND");

        try
        {
            var file = Request.Form.Files[0];

            List<string> filelines = Parsers.ReadAsList(file);
            Console.WriteLine("FILE CONVERTED TO STRINGS");
            List<CourseInstance> objList =  Parsers.ParseCoursesFromFile(filelines);
            Console.WriteLine("FILE PARSED");
            DBC.CoursesUpload(objList);
            Console.WriteLine("FILE UPLOADED");

            return Ok("File uploaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error uploading file: {ex.Message}");
            return StatusCode(500, $"Error uploading file: {ex.Message}");
        }
    }



}
