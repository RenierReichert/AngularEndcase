using CoursesDBProject.Controllers;
using CoursesDBProject.Entities;
using CoursesDBProject.Shared;
using CoursesDBProject.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;

namespace BackendTests
{
    [TestClass]
    public class ParserTests
    {
        private static string pathToInputFiles = "D://EINDCASE//AngularEndcase//FrontEnd//courseDBWebpage//inputfiles";
        public static List<CourseInstance> happyflowExpected = new()
            {
                new CourseInstance()
        {
            course = new Course()
            {
                titel = "C# Programmeren",
                code = "CNETIN",
                duur = 5,

            },
                    startdatum = new DateTime(2018, 10, 8)

                },
                new CourseInstance()
        {
            course = new Course()
            {
                titel = "C# Programmeren",
                code = "CNETIN",
                duur = 5,

            },
                    startdatum = new DateTime(2018, 10, 15)

                }
    };

        public static List<CourseInstance> errorflowExpected = new List<CourseInstance>(0);


        [DataRow("Titel: C# Programmeren\r\nCursuscode: CNETIN\r\nDuur: 5 dagen\r\nStartdatum: 8/10/2018\r\n\r\nTitel: C# Programmeren\r\nCursuscode: CNETIN\r\nDuur: 5 dagen\r\nStartdatum: 15/10/2018\r\n\r\nTitel: Java Persistence API\r\nCursuscode: JPA\r\nDuur: 2 dagen\r\nStartdatum: 15/10/2018\r\n\r\nTitel: Java Persistence API\r\nCursuscode: JPA\r\nDuur: 2 dagen\r\nStartdatum: 8/10/2018\r\n\r\nTitel: C# Programmeren\r\nCursuscode: CNETIN\r\nDuur: 5 dagen\r\nStartdatum: 8/10/2018")]
        [DataRow("Titel: C# Programmeren\r\nDuur: 5 dagen\r\nCursuscode: CNETIN\r\nStartdatum: 8/10/2018")]
        [TestMethod]
        public void IFormToStringList(string content)
        {
            //Arrange
            //Setup mock file using a memory stream
            var fileName = "test.txt";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;


            //create FormFile with desired data
            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            //Act
            List<string> expected = Parsers.ReadAsList(file);
            List<string> actual = content.Split("\r\n").ToList();

            //Assert
            Assert.AreEqual(expected.Count, actual.Count);
            for (var i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }


        [DataRow("Titel: C# Programmeren\r\nCursuscode: CNETIN\r\nDuur: 5 dagen\r\nStartdatum: 8/10/2018\r\n\r\nTitel: C# Programmeren\r\nCursuscode: CNETIN\r\nDuur: 5 dagen\r\nStartdatum: 15/10/2018", true)]
        [DataRow("Titel: C# Programmeren\r\nDuur: 5 dagen\r\nCursuscode: CNETIN\r\nStartdatum: 8/10/2018", false)]
        [TestMethod]
        public void ParsingCourseInstancesFromStrings(string content, bool correctinput)
        {
            //Arrange
            List<string> input = content.Split("\r\n").ToList();
            List<CourseInstance> expected, actual;

            if (correctinput)
            {
                expected = happyflowExpected;
            }
            else
            {
                expected = errorflowExpected;
            }


            //act and assert
            if (!correctinput)
            {
                try
                {
                    actual = Parsers.ParseCoursesFromFile(input);
                    Assert.Fail();
                }
                catch
                {
                    Assert.IsTrue(true);
                }
            }
            else
            {
                actual = Parsers.ParseCoursesFromFile(input);
                Assert.AreEqual(expected.Count, actual.Count);

                //Tojson for better checking?
                /*
                for (var i = 0; i < expected.Count; i++)
                {
                    Assert.AreEqual(expected[i].course, actual[i].course);
                    Assert.AreEqual(expected[i].startdatum, actual[i].startdatum);
                }
                */

                for (var i = 0; i < expected.Count; i++)
                {
                    var object1Json = JsonConvert.SerializeObject(expected[i]);
                    var object2Json = JsonConvert.SerializeObject(actual[i]);

                    Assert.AreEqual(object1Json, object2Json);
                }
            }
        }
    }
}