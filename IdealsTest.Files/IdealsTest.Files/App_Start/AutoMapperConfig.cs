using System;
using AutoMapper;
using DAL.Entities;
using IdealsTest.Core.Models;
using IdealsTest.Files.Models;

namespace IdealsTest.Files
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Create()
        {
            return new MapperConfiguration(cfg => {
                cfg.CreateMap<FileInfoViewModel, FileInformation>().ForMember(s => s.Id, t => t.Ignore());
                cfg.CreateMap<FileInformation, FileInfo>().ForMember(s => s.Id, t => t.MapFrom(src => Guid.NewGuid()));
                cfg.CreateMap<FileInfo, FileInformation>();
            });
        }
    }
}