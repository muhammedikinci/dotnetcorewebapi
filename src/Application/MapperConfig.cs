using Domain.ValueObjects;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace Application
{
    public class MapperConfig : Profile
    {
        public static Dictionary<Type, Type> _mappings;

        public class CounterToListFormatter<T> : IValueConverter<Counter<T>, List<T>>
        {
            public List<T> Convert(Counter<T> sourceMember, ResolutionContext context)
                => sourceMember.CounterList;
        }

        public class ListToCounterFormatter<T> : IValueConverter<List<T>, Counter<T>>
        {
            Counter<T> IValueConverter<List<T>, Counter<T>>.Convert(List<T> sourceMember, ResolutionContext context)
            {
                return new Counter<T>() { TotalCount = sourceMember.Count, CounterList = sourceMember };
            }
        }

        public MapperConfig()
        {
            var counterToListFormatter = new CounterToListFormatter<string>();
            var listToCounterFormatter = new ListToCounterFormatter<string>();

            CreateMap<Models.Ogretmen, Domain.Entities.Ogretmen>()
                    .ForMember(b => b.Okullar, opt => opt.ConvertUsing(listToCounterFormatter, "Okullar"));

            CreateMap<Domain.Entities.Ogretmen, Models.Ogretmen>()
                    .ForMember(b => b.Okullar, opt => opt.ConvertUsing(counterToListFormatter, "Okullar"));

            CreateMap<Models.Ogrenci, Domain.Entities.Ogrenci>()
                    .ForMember(b => b.Okullar, opt => opt.ConvertUsing(listToCounterFormatter, "Okullar"))
                    .ForMember(b => b.Ogretmenler, opt => opt.ConvertUsing(listToCounterFormatter, "Ogretmenler"));

            CreateMap<Domain.Entities.Ogrenci, Models.Ogrenci>()
                    .ForMember(b => b.Okullar, opt => opt.ConvertUsing(counterToListFormatter, "Okullar"))
                    .ForMember(b => b.Ogretmenler, opt => opt.ConvertUsing(counterToListFormatter, "Ogretmenler"));

            CreateMap<Domain.Entities.Okul, Models.Okul>();
            CreateMap<Models.Okul, Domain.Entities.Okul>();
            CreateMap<Models.OkulUpdate, Domain.Entities.Okul>();
        }
    }
}
