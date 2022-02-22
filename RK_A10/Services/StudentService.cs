using RK_A10.DB;
using RK_A10.DTO;
using RK_A10.Interface;
using RK_A10.Utilities;
using Microsoft.EntityFrameworkCore;

namespace RK_A10.Services
{
    public class StudentService : IStudentService
    {
        private StudentContext _context;
        public StudentService(StudentContext context)
        {
            _context = context;
        }

        public async Task AddStudent(StudentDTO dto)
        {
            await _context.Students.AddAsync(dto.DTOToEntity());
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudent(int id)
        {
            var studentToDelete = await _context.Students.FindAsync(id);
            if (studentToDelete != null)
            {
                _context.Students.Remove(studentToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<StudentDTO> GetStudent(int id)
        {
            var foundStudent = await _context.Students.FindAsync(id);
            if (foundStudent != null)
                return foundStudent.EntityToDTO();
            return null;
        }

        public async Task<List<StudentDTO>> GetAllStudents()
        {
            return await _context.Students.Select(student => student.EntityToDTO()).ToListAsync();
        }

        public async Task UpdateStudent(int id, StudentDTO dto)
        {
            var studentToEdit = await _context.Students.FindAsync(id);
            if (studentToEdit != null)
            {
                studentToEdit = dto.DTOToEntity();
                studentToEdit.StudentId = id;
                _context.Students.Update(studentToEdit);
                await _context.SaveChangesAsync();
            }
        }
    }
}