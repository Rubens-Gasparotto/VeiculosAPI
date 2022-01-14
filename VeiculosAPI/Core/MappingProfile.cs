﻿using AutoMapper;
using VeiculosAPI.Repository.DTOs.Marca;
using VeiculosAPI.Repository.DTOs.Modelo;
using VeiculosAPI.Repository.DTOs.Usuario;
using VeiculosAPI.Repository.Models;

namespace VeiculosAPI.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MarcaCreateDTO, Marca>();
            CreateMap<MarcaEditDTO, Marca>();
            CreateMap<MarcaDTO, Marca>();

            CreateMap<ModeloCreateDTO, Modelo>();
            CreateMap<ModeloEditDTO, Modelo>();
            CreateMap<ModeloDTO, Modelo>();

            CreateMap<UsuarioCreateDTO, Usuario>();
            CreateMap<UsuarioEditDTO, Usuario>();
            CreateMap<UsuarioDTO, Usuario>();
        }
    }
}