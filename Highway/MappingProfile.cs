using AutoMapper;
using Highway.Controllers;
using Highway.Entities;
using Highway.Models.CategoryModel;
using Highway.Models.EmployeeModels;
using Highway.Models.IncomesModel;
using Highway.Models.LocationModel;
using Highway.Models.PriceModel;
using Highway.Models.TollBoothModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Highway
{
    public class MappingProfile: Profile
    {
       public  MappingProfile()
        {
            CreateMap<CategoryForCreationDto, Category>();
            CreateMap<Employee, EmployeeDto>().ForMember(d => d.Name, s => s.MapFrom(source => source.FirstName + " " + source.LastName));
           
            CreateMap<Location, LocationDto>();

            CreateMap<Price, PriceDto>();
            CreateMap<PriceDto, Price>();
            CreateMap<PriceForCreationDto,Price>();
            
            CreateMap<Incomes, IncomeDto>();
            CreateMap<IncomesForCreationDto,Incomes>();
            
            CreateMap<TollboothForCreationDto, TollBooth>();


        }
    }
}
