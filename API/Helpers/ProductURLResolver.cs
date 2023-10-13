using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class ProductURLResolver : IValueResolver<Product, ProductToReturnDTO, string>
    {
        private readonly IConfiguration _config;

        public ProductURLResolver(IConfiguration config)
        {
            _config = config;    
        }

        
        public string Resolve(Product source, ProductToReturnDTO destination, string destMember, ResolutionContext context)
        {
            //Check if PictureURL is empty
            if(!string.IsNullOrEmpty(source.PictureUrl)) {
                return _config["ApiURL"] + source.PictureUrl;
            }

            return null;
        }
    }
}