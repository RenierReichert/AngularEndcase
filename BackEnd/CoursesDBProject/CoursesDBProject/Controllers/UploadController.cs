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

        #region RecieveAndParse
        try
        {
            var file = Request.Form.Files[0];

            List<string> filelines = Parsers.ReadAsList(file);
            Console.WriteLine("FILE CONVERTED TO STRINGS");
            objList =  Parsers.ParseCoursesFromFile(filelines);
            Console.WriteLine("FILE PARSED");
            if(objList.Count == 0) 
            {
                return Ok("This data was already in the database.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error uploading file: {ex.Message}");
            return StatusCode(500, $"Error uploading file: {ex.Message}");
        }
        #endregion

        #region DBUpload
        try
        {
            DBC.CoursesUpload(objList);
            Console.WriteLine("FILE UPLOADED");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error uploading file: {ex.Message}");
            return StatusCode(500, $"Oopsie Whoopsie, our DataBase Brokey Wokey. Our coding boys will quickly help you fix this :) Contact your system admin.");
        }
        #endregion
        return Ok(new { status = "Everything went well" });
      
    }



}
