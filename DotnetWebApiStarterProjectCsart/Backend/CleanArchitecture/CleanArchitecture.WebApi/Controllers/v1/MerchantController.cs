using CleanArchitecture.Core.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using CleanArchitecture.Core.Features.Merchants.Queries.GetAllMerchant;
using CleanArchitecture.Core.Features.Merchants.Queries.GetMerchantById;
using CleanArchitecture.Core.Features.Merchants.Command.CreateMerchant;
using CleanArchitecture.Core.Features.Merchants.Command.DeleteMerchantById;
using CleanArchitecture.Core.Features.Merchants.Command.UpdateMerchant;

namespace CleanArchitecture.WebApi.Controllers.v1
{
     
        [ApiVersion("1.0")]
        public class MerchantController : BaseApiController
        {
            // GET: api/<controller>
            [HttpGet]
            [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResponse<IEnumerable<GetAllMerchantViewModel>>))]
            public async Task<PagedResponse<IEnumerable<GetAllMerchantViewModel>>> Get([FromQuery] GetAllMerchantParameter filter)
            {
                return await Mediator.Send(new GetAllMerchantQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber });
            }

            // GET api/<controller>/5
            [HttpGet("{id}")]
            public async Task<IActionResult> Get(int id)
            {
                return Ok(await Mediator.Send(new GetMerchantByIdQuery { Id = id }));
            }

            // POST api/<controller>
            [HttpPost]

            public async Task<IActionResult> Post(CreateMerchantCommand command)
            {
                return Ok(await Mediator.Send(command));
            }

            // PUT api/<controller>/5
            [HttpPut("{id}")]

            public async Task<IActionResult> Put(int id, UpdateMerchantCommand command)
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
                return Ok(await Mediator.Send(new DeleteMerchantByIdCommand { Id = id }));
            }
        }
    }
