using AutoMapper;
using VeiculosAPI.Repository.DTOs.Marca;
using VeiculosAPI.Repository.DTOs.Modelo;
using VeiculosAPI.Repository.DTOs.Permissao;
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
            CreateMap<Marca, MarcaDTO>();

			CreateMap<ModeloCreateDTO, Modelo>();
			CreateMap<ModeloEditDTO, Modelo>();
			CreateMap<ModeloDTO, Modelo>();
			CreateMap<Modelo, ModeloDTO>();

			CreateMap<UsuarioCreateDTO, Usuario>();
			CreateMap<UsuarioEditDTO, Usuario>();
			CreateMap<UsuarioDTO, Usuario>();
			CreateMap<Usuario, UsuarioDTO>();

			CreateMap<PermissaoCreateDTO, Permissao>();
			CreateMap<PermissaoEditDTO, Permissao>();
			CreateMap<PermissaoDTO, Permissao>();
			CreateMap<Permissao, PermissaoDTO>();
		}
	}
}
