using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using APIStudentSecurity.Controllers;
using APIStudentSecurity.Models;
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
        [TestMethod]
        public void TestPostStudent()
        {
            // Arrange
            StudentsController studentsController = new StudentsController();
            Student estudiante_prueba = new Student() { 
            FirstName = "Sancho",
            LastName = "Panza",
            StudentID = 10,
            EnrollmentDate = DateTime.Now
            };

            // Act
            IHttpActionResult actionResult = studentsController.PostStudent(estudiante_prueba);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Student>;

            // Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(estudiante_prueba.StudentID, createdResult.RouteValues["id"]);
            Assert.AreEqual("Sancho", createdResult.Content.FirstName);
        }

        [TestMethod]
        public void TestDeleteStudent()
        {
            // Arrange
            StudentsController studentsController = new StudentsController();
            Student estudiante_prueba = new Student()
            {
                FirstName = "Sancho",
                LastName = "Panza",
                StudentID = 10,
                EnrollmentDate = DateTime.Now
            };

            // Act
            IHttpActionResult actionResult = studentsController.PostStudent(estudiante_prueba);
            IHttpActionResult actionResultDelete = studentsController.DeleteStudent(estudiante_prueba.StudentID);


            // Assert
            Assert.IsInstanceOfType(actionResultDelete, typeof(OkNegotiatedContentResult<Student>));
        }

        [TestMethod]
        public void TestPutStudent()
        {
            // Arrange
            StudentsController studentsController = new StudentsController();
            Student estudiante_prueba = new Student()
            {
                FirstName = "Sancho",
                LastName = "Panza",
                StudentID = 10,
                EnrollmentDate = DateTime.Now
            };
            Student estudiante_reemplazo = new Student()
            {
                FirstName = "Tulio",
                LastName = "Triviño",
                StudentID = 20,
                EnrollmentDate = DateTime.Now
            };

            // Act
            IHttpActionResult actionResult = studentsController.PostStudent(estudiante_prueba);
            IHttpActionResult actionResultPut = studentsController.PutStudent(estudiante_prueba.StudentID,estudiante_reemplazo);
            var createdResult = actionResultPut as NegotiatedContentResult<Student>;

            // Assert
            Assert.IsNotNull(actionResultPut);
            Assert.IsNotNull(createdResult);
            Assert.AreEqual(estudiante_reemplazo.FirstName, createdResult.Content.FirstName);
            Assert.AreEqual(estudiante_reemplazo.StudentID, createdResult.Content.StudentID);
        }
    }
}
