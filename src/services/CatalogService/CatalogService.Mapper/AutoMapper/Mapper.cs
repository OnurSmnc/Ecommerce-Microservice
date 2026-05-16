using AutoMapper;
using CatalogService.Application.Interfaces.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using IMapper = AutoMapper.IMapper;

namespace CatalogService.Mapper.AutoMapper
{
    public class Mapper : Application.Interfaces.AutoMapper.IMapper
    {
        private static List<(Type Source, Type Destination, string? Ignore)> _mappings = new();
        private IMapper _mapperContainer;

        public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
        {
            EnsureMapper<TSource, TDestination>(ignore);
            return _mapperContainer.Map<TDestination>(source);
        }

        public IList<TDestination> Map<TDestination, TSource>(IList<TSource> source, string? ignore = null)
        {
            EnsureMapper<TSource, TDestination>(ignore);
            return _mapperContainer.Map<IList<TDestination>>(source);
        }

        public TDestination Map<TDestination>(object source, string? ignore = null)
        {
            EnsureMapperForTypes(source.GetType(), typeof(TDestination), ignore);
            return _mapperContainer.Map<TDestination>(source);
        }

        public IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null)
        {
            if (source == null || !source.Any()) return new List<TDestination>();
            EnsureMapperForTypes(source.First().GetType(), typeof(TDestination), ignore);
            return _mapperContainer.Map<IList<TDestination>>(source);
        }

        public IList<TDestination> MapList<TDestination, TSource>(IList<TSource> source, string? ignore = null)
        {
            EnsureMapper<TSource, TDestination>(ignore);
            return _mapperContainer.Map<IList<TDestination>>(source);
        }

        private void EnsureMapper<TSource, TDestination>(string? ignore)
            => EnsureMapperForTypes(typeof(TSource), typeof(TDestination), ignore);

        private void EnsureMapperForTypes(Type sourceType, Type destType, string? ignore)
        {
            if (_mappings.Any(m => m.Source == sourceType && m.Destination == destType))
                return;

            _mappings.Add((sourceType, destType, ignore));
            RebuildMapper();
        }

        private void RebuildMapper()
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddAutoMapper(cfg =>
            {
                foreach (var (source, dest, ignore) in _mappings)
                {
                    var map = cfg.CreateMap(source, dest).MaxDepth(5);
                    if (ignore is not null)
                    {
                        map.ForAllMembers(o =>
                        {
                            if (o.DestinationMember.Name == ignore) o.Ignore();
                        });
                    }
                    map.ReverseMap();
                }
            });

            var serviceProvider = services.BuildServiceProvider();
            _mapperContainer = serviceProvider.GetRequiredService<IMapper>();
        }
    }
}