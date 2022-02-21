using RK_A8.DTO;
using RK_A8.Entities;

namespace RK_A8.Utilities
{
    public static class Utility
    {
        public static WorkTask DTOToEntity(this DTOTask dto)
        {
            return new WorkTask() { Title = dto.Title, IsCompleted = dto.IsCompleted };
        }

        public static DTOTask EntityToDTO(this WorkTask entity)
        {
            return new DTOTask() { Title = entity.Title, IsCompleted = entity.IsCompleted };
        }
    }
}