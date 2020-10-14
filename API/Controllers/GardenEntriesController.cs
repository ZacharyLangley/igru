using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.GardenEntries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    public class GardenEntriesController : BaseController
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<GardenEntryDto>>> List()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GardenEntryDto>> Details(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Unit>> Edit(Guid id, Edit.Command command)
        {
            command.Id = id;
            return await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await Mediator.Send(new Delete.Command{Id = id});
        }
    }
}