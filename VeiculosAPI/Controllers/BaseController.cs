using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VeiculosAPI.Services.BaseService.Interfaces;

namespace VeiculosAPI.Controllers
{
    public class BaseController<TModel, TDTO, TCreateDTO, TEditDTO> : ControllerBase
    {
        public IBaseService<TModel, TCreateDTO, TEditDTO> service;

        public BaseController(IBaseService<TModel, TCreateDTO, TEditDTO> baseService)
        {
            service = baseService;
        }

        [HttpGet]
        [Produces("application/json")]
        public virtual ActionResult<List<TDTO>> GetAll()
        {
            return Ok(service.GetAll());
        }

        [HttpGet]
        [Route("{id:int}")]
        [Produces("application/json")]
        public virtual ActionResult<TDTO> Get([FromRoute] int id)
        {
            var item = service.Get(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        [Produces("application/json")]
        public virtual ActionResult<TDTO> Create([FromBody] TCreateDTO dados)
        {
            return Created("", service.Create(dados));
        }

        [HttpPut]
        [Route("{id:int}")]
        [Produces("application/json")]
        public virtual ActionResult<TDTO> Update([FromRoute] int id, [FromBody] TEditDTO dados)
        {
            if (!service.Exists(id))
                return NotFound();

            return Ok(service.Update(id, dados));
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Produces("application/json")]
        public virtual ActionResult<bool> Delete([FromRoute] int id)
        {
            if (!service.Exists(id))
                return NotFound();

            return Ok(service.Delete(id));
        }
    }
}
