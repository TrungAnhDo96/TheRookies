using RK_A6.Entities;
using RK_A6.Models;

namespace RK_A6.Interfaces
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