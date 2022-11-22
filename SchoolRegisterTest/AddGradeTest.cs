using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SchoolRegisterTest
{
    [TestClass]
    public class AddGradeTest
    {
       
        [TestMethod]
        public void AddGrade()
        {
          
            var grade = new Grade();
            grade.AddGrade();

            var result = grade.Add(new Grades(id, trimester, grade));
            var expected = true;

            Assert.AddGrade(expected, actual);

        }
    }

 
}
