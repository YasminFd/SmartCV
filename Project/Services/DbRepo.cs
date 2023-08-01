using Project.Data;
using Project.Models;

namespace Project.Services
{
    public class DbRepo
    {
        private readonly AppDBContext _context;
        public DbRepo(AppDBContext context)
        {
            _context = context;
        }
        public List<Resume> GetAllResumes()
        {
            return _context.resumes.ToList();
        }
        public async Task AddResume(Resume resume)
        {
            _context.resumes.Add(resume);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateResume(Resume resume)
        {
            _context.resumes.Update(resume);
            await _context.SaveChangesAsync();
        }
        public Resume GetResumeById(int? id)
        {
            return _context.resumes.FirstOrDefault(m =>m.ID == id);
        }
        public async Task DeleteResume(int? id)
        {
            var resume = GetResumeById(id);
            if (resume != null)
            {
                _context.resumes.Remove(resume);
                await _context.SaveChangesAsync();
            }
        }

    }
}
