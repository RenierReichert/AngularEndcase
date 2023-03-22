using CoursesDBProject.Entities;
using CoursesDBProject.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using CoursesDBProject.Tables;

namespace BackendTests
{
    [TestClass]
    public class DBTests
    {


        [DataRow(true)]
        [DataRow(false)]
        [TestMethod]
        public void RejectIncorrectUploads(bool correctinput)
        {
            
            //Arrange
            List<CourseInstance> expected, actual;
            if (correctinput)
            {
                expected = ParserTests.happyflowExpected;
            }
            else
            {
                expected = ParserTests.errorflowExpected;
            }
          //  var mockdb = new Mock<InfoSupportDbContext>();
          //  var dbControl = new CourseDBControl(mockdb.Object);

            //act and assert
            
        }
    }
    
}
