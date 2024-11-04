using AutoMapper;
using Backend.DTOs;
using Backend.Models;

namespace Backend.Automappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            // si las campos tienen el mismo nombre bastaria. 
            CreateMap<BeerInsertDto, Beer>().
            ForMember(destino => destino.BeerName, origen => origen.MapFrom(BeerDto => BeerDto.Name));
            //objeto origen 
            //objeto destino cuando tenen el mismo nombre
            // Creando mapper en caso tengan nombre diferente los campos
            CreateMap<Beer, BeerDto>(). 
                ForMember(destino => destino.Id, origen => origen.MapFrom(beerModel => beerModel.BeerId)).
                ForMember(destino => destino.Name, origen => origen.MapFrom(beerModel => beerModel.BeerName));

            CreateMap<BeerUpdateDto, Beer>().ForMember(destino => destino.BeerName, origen => origen.MapFrom(beerModel => beerModel.Name));
        }
    }
}