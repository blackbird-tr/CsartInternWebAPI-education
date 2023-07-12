using CleanArchitecture.Core.Features.Merchants.Command.CreateMerchant;
using CleanArchitecture.Core.Features.Merchants.Command.DeleteMerchantById;
using CleanArchitecture.Core.Features.Merchants.Command.UpdateMerchant;
using CleanArchitecture.Core.Features.Merchants.Queries.GetAllMerchant;
using CleanArchitecture.Core.Features.Merchants.Queries.GetMerchantById;
using CleanArchitecture.Core.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using CleanArchitecture.Core.Features.MerchantProducts.Queries.GetAllMerchantProducts;
using CleanArchitecture.Core.Features.MerchantProducts.Commands.CreateMerchantProduct;
using CleanArchitecture.Core.Features.MerchantProducts.Commands.DeleteMerchantProductById;
using CleanArchitecture.Core.Features.MerchantProducts.Commands.UpdateMerchantProduct;
using CleanArchitecture.Core.Features.MerchantProducts.Queries.GetMerchantProductByMerchantId;
using CleanArchitecture.Core.Features.MerchantProducts.Queries.GetMerchantProductByProductId;

namespace CleanArchitecture.WebApi.Controllers.v1
{
    
      [ApiVersion("1.0")]
    public class MerchantProductController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResponse<IEnumerable<GetAllMerchantProductViewModel>>))]
        public async Task<PagedResponse<IEnumerable<GetAllMerchantProductViewModel>>> Get([FromQuery] GetAllMerchantProductParameter filter)
        {
            return await Mediator.Send(new GetAllMerchantProductQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber });
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetMerchantByIdQuery { Id = id }));
        }
        [HttpGet("GetProductsByMerchantId")]
        public async Task<IActionResult> GetProductsByMerchantId(int id)
        {
            return Ok(await Mediator.Send(new GetAllMerchantProductsByMerchantIdQuery { MerchantId = id }));
        }
        [HttpGet("GetProductsByProductId")]
        public async Task<IActionResult> GetProductsByProductId(int id)
        {
            return Ok(await Mediator.Send(new GetAllMerchantProductsByProductIdQuery { ProductId = id }));
        }

        // POST api/<controller>
        [HttpPost]

        public async Task<IActionResult> Post(CreateMerchantProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, UpdateMerchantProductCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteMerchantProductCommand { Id = id }));
        }
    }
}
