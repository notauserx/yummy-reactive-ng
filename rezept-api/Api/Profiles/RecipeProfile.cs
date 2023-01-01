using AutoMapper;
using Rezept.Api.Contracts;
using Rezept.Data.Entities;

namespace Api.Profiles;

public class RecipeProfile : Profile
{
    public RecipeProfile()
    {
        CreateMap<Recipe, RecipeListItem>();
        CreateMap<Recipe, RecipeListItem>()
            .ForMember(listItem => listItem.Serves,
                        options => options.MapFrom(source => source.RecipeServings))
            .ForMember(listItem => listItem.Category,
                        options => options.MapFrom(source => source.Category.Name));

    }
}
