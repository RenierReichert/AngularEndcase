using CoursesDBProject.Entities;
using CoursesDBProject.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace BackendTests
{
    [TestClass]
    public class DBTests
    {
    }
    /*
    [DataRow("Titel: C# Programmeren\r\nCursuscode: CNETIN\r\nDuur: 5 dagen\r\nStartdatum: 8/10/2018\r\n\r\nTitel: C# Programmeren\r\nCursuscode: CNETIN\r\nDuur: 5 dagen\r\nStartdatum: 15/10/2018", true)]
    [DataRow("Titel: C# Programmeren\r\nDuur: 5 dagen\r\nCursuscode: CNETIN\r\nStartdatum: 8/10/2018", false)]
    [TestMethod]
    public void AcceptCorrectUploadsAndRejectIncorrectOnes(string content, bool correctinput)
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
            

            for (var i = 0; i < expected.Count; i++)
            {
                var object1Json = JsonConvert.SerializeObject(expected[i]);
                var object2Json = JsonConvert.SerializeObject(actual[i]);

                Assert.AreEqual(object1Json, object2Json);
            }
        }
    }

    [DataRow("Titel: C# Programmeren\r\nCursuscode: CNETIN\r\nDuur: 5 dagen\r\nStartdatum: 8/10/2018\r\n\r\nTitel: C# Programmeren\r\nCursuscode: CNETIN\r\nDuur: 5 dagen\r\nStartdatum: 15/10/2018", true)]
    [DataRow("Titel: C# Programmeren\r\nDuur: 5 dagen\r\nCursuscode: CNETIN\r\nStartdatum: 8/10/2018", false)]
    [TestMethod]
    public void DuplicatesShouldntBeAddedToDB(string content, bool correctinput)
    {


    }
    */
}
