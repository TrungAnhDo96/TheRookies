using RK_A9.DTO;
using RK_A9.Enums;

namespace RK_A9.Interface
{
    public interface IPersonService
    {
        void AddPerson(PersonDTO dto);

        void UpdatePerson(int id, PersonDTO dto);

        void DeletePerson(int id);

        List<PersonDTO> GetAllPeople();

        List<PersonDTO> Filter(FilterPersonDTO filterDTO);
    }
}