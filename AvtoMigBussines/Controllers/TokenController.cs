﻿using AvtoMigBussines.Authenticate;
using AvtoMigBussines.Data;
using AvtoMigBussines.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AvtoMigBussines.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AspNetUser> userManager;
        public TokenController(ApplicationDbContext context, UserManager<AspNetUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }
        [Route("RegisterToken")]
        [HttpPost]
        public async Task<IActionResult> RegisterToken([FromBody] NotifiactionToken notifiactionToken)
        {
            if (ModelState.IsValid)
            {
                var userName = User.FindFirstValue(ClaimTypes.Name);
                var user = await userManager.FindByNameAsync(userName);

                notifiactionToken.AspNetUserId = user.Id;
                notifiactionToken.OrganizationId = user.OrganizationId;
                await _context.NotifiactionTokens.AddAsync(notifiactionToken);
                await _context.SaveChangesAsync();
                return Ok(notifiactionToken);
            }
            return BadRequest("Some data is not valid");
        }
        /*[HttpGet]
        public async Task<IActionResult> GetAllUsersToken(string? jwtToken)
        {
            if (jwtToken == null)
            {
                return Unauthorized();
            }
            var listOfUsersToSendNotifiaction = await _context.NotifiactionTokens.Where(x=>x.OrganizationId == jwtToken.Select(x>x.OrganizationId));
        }*/
    }
}