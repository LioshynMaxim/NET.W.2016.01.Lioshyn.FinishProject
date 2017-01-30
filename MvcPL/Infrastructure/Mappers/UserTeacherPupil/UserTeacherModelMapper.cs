using BLL.Interfacies.Entities;
using MvcPL.Areas.Administrator.Models.Mersh;

namespace MvcPL.Infrastructure.Mappers.UserTeacherPupil
{
    public static class UserTeacherModelMapper
    {
        
        public static UserTeacherEntity ToBllUserTeacher(this UserTeacherModel model)
        {
            if (model == null) return null;
            return new UserTeacherEntity
            {
                User = model.User.ToDalUser(),
                Teacher = model.Teacher.ToBlllTeacher()
            };
        }

        
        public static UserTeacherModel ToUserTeacherModel(this UserTeacherEntity model)
        {
            if (model == null) return null;
            return new UserTeacherModel
            {
                User = model.User.ToUserModel(),
                Teacher = model.Teacher.ToTeacherModel()
            };
        }
    }
}