﻿using System.Threading.Tasks;
using Calabonga.Microservice.IdentityModule.Web.Infrastructure.ViewModels.AccountViewModels;
using Calabonga.Microservice.IdentityModule.Web.Mediator.Account;
using Calabonga.Microservice.IdentityModule.Web.ViewModels.AccountViewModels;
using Calabonga.OperationResultsCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Calabonga.Microservice.IdentityModule.Web.Controllers
{
    /// <summary>
    /// Account Controller
    /// </summary>
    [Route("api/[controller]")]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Register controller
        /// </summary>
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Register new user. Success registration returns UserProfile for new user.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        [AllowAnonymous]
        [ProducesResponseType(200, Type = typeof(OperationResult<UserProfileViewModel>))]
        public async Task<ActionResult<OperationResult<UserProfileViewModel>>> Register(RegisterViewModel model)
        {
            return Ok(await _mediator.Send(new RegisterRequest(model), HttpContext.RequestAborted));
        }

        /// <summary>
        /// Returns profile information for authenticated user
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(OperationResult<UserProfileViewModel>))]
        public async Task<ActionResult<OperationResult<UserProfileViewModel>>> Profile()
        {
            return await _mediator.Send(new ProfileRequest(), HttpContext.RequestAborted);
        }
    }
}