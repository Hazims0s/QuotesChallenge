using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.AutherDTOs;
using Application.DTOs.QuotesDTOs;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<Auther,AutherDTO>();
            CreateMap<AddAutherDTO,Auther>();
            CreateMap<Quote, QuoteDTO>();
            CreateMap<QuoteDTO, Quote>();
            CreateMap<AddQuoteDTO,Quote>();
        }
        
    }
}


/*

  public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
         //   CreateMap<Auther,AutherDTO>();
           // 
            CreateMap<Quote,QuoteDTO>(); 
             

*/