using RK_A7.Models;

namespace RK_A7.Interfaces
{
    public interface IPeopleService
    {
        List<PersonModel> GetAllPeople();

        PersonModel GetPerson(int id);

        void AddPerson(PersonModel model);

        void EditPerson(int id, PersonModel model);

        void DeletePerson(int id);
    }
}