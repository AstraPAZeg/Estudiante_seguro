using System;
using APIStudentSecurity.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StudentSecurity.Tests.Controllers
{
    [TestClass]
    public class UnitTest1APIStudent
    {
        [TestMethod]
        public void TestGetStudent()
        {
            //Arrange
            StudentsController studentsController = new StudentsController();

            //Act
            var listaEstudiantes = studentsController.GetStudents();

            //Assert
            Assert.IsNotNull(listaEstudiantes);
        }
    }
}
