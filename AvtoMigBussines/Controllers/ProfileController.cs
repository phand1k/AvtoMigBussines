﻿using AvtoMigBussines.Authenticate;
using AvtoMigBussines.Data;
using AvtoMigBussines.Repositories.Interfaces;
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
    public class ProfileController : Controller
    {
        private readonly IUserService userService;
        private readonly UserManager<AspNetUser> userManager;
        private readonly INotificationCenterService notificationCenterService;
        public ProfileController(IUserService userService, UserManager<AspNetUser> userManager, INotificationCenterService notificationCenterService)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.notificationCenterService = notificationCenterService;
        }
        [HttpGet("Notifications")]
        public async Task<IActionResult> Notifications()
        {
            var notificationData = await notificationCenterService.GetAllNotificationsAsync();
            return Ok(notificationData);
        }
        [Route("GetProfileInfo")]
        [HttpGet]
        public async Task<IActionResult> GetProfileInfo()
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var aspNetUser = await userService.GetUserByPhoneNumberAsync(userName);
            var user = await userManager.FindByIdAsync(aspNetUser.Id);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }

    }
}
