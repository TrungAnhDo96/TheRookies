using System.Collections.Generic;
using RK_A5.Models;
using RK_A5.Enums;

namespace RK_A5.Interfaces
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
    }
}