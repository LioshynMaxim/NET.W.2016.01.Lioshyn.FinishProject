using System.Collections.Generic;
using BLL.Interfacies.Entities;

namespace BLL.Interfacies.Services
{
    public interface IFullTeacherService
    {
        IEnumerable<FullTeacherEntity> GetAllTeacher();
        FullTeacherEntity SetFullTeacher(int idTeacher);
    }
}