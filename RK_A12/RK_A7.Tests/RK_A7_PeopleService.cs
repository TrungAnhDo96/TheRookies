using System.Linq;
using NUnit.Framework;
using RK_A7.DB;
using RK_A7.Interfaces;
using RK_A7.Models;
using RK_A7.Services;

namespace RK_A7.Tests
{
    public class RK_A7_PeopleService
    {
        private PeopleDB _dbInstance;
        private IPeopleService _service;

        [SetUp]
        public void Setup()
        {
            _dbInstance = PeopleDB.Instance();
            _service = new PeopleService();
        }

        [Test]
        public void EditPerson_FirstNameToEdited_EditedFirstName()
        {
            //Arrange
            var editPerson = new PersonModel() { Id = 1, FirstName = "Edited" };

            //Act
            _service.EditPerson(1, editPerson);

            //Assert
            Assert.AreEqual("Edited", _dbInstance.MemberList[0].FirstName);
        }

        [Test]
        public void DeletePerson_DeleteId1_PersonNotExist()
        {
            //Arrange
            var deletedId = 1;

            //Act
            _service.DeletePerson(deletedId);

            //Assert
            Assert.IsNull(_dbInstance.MemberList.FirstOrDefault(x => x.Id == deletedId));
        }

        [Test]
        public void Delete_DeleteId1_PersonNotExist()
        {
            //Arrange
            var deletedId = 1;

            //Act
            _service.DeletePerson(deletedId);

            //Assert
            Assert.IsNull(_dbInstance.MemberList.FirstOrDefault(x => x.Id == deletedId));
        }

        [Test]
        public void GetAllPeople_ReturnAllRecords()
        {
            //Act
            var result = _service.GetAllPeople();

            //Assert
            Assert.AreEqual(_dbInstance.MemberList.Count, result.Count);
        }

        [Test]
        public void GetPerson_GetId1_ReturnRecord()
        {
            //Arrange
            var getId = 2;

            //Act
            var result = _service.GetPerson(getId);

            //Assert
            Assert.AreEqual(_dbInstance.MemberList.FirstOrDefault(x => x.Id == getId).FirstName, result.FirstName);
        }

        [Test]
        public void AddPerson_PersonExist()
        {
            //Arrange
            var newPerson = new PersonModel()
            {
                FirstName = "New",
                LastName = "Person"
            };

            //Act
            _service.AddPerson(newPerson);

            //Assert
            Assert.AreEqual(PeopleDB.Instance().MemberList.Count, PeopleDB.Instance().Order);
            Assert.AreEqual(PeopleDB.Instance().MemberList.Count, PeopleDB.Instance().MemberList.Last().Id);
            Assert.AreEqual(PeopleDB.Instance().MemberList.Last().FirstName, newPerson.FirstName);
        }
    }
}