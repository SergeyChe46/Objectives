using AutoMapper;
using Objectives.Models;
using Objectives.Models.ViewModels;

namespace Objectives.Helpers.Mapping
{
    public class PerformerMapping
    {
        public static Performer PerformerMapper(PerformerViewModel performerViewModel)
        {
            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<PerformerViewModel, Performer>()
                .ForMember(dst => dst.UserName, src => src.MapFrom(src => src.Name))
                );

            Performer newPerformer = new Mapper(config)
                .Map<Performer>(performerViewModel);

            return newPerformer;
        }
    }
}
