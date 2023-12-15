using AutoMapper;
using Microsoft.Ajax.Utilities;

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
            }
        );

            return mapperConfig;
        }
    }
}