using System;
using AutoMapper;

namespace EasyStore.Application.Interfaces.Mapping
{
    public interface ICustomMapping
    {
        void CreateMappings(Profile configuration);
    }
}
