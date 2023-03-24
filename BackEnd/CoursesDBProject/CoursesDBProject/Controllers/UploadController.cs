using CoursesDBProject.DTOs;
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
        List<CourseInstance> objList;
        ChangeListDTO changelist; 

        #region RecieveAndParse
        try
        {
            var file = Request.Form.Files[0];
            List<string> filelines = Parsers.ReadAsList(file);
            Console.WriteLine("FILE CONVERTED TO STRINGS");
            objList =  Parsers.ParseCoursesFromFile(filelines);
            Console.WriteLine("FILE PARSED");
        }
        catch (Parsers.MyException ex)
        { 
            Console.WriteLine($"Error uploading file: {ex.Message}");
            return StatusCode(500, $"{ex.Message}");
        }
        #endregion

        #region DBUpload

        try
        {
            changelist = DBC.CoursesUpload(objList);
            Console.WriteLine("FILE UPLOADED");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error uploading file: {ex.Message}");
            return StatusCode(406, $"{ex.Message}");
            //return StatusCode(500, $"Oopsie Whoopsie, our DataBase Brokey Wokey. Our coding boys will quickly help you fix this :) Contact your system admin.");
        }
        #endregion

        Console.WriteLine(changelist.message);

        return Ok(new {
            message = changelist.message,
            cichangeList = changelist.courseInstance,
            pcchangeList = changelist.courses 
        });
      
    }



}
