using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Authers.Commands;
using Application.Authers.Queries;
using Application.DTOs.AutherDTOs;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class AuthresController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetListAuthers(CancellationToken ct)
        {

            return HandelResult( await Mediator.Send(new GetListAuthers.Query(),ct));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuther(Guid id,CancellationToken ct)
        {
            return HandelResult(await Mediator.Send(new GetAuther.Query{Id=id},ct)) ; 

        }

         [HttpPost("Add")]
        public async Task<IActionResult> AddAuther(AddAutherDTO auther ,CancellationToken ct)
        {
           return HandelResult( await Mediator.Send(new AddAuther.Command{Auther =auther} ,ct));
            
        }

        
        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> EditAuther(Guid id,AutherDTO auther,CancellationToken ct)
        {
            auther.Id=id; 
            
            await Mediator.Send(new UpdateAuther.Command{Auther =auther},ct );
            return Ok(); 
        }
        
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> RemoveAuther(Guid id,CancellationToken ct)
        {
            await Mediator.Send(new DeleteAuther.Command{Id=id} ,ct);
            return Ok(); 
        }
    }
}