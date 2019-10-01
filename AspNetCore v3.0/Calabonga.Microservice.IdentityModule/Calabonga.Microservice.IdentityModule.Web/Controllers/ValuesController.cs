﻿using Calabonga.EntityFrameworkCore.UnitOfWork.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Calabonga.Microservice.IdentityModule.Web.Controllers
{
    /// <summary>
    /// // Calabonga: update summary (2019-09-29 02:20 ValuesController)
    /// </summary>
    [Route("api/[controller]")]
    public class ValuesController: OperationResultController
    {
        public ValuesController()
        {
            
        }

        [HttpGet("user-data")]
        public IActionResult Get()
        {
            return Ok($"User.Identity.Name {User.Identity.Name}");
        }
    }
}
