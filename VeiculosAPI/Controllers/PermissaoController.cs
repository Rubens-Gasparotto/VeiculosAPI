﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VeiculosAPI.Repository.DTOs.Permissao;
using VeiculosAPI.Repository.Models;
using VeiculosAPI.Services.PermissaoService.Interfaces;

namespace VeiculosAPI.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize]
    [Route("v{version:apiVersion}/permissoes")]
    public class PermissaoController : BaseController<Permissao, PermissaoDTO, PermissaoCreateDTO, PermissaoEditDTO>
    {
        public PermissaoController(IPermissaoService service) : base(service) { }

        [HttpPost]
        [NonAction]
        public override ActionResult<PermissaoDTO> Create([FromBody] PermissaoCreateDTO dados)
        {
            return base.Create(dados);
        }

        [HttpPut]
        [Route("{id:int}")]
        [NonAction]
        public override ActionResult<PermissaoDTO> Update([FromRoute] int id, [FromBody] PermissaoEditDTO dados)
        {
            return base.Update(id, dados);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [NonAction]
        public override ActionResult<bool> Delete([FromRoute] int id)
        {
            return base.service.Delete(id);
        }
    }
}
