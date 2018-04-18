using CqrsMediatREFDapper.Domain.CourseContext.Models;
using CqrsMediatREFDapper.Domain.SharedContext.Interfaces.Repositories;

namespace CqrsMediatREFDapper.Domain.CourseContext.Interfaces.Repositories
{
    public interface ICourseReadOnlyRepository : IReadOnlyRepository<Course>
    {
    }
}
