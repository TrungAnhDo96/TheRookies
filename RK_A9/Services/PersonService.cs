using RK_A9.DB;
using RK_A9.DTO;
using RK_A9.Entities;
using RK_A9.Interface;
using RK_A9.Utilities;

namespace RK_A9.Services
{
    public class PersonService : IPersonService
    {
        private PeopleContext _context;

        public PersonService(PeopleContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public void AddPerson(PersonDTO dto)
        {
            _context.Add(dto.DTOToEntity());
            _context.SaveChanges();
        }

        public void DeletePerson(int id)
        {
            Person foundPerson = _context.People.Find(id);
            if (foundPerson != null)
            {
                _context.People.Remove(foundPerson);
                _context.SaveChanges();
            }
        }

        public void UpdatePerson(int id, PersonDTO person)
        {
            Person personToUpdate = _context.People.Find(id);
            if (personToUpdate != null)
            {
                personToUpdate = person.DTOToEntity();
                personToUpdate.Id = id;
                _context.People.Update(personToUpdate);
                _context.SaveChanges();
            }
        }

        public List<PersonDTO> GetAllPeople()
        {
            List<PersonDTO> allPeople = _context.People.Select(person => person.EntityToDTO()).ToList();
            return allPeople;
        }

        public List<PersonDTO> Filter(FilterPersonDTO filterDTO)
        {
            var filteredList = _context.People.Where(person =>
               (!string.IsNullOrEmpty(filterDTO.FirstName) && person.FirstName.ToLower() == filterDTO.FirstName.ToLower()) ||
               (!string.IsNullOrEmpty(filterDTO.FirstName) && person.LastName.ToLower() == filterDTO.LastName.ToLower()) ||
               person.Gender == filterDTO.Gender ||
               (!string.IsNullOrEmpty(filterDTO.BirthPlace) && person.BirthPlace.ToLower() == filterDTO.BirthPlace.ToLower())
            );

            return filteredList.Select(entity => entity.EntityToDTO()).ToList();
        }
    }
}