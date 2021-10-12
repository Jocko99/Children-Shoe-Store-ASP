using Application;
using Application.DataTransfer;
using AutoMapper;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Profiles
{
    public class RatingProfile : Profile
    {

        public RatingProfile() 
        {
            
            CreateMap<Rating, RatingDto>();
            
        }

        
    }
}
