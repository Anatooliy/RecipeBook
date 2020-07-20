using AutoMapper;
using BLL.DTO;
using Web.API.Models;

namespace Web.API.Util
{
    public class ConfigureAutoMapper
    {
        public IMapper GetDtoToViewMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RecipeDTO, RecipeViewModel>().ForMember(rv => rv.NamesTree, dto => dto.MapFrom(r => r.NamesTree));
                cfg.CreateMap<NamesTreeNodeDTO, TreeNodeViewModel>();
            });

            return config.CreateMapper();
        }

        public IMapper GetViewToDtoMapper()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<RecipeViewModel, RecipeDTO>()).CreateMapper();
        }
    }
}