using AutoMapper;
using Rezept.Api.Contracts;
using Rezept.Api.Services.Core;
using Rezept.Data.Entities;

namespace Api.Profiles;

public class RecipeProfile : Profile
{
    public RecipeProfile()
    {
        CreateMap<Recipe, RecipeListItem>()
            .ForMember(listItem => listItem.Serves,
                        options => options.MapFrom(source => source.RecipeServings));

        CreateMap<Recipe, RecipeListItem>();
    }
}
