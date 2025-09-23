using AutoMapper;

namespace MfiManager.Middleware.Helpers {
    public class MappingProfile : Profile {
        public MappingProfile() {
            //CreateMap<Source, Destination>()
            //    .AfterMap((src, dest, context) => {
            //        // You can access your logger through the resolution context
            //        var logger = context.Items["Logger"] as IServiceLogger;
            //        logger?.Log($"Mapped {src.GetType().Name} to {dest.GetType().Name}");
            //    });
        }
    }
}
