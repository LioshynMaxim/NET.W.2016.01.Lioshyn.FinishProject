using AutoMapper;
using DAL.Interfacies.DTO;
using ORM;

namespace DAL.Mappers
{
    class FullAutoMapper
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(configuration => configuration.CreateMap<ORM.ClassRoom, ClassRoom>().ReverseMap());
            Mapper.Initialize(configuration => configuration.CreateMap<Comment, DalComment>().ReverseMap());
            Mapper.Initialize(configuration => configuration.CreateMap<Mail, DalMail>().ReverseMap());
            Mapper.Initialize(configuration => configuration.CreateMap<Parent, DalParent>().ReverseMap());
            Mapper.Initialize(configuration => configuration.CreateMap<Pupil, DalPupil>().ReverseMap());
            Mapper.Initialize(configuration => configuration.CreateMap<Requisition, DalRequisition>().ReverseMap());
            Mapper.Initialize(configuration => configuration.CreateMap<Role, DalRole>().ReverseMap());
            Mapper.Initialize(configuration => configuration.CreateMap<Teacher, DalTeacher>().ReverseMap());
            Mapper.Initialize(configuration => configuration.CreateMap<User, DalUser>().ReverseMap());
            
        }
    }
}
