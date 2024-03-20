using AutoMapper;

namespace personal.blog.api.mapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
           
            //CreateMap<User, UserExcelDto>()
            //     .ForMember(x => x.Age, ops => ops.MapFrom(x => x.BirthDay.HasValue ? DateTime.Now.Year - x.BirthDay.Value.Year : 0))
            //     .ForMember(x => x.BirthDay, ops => ops.MapFrom(x => x.BirthDay.HasValue ? x.BirthDay.Value.ToString("yyyy-MM-dd") : ""))
            //     .ForMember(x => x.RegisterTime, ops => ops.MapFrom(x => x.RegisterTime.HasValue ? x.RegisterTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : ""))
            //     .ForMember(x => x.HasResume, ops => ops.MapFrom(x => string.IsNullOrWhiteSpace(x.ResumeFileName) ? "否" : "是"));
        
        }
    }
}
