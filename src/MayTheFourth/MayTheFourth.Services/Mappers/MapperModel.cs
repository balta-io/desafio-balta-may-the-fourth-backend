using AutoMapper;

namespace MayTheFourth.Services.Mappers
{
    public static class MapperModel
    {
        private static IMapper? _IMapper { get; set; }

        public static void SetMapper(IMapper pMapper)
        {
            if (MapInstance != null)
                throw new ArgumentNullException("Deve ser instanciado apenas uma vez");

            _IMapper = pMapper;
        }

        public static IMapper? MapInstance { get => _IMapper; }


        public static TDestination Map<TDestination>(object source)
        {
            if (MapInstance == null)
                throw new ArgumentNullException("Instancia do mapper não encontrada.");

            return MapInstance.Map<TDestination>(source);
        }

        public static TDestination Map<TDestination>(object source, Action<IMappingOperationOptions<object, TDestination>> opts)
        {
            if (MapInstance == null)
                throw new ArgumentNullException("Instancia do mapper não encontrada.");

            return MapInstance.Map(source, opts);
        }

        public static TDestination Map<TSource, TDestination>(TSource source)
        {
            if (MapInstance == null)
                throw new ArgumentNullException("Instancia do mapper não encontrada.");

            return MapInstance.Map<TSource, TDestination>(source);
        }

        public static TDestination Map<TSource, TDestination>(TSource source, Action<IMappingOperationOptions<TSource, TDestination>> opts)
        {
            if (MapInstance == null)
                throw new ArgumentNullException("Instancia do mapper não encontrada.");

            return MapInstance.Map(source, opts);
        }

        public static TDestination Map<TSource, TDestination>(TSource source, TDestination destination, Action<IMappingOperationOptions<TSource, TDestination>> opts)
        {
            if (MapInstance == null)
                throw new ArgumentNullException("Instancia do mapper não encontrada.");

            return MapInstance.Map(source, destination, opts);
        }
    }
}
