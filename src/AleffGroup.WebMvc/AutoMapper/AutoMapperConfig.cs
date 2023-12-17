using AleffGroup.WebMvc.AutoMapper.Profiles;
using AutoMapper;

namespace AleffGroup.WebMvc.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            var mapperConfig = new MapperConfiguration(
            config =>
            {
                config.AddProfile<UserProfile>();
                config.AddProfile<LogAccessProfile>();
            }
        );

            return mapperConfig;
        }
    }
}