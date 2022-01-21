using System.Collections.Generic;
using System.Linq;
using RK_A5.Enums;
using RK_A5.Interfaces;
using RK_A5.Entities;
using RK_A5.Services;
using RK_A5.Utilities;
using RK_A5.Models;

namespace RK_A5.Facades
{
    public class PeopleFacade : IPeopleFacade
    {
        IPeopleService _service;

        public PeopleFacade()
        {
            _service = new PeopleService();
        }
        public List<string> GetFullName()
        {
            List<Person> members = _service.Read();
            List<string> result = new List<string>();
            members.ForEach(member => result.Add(member.FirstName + " " + member.LastName));
            return result;
        }

        public PersonModel GetOldestPerson()
        {
            List<Person> members = _service.Read();
            uint maxAge = members.Max(member =>
            {
                return DateAgeUtility.CalAge(member.DateOfBirth);
            });
            return (PersonModel)(members.FirstOrDefault(member => DateAgeUtility.CalAge(member.DateOfBirth) == maxAge));
        }

        public List<PersonModel> GetPeopleByBirthYear(int year)
        {
            List<Person> members = _service.Read();
            List<Person> peopleByBirthYear = members.Where(member => DateAgeUtility.ParseDate(member.DateOfBirth).Year == year).ToList();
            return peopleByBirthYear.ConvertAll(person => (PersonModel)person);
        }

        public List<PersonModel> GetPeopleByBirthYearGreater(int year)
        {
            List<Person> members = _service.Read();
            List<Person> peopleByBirthYearGreater = members.Where(member => DateAgeUtility.ParseDate(member.DateOfBirth).Year > year).ToList();
            return peopleByBirthYearGreater.ConvertAll(person => (PersonModel)person);
        }

        public List<PersonModel> GetPeopleByBirthYearLess(int year)
        {
            List<Person> members = _service.Read();
            List<Person> peopleByBirthYearLess = members.Where(member => DateAgeUtility.ParseDate(member.DateOfBirth).Year < year).ToList();
            return peopleByBirthYearLess.ConvertAll(person => (PersonModel)person);
        }

        public List<PersonModel> GetPeopleByGender(Gender gender)
        {
            List<Person> members = _service.Read();
            List<Person> peopleByGender = members.Where(member => member.Gender == gender).ToList();
            return peopleByGender.ConvertAll(person => (PersonModel)person);
        }

        public List<PersonModel> GetAllPeople()
        {
            return _service.Read().ConvertAll(person => (PersonModel)person);
        }
    }
}