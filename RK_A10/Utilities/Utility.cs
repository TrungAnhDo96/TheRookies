using RK_A10.Entities;
using RK_A10.DTO;

namespace RK_A10.Utilities
{
    public static class Utility
    {
        public static StudentDTO EntityToDTO(this Student entity)
        {
            return new StudentDTO()
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                City = entity.City,
                State = entity.State
            };
        }

        public static Student DTOToEntity(this StudentDTO dto)
        {
            return new Student()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                City = dto.City,
                State = dto.State
            };
        }
    }
}