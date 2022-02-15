using RK_A6.Models;
using RK_A6.Enums;
using System.Data;

namespace RK_A6.Interfaces
{
    public interface IPeopleFacade
    {
        List<PersonModel> GetPeopleByGender(Gender gender);

        PersonModel GetOldestPerson();

        List<string> GetFullName();

        List<PersonModel> GetPeopleByBirthYear(int year);

        List<PersonModel> GetPeopleByBirthYearGreater(int year);

        List<PersonModel> GetPeopleByBirthYearLess(int year);

        List<PersonModel> GetAllPeople();

        DataTable GetDataTable();

        PersonModel GetPerson(uint id);

        void AddPerson(PersonModel model);

        void EditPerson(PersonModel model);

        void DeletePerson(PersonModel model);
    }
}