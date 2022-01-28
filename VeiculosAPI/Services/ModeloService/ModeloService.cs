using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VeiculosAPI.Repository;
using VeiculosAPI.Repository.DTOs.Modelo;
using VeiculosAPI.Repository.DTOs.Paginacao;
using VeiculosAPI.Repository.Models;
using VeiculosAPI.Services.BaseService;
using VeiculosAPI.Services.ModeloService.Interfaces;

namespace VeiculosAPI.Services.ModeloService
{
    public class ModeloService : BaseService<Modelo, ModeloDTO, ModeloCreateDTO, ModeloEditDTO>, IModeloService
    {
        public ModeloService(VeiculosDb context, IMapper mapper) : base(context, mapper) { }

        public override async Task<List<ModeloDTO>> GetAll()
        {
            var modelos = await dbSet.Include(c => c.Marca).ToListAsync();

            return mapper.Map<List<Modelo>, List<ModeloDTO>>(modelos);
        }

        public override async Task<PaginacaoResponseDTO<ModeloDTO>> GetAllPaginate(PaginacaoDTO dadosPaginacao)
        {
            var pagina = dadosPaginacao.Pagina.Value;
            var itensPagina = dadosPaginacao.ItensPagina.Value;

            var items = await dbSet.Skip((pagina - 1) * itensPagina).Take(itensPagina).Include(c => c.Marca).Where(c => c.DeletedAt == null).ToListAsync();

            var totalItens = await dbSet.Where(c => c.DeletedAt == null).CountAsync();

            return new PaginacaoResponseDTO<ModeloDTO>
            {
                Pagina = pagina,
                ItensPagina = itensPagina,
                TotalItens = totalItens,
                UltimaPagina = (int)Math.Ceiling((decimal)totalItens / itensPagina),
                Itens = mapper.Map<List<Modelo>, List<ModeloDTO>>(items)
            };
        }

        public override async Task<ModeloDTO> Get(int id)
        {
            var modelo = await dbSet.Include(c => c.Marca).FirstOrDefaultAsync(c => c.Id == id);

            return mapper.Map<Modelo, ModeloDTO>(modelo);
        }

        public override async Task<ModeloDTO> Create(ModeloCreateDTO dados)
        {
            string logoPath = await SaveImagem(dados.Imagem);

            var dadosSalvos = await dbSet.AddAsync(new Modelo
            {
                Nome = dados.Nome,
                InicioFabricacao = dados.InicioFabricacao,
                FimFabricacao = dados.FimFabricacao,
                MarcaId = dados.MarcaId,
                Imagem = "modelos/" + logoPath
            });

            await Save();

            return mapper.Map<Modelo, ModeloDTO>(dadosSalvos.Entity);
        }

        public override async Task<ModeloDTO> Update(int id, ModeloEditDTO dados)
        {
            Modelo original = await dbSet.AsNoTracking().FirstAsync(c => c.Id == id);

            Modelo editarDado = mapper.Map<ModeloEditDTO, Modelo>(dados);

            editarDado.Id = original.Id;
            editarDado.CreatedAt = original.CreatedAt;

            if (dados.Imagem != null && dados.Imagem.Length > 0)
            {
                RemoverImagem(original.Imagem);

                editarDado.Imagem = await SaveImagem(dados.Imagem);
            }
            else
            {
                editarDado.Imagem = original.Imagem;
            }

            dbSet.Update(editarDado);

            await Save();

            return mapper.Map<Modelo, ModeloDTO>(editarDado);
        }

        private static async Task<string> SaveImagem(IFormFile file)
        {
            if (!Directory.Exists("wwwroot/modelos/"))
                Directory.CreateDirectory("wwwroot/modelos/");

            if (file.Length > 0)
            {
                string path = ((int)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds).ToString() + Path.GetExtension(file.FileName);

                using var stream = File.Create("wwwroot/modelos/" + path);
                await file.CopyToAsync(stream);

                return "modelos/" + path;
            }
            else
            {
                throw new Exception("Falha ao ler arquivo logo.");
            }
        }
        private static void RemoverImagem(string path)
        {
            if (File.Exists("wwwroot/" + path))
                File.Delete("wwwroot/" + path);
        }
    }
}
