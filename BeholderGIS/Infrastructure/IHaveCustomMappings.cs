using AutoMapper;

namespace BeholderGIS.Infrastructure
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration config);
    }
}