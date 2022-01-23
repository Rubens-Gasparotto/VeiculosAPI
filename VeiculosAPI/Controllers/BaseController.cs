using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VeiculosAPI.Services.BaseService.Interfaces;

namespace VeiculosAPI.Controllers
{
    public class BaseController<TModel, TDTO, TCreateDTO, TEditDTO> : ControllerBase
    {
        public IBaseService<TModel, TDTO, TCreateDTO, TEditDTO> service;
        public int usuarioId;
        public string slugPermissao;

        public BaseController(IBaseService<TModel, TDTO, TCreateDTO, TEditDTO> baseService)
        {
            service = baseService;
        }

        [HttpGet]
        [Produces("application/json")]
        public virtual ActionResult<List<TDTO>> GetAll()
        {
            if (!HasPermissao($"listar:{slugPermissao}"))
                return Forbid();

            return Ok(service.GetAll());
        }

        [HttpGet]
        [Route("{id:int}")]
        [Produces("application/json")]
        public virtual ActionResult<TDTO> Get([FromRoute] int id)
        {
            if (!HasPermissao($"visualizar:{slugPermissao}"))
                return Forbid();

            var item = service.Get(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        [Produces("application/json")]
        public virtual ActionResult<TDTO> Create([FromBody] TCreateDTO dados)
        {
            if (!HasPermissao($"criar:{slugPermissao}"))
                return Forbid();

            return Created("", service.Create(dados));
        }

        [HttpPut]
        [Route("{id:int}")]
        [Produces("application/json")]
        public virtual ActionResult<TDTO> Update([FromRoute] int id, [FromBody] TEditDTO dados)
        {
            if (!HasPermissao($"editar:{slugPermissao}"))
                return Forbid();

            if (!service.Exists(id))
                return NotFound();

            return Ok(service.Update(id, dados));
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Produces("application/json")]
        public virtual ActionResult<bool> Delete([FromRoute] int id)
        {
            if (!HasPermissao($"remover:{slugPermissao}"))
                return Forbid();

            if (!service.Exists(id))
                return NotFound();

            return Ok(service.Delete(id));
        }

        public virtual bool HasPermissao(string slug)
        {
            return service.GetPermissoes(usuarioId).Any(permissao => permissao.Slug == slug);
        }
    }
}
