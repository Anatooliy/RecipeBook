using AutoMapper;
using BLL.DTO;
using Web.API.Models;

namespace Web.API.Util
{
    public class ConfigureAutoMapper
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RecipeDTO, RecipeViewModel>().ForMember(rv => rv.NamesTree, dto => dto.MapFrom(r => r.NamesTree));
                cfg.CreateMap<NamesTreeNodeDTO, TreeNodeViewModel>();
            });

            return config.CreateMapper();
        }
    }
}