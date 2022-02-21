using RK_A8.DTO;
using RK_A8.Entities;

namespace RK_A8.Utilities
{
    public static class Utility
    {
        public static WorkTask DTOToEntity(this WorkTaskDTO dto)
        {
            return new WorkTask() { Title = dto.Title, IsCompleted = dto.IsCompleted };
        }

        public static WorkTaskDTO EntityToDTO(this WorkTask entity)
        {
            return new WorkTaskDTO() { Title = entity.Title, IsCompleted = entity.IsCompleted };
        }
    }
}