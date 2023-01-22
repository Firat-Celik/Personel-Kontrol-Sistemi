using AutoMapper;
using PersonelKontrol.Application.Dtos;
using PersonelKontrol.Application.DTOs;
using PersonelKontrol.Domain.Entities.Concrates;

namespace PersonelKontrol.Application.Mapping
{
    public sealed class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Personel, EmployeeInfoDto>();
            CreateMap<PersonelHareketleri, EmployeeMovementsInfoDto>();
            CreateMap<PersonelHareketleri, AddEmployeeMovementsDto>()
                .ForMember(destination => destination.Id, operation => operation.MapFrom(source => source.Id))
                .ForMember(destination => destination.Tarih, operation => operation.MapFrom(source => source.Tarih))
                .ForMember(destination => destination.GirisSaati, operation => operation.MapFrom(source => source.GirisSaati))
                .ForMember(destination => destination.CikisSaati, operation => operation.MapFrom(source => source.CikisSaati))
                .ForMember(destination => destination.AktifMi, operation => operation.MapFrom(source => source.AktifMi))
                .ForMember(destination => destination.OlusturulmaZamani, operation => operation.MapFrom(source => source.OlusturulmaZamani))
                .ForMember(destination => destination.DuzenlenmeZamani, operation => operation.MapFrom(source => source.DuzenlenmeZamani))
                .ForMember(destination => destination.SilindiMi, operation => operation.MapFrom(source => source.SilindiMi));
                 
    }
    }
}