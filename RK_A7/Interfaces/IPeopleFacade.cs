using RK_A7.Models;
using RK_A7.Enums;
using System.Data;

namespace RK_A7.Interfaces
{
    public interface IPeopleFacade
    {
        List<PersonModel> GetAllPeople();

        PersonModel GetPerson(uint id);

        void AddPerson(PersonModel model);

        void EditPerson(PersonModel model);

        void DeletePerson(PersonModel model);
    }
}