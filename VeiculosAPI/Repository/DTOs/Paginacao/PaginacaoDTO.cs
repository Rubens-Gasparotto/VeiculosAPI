using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VeiculosAPI.Repository.DTOs.Paginacao
{
    public class PaginacaoDTO
    {
        [Required]
        public Nullable<int> Pagina { get; set; }
        [Required]
        public Nullable<int> ItensPagina { get; set; }
    }
    public class PaginacaoResponseDTO<T>
    {
        public int Pagina { get; set; }
        public int ItensPagina { get; set; }
        public int TotalItens { get; set; }
        public int UltimaPagina { get; set; }
        public List<T> Itens { get; set; }
    }
}
