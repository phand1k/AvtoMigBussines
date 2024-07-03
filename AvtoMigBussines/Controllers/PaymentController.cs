﻿using AvtoMigBussines.Authenticate;
using AvtoMigBussines.Services.Implementations;
using AvtoMigBussines.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AvtoMigBussines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<AspNetUser> _userManager;
        private readonly IPaymentMethodService paymentMethodService;
        public PaymentController(IUserService userService, UserManager<AspNetUser> userManager, IPaymentMethodService paymentMethodService)
        {
            _userService = userService;
            _userManager = userManager;
            this.paymentMethodService = paymentMethodService;
        }

        private async Task<AspNetUser> GetCurrentUserAsync()
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            if (string.IsNullOrEmpty(userName))
            {
                return null;
            }

            var aspNetUser = await _userService.GetUserByPhoneNumberAsync(userName);
            if (aspNetUser == null)
            {
                return null;
            }

            var user = await _userManager.FindByIdAsync(aspNetUser.Id);
            return user;
        }
        [HttpGet("GetAllPaymentMethods")]
        public async Task<IActionResult> GetAllPaymentMethods()
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return Unauthorized(new { Message = "User is not authenticated." });
            }
            var result = await paymentMethodService.GetAllAsync();
            return Ok(result);
        }
    }
}