using BLL.Interfacies.Entities;
using MvcPL.Areas.Administrator.Models.Mersh;

namespace MvcPL.Infrastructure.Mappers.UserTeacherPupil
{
    public static class UserPupilModelMapper
    {

        public static UserPupilEntity ToBllUserPupil(this UserPupilModel model)
        {
            if (model == null) return null;
            return new UserPupilEntity
            {
                User = model.User.ToDalUser(),
                Pupil = model.Pupil.ToBllPupil()
            };
        }


        public static UserPupilModel ToUserPupilModel(this UserPupilEntity model)
        {
            if (model == null) return null;
            return new UserPupilModel
            {
                User = model.User.ToUserModel(),
                Pupil = model.Pupil.ToPupilModel()
            };
        }

    }
}