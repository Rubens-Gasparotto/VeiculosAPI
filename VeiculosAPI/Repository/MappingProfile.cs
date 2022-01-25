using AutoMapper;
using VeiculosAPI.Repository.DTOs.Marca;
using VeiculosAPI.Repository.DTOs.Modelo;
using VeiculosAPI.Repository.DTOs.Permissao;
using VeiculosAPI.Repository.DTOs.Usuario;
using VeiculosAPI.Repository.Models;

namespace VeiculosAPI.Repository
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<MarcaCreateDTO, Marca>();
			CreateMap<MarcaEditDTO, Marca>();
			CreateMap<MarcaDTO, Marca>().ReverseMap();

			CreateMap<ModeloCreateDTO, Modelo>();
			CreateMap<ModeloEditDTO, Modelo>();
			CreateMap<ModeloDTO, Modelo>().ReverseMap();

			CreateMap<UsuarioCreateDTO, Usuario>();
			CreateMap<UsuarioEditDTO, Usuario>();
			CreateMap<UsuarioDTO, Usuario>().ReverseMap();
			CreateMap<UsuarioWithPermissaoDTO, Usuario>().ReverseMap();

			CreateMap<PermissaoCreateDTO, Permissao>();
			CreateMap<PermissaoEditDTO, Permissao>();
			CreateMap<PermissaoDTO, Permissao>().ReverseMap();
		}
	}
}
