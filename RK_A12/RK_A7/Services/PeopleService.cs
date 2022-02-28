using RK_A7.Interfaces;
using RK_A7.Entities;
using RK_A7.Models;
using RK_A7.DB;

namespace RK_A7.Services
{
    public class PeopleService : IPeopleService
    {
        public PeopleService() { }

        public List<PersonModel> GetAllPeople()
        {
            var result = new List<PersonModel>();
            foreach (var member in PeopleDB.Instance().MemberList)
            {
                result.Add((PersonModel)member);
            }
            return result;
        }

        public PersonModel GetPerson(int id)
        {
            var foundPerson = PeopleDB.Instance().MemberList.Where(member => member.Id == id).FirstOrDefault();
            if (foundPerson != null)
            {
                return (PersonModel)foundPerson;
            }
            return null;
        }

        public void AddPerson(PersonModel person)
        {
            var memberToAdd = (Person)person;
            memberToAdd.Id = PeopleDB.Instance().Order + 1;
            PeopleDB.Instance().MemberList.Add(memberToAdd);
            PeopleDB.Instance().Order++;
        }

        public void EditPerson(int id, PersonModel person)
        {
            var memberToEditIndex = PeopleDB.Instance().MemberList.FindIndex(member => member.Id == id);
            if (PeopleDB.Instance().MemberList[memberToEditIndex] != null)
            {
                var editedPerson = (Person)person;
                editedPerson.Id = id;
                PeopleDB.Instance().MemberList[memberToEditIndex] = editedPerson;
            }
        }

        public void DeletePerson(int id)
        {
            var memberToEditIndex = PeopleDB.Instance().MemberList.FindIndex(member => member.Id == id);
            if (PeopleDB.Instance().MemberList[memberToEditIndex] != null)
            {
                PeopleDB.Instance().MemberList.RemoveAt(memberToEditIndex);
            }

        }
    }
}