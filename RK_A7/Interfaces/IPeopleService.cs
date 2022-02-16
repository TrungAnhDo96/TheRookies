using RK_A7.Entities;
using RK_A7.Models;

namespace RK_A7.Interfaces
{
    public interface IPeopleService
    {
        void OpenCon();

        void CloseCon();

        Dictionary<uint, Person> Read();

        Person Get(uint id);

        void Create(PersonModel model);

        bool Update(uint id, PersonModel model);

        bool Delete(uint id);
    }
}