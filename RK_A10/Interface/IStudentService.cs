using RK_A10.DTO;

namespace RK_A10.Interface
{
    public interface IStudentService
    {
        Task<StudentDTO> GetStudent(int id);

        Task<List<StudentDTO>> GetAllStudents();

        Task AddStudent(StudentDTO dto);

        Task UpdateStudent(int id, StudentDTO dto);

        Task DeleteStudent(int id);
    }
}