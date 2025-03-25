using U2_S7_Lezioni.Data;
using U2_S7_Lezioni.Models;
using Microsoft.EntityFrameworkCore;
using U2_S7_Lezioni.DTOs;

namespace U2_S7_Lezioni.Servicies
{
    public class StudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> AddAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> GetByIdAsync(Guid id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Student?> UpdateAsync(Guid id, StudentUpdateDTO dto)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return null;

            student.Nome = dto.Nome;
            student.Cognome = dto.Cognome;
            student.Email = dto.Email;

            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return false;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}