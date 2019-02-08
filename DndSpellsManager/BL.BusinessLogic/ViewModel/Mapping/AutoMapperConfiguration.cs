using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.BusinessLogic.ViewModel.Mapping
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
            });
        }
    }
}
