using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using VeiculosAPI.Repository;
using VeiculosAPI.Repository.DTOs.Marca;
using VeiculosAPI.Repository.Models;
using VeiculosAPI.Services.BaseService;
using VeiculosAPI.Services.MarcaService.Interfaces;

namespace VeiculosAPI.Services.MarcaService
{
    public class MarcaService : BaseService<Marca, MarcaDTO, MarcaCreateDTO, MarcaEditDTO>, IMarcaService
    {
        public MarcaService(VeiculosDb context, IMapper mapper) : base(context, mapper) { }

        public override async Task<MarcaDTO> Create(MarcaCreateDTO dados)
        {
            string logoPath = await SaveImagem(dados.Logo);

            var dadosSalvos = await dbSet.AddAsync(new Marca
            {
                Nome = dados.Nome,
                Logo = "marcas/" + logoPath
            });

            await Save();

            return mapper.Map<Marca, MarcaDTO>(dadosSalvos.Entity);
        }

        public override async Task<MarcaDTO> Update(int id, MarcaEditDTO dados)
        {
            Marca original = await dbSet.AsNoTracking().FirstAsync(c => c.Id == id);

            Marca editarDado = mapper.Map<MarcaEditDTO, Marca>(dados);

            editarDado.Id = original.Id;
            editarDado.CreatedAt = original.CreatedAt;

            if (dados.Logo != null && dados.Logo.Length > 0)
            {
                RemoverImagem(original.Logo);

                editarDado.Logo = await SaveImagem(dados.Logo);
            } else
            {
                editarDado.Logo = original.Logo;
            }

            dbSet.Update(editarDado);

            await Save();

            return mapper.Map<Marca, MarcaDTO>(editarDado);
        }

        private static async Task<string> SaveImagem(IFormFile file)
        {
            if (file.Length > 0)
            {
                string path = ((int)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds).ToString() + Path.GetExtension(file.FileName);

                using var stream = File.Create("wwwroot/marcas/" + path);
                await file.CopyToAsync(stream);

                return "marcas/" + path;
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
