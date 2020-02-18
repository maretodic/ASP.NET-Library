using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MVC_Library.Dto;
using MVC_Library.Models;
using System.Web;

namespace MVC_Library.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Member, MemberDto>();
            CreateMap<Book, BookDto>();

            CreateMap<MemberDto, Member>().ForMember(m => m.ID, opt => opt.Ignore());
            CreateMap<BookDto, Book>().ForMember(m => m.ID, opt => opt.Ignore());
        }
    }
}