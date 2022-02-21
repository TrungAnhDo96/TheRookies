using RK_A9.DTO;
using RK_A9.Entities;
using RK_A9.Enums;

namespace RK_A9.Utilities
{
    public static class Utility
    {
        public static Person DTOToEntity(this PersonDTO dto)
        {
            var result = new Person()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DateOfBirth = DateTime.Parse(dto.DateOfBirth),
                Gender = dto.Gender,
                BirthPlace = dto.BirthPlace
            };
            return result;
        }

        public static PersonDTO EntityToDTO(this Person entity)
        {
            var result = new PersonDTO()
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                DateOfBirth = entity.DateOfBirth.ToString("dd/MM/yyyy"),
                Gender = entity.Gender,
                BirthPlace = entity.BirthPlace
            };
            return result;
        }
    }
}