using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Lgm.Emos.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lgm.Emos.Web.Admin.Dashboard.Users
{
    //[Authorize(Policy = "ApiUser")]
    [Produces("application/json")]
    [Route("api/dashboard/users")]
    public class UsersController : Controller
    {
        private readonly ClaimsPrincipal _caller;
        private readonly IdentityAppDbContext _appDbContext;
        private readonly IHostingEnvironment _environment;
        private readonly IMapper _mapper;

        public UsersController(UserManager<IdentityAppUser> userManager, IdentityAppDbContext appDbContext, IHttpContextAccessor httpContextAccessor, IMapper mapper, IHostingEnvironment environment)
        {
            _caller = httpContextAccessor.HttpContext.User;
            _appDbContext = appDbContext;
            _environment = environment;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            // retrieve the user info
            //HttpContext.User
            //var userId = _caller.Claims.Single(c => c.Type == "id");
            var emosUsers = await _appDbContext.EmosUsers.Select(u => new { u.Id, u.FirstName, u.LastName, u.Service, u.Office, u.Team, u.Rank, u.BadgeCode }).ToListAsync();

            return new OkObjectResult(emosUsers);
        }

        [Route("api/dashboard/users/firstName/lastName")]
        [HttpGet("{firstName}/{lastName}")]
        public async Task<IActionResult> GetUsersByName(string firstName, string lastName)
        {
            // retrieve the user info

            var users = await _appDbContext.EmosUsers.Where(u => u.FirstName == firstName && u.LastName == lastName).Select(u => _mapper.Map<UserApiModel>(u)).ToListAsync();

            return new OkObjectResult(users);
        }

        [HttpGet("{ByCode}")]
        public async Task<IActionResult> GetUsersByCode(string code)
        {
            // retrieve the user info

            var user = await _appDbContext.EmosUsers.FirstOrDefaultAsync(u => u.BadgeCode == code);

            if (user != null)
            {
                var apiUser = _mapper.Map<UserApiModel>(user);
                return new OkObjectResult(apiUser);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (ModelState.IsValid)
            {
                EmosUser emosUser = await _appDbContext.EmosUsers.SingleOrDefaultAsync(u => u.Id == id);

                if (emosUser != null)
                {
                    _appDbContext.Remove<EmosUser>(emosUser);
                    await _appDbContext.SaveChangesAsync();

                    // retrieve the user info
                    //HttpContext.User
                    //var userId = _caller.Claims.Single(c => c.Type == "id");

                    return new NoContentResult();
                }
                else
                {
                    return NotFound();
                }
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] ApiModelUser userInfo)
        {
            if (ModelState.IsValid)
            {

                EmosUser emosUser = await _appDbContext.EmosUsers.SingleOrDefaultAsync(u => u.Id == userInfo.id);

                if (emosUser != null)
                {
                    emosUser.FirstName = userInfo.firstName;
                    emosUser.LastName = userInfo.lastName;
                    emosUser.Office = userInfo.office;
                    emosUser.Rank = userInfo.rank;
                    emosUser.Service = userInfo.service;
                    emosUser.Team = userInfo.team;
                    emosUser.BadgeCode = userInfo.badgeCode;
                    await _appDbContext.SaveChangesAsync();

                    // retrieve the user info
                    //HttpContext.User
                    //var userId = _caller.Claims.Single(c => c.Type == "id");
                   
                    return Ok(new ApiModelUser { id = emosUser.Id, firstName = emosUser.FirstName, lastName = emosUser.LastName, office = emosUser.Office, rank = emosUser.Rank, service = emosUser.Service, team = emosUser.Team, badgeCode = emosUser.BadgeCode });
                }
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody]  ApiModelUser userInfo)
        {
            if (ModelState.IsValid)
            {
                EmosUser emosUser = new EmosUser();

                emosUser.FirstName = userInfo.firstName;
                emosUser.LastName = userInfo.lastName;
                emosUser.Office = userInfo.office;
                emosUser.Rank = userInfo.rank;
                emosUser.Service = userInfo.service;
                emosUser.Team = userInfo.team;
                emosUser.BadgeCode = userInfo.badgeCode;
                await _appDbContext.AddAsync(emosUser);
                await _appDbContext.SaveChangesAsync();

                return Ok(new ApiModelUser { id = emosUser.Id, firstName = emosUser.FirstName, lastName = emosUser.LastName, office = emosUser.Office, rank = emosUser.Rank, service = emosUser.Service, team = emosUser.Team, badgeCode = emosUser.BadgeCode });

            }
            // retrieve the user info
            //HttpContext.User
            //var userId = _caller.Claims.Single(c => c.Type == "id");
            return BadRequest();
        }

        //[HttpPost]
        //public async Task Post(UserApiModel user, IFormFile image)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var imgDir = Path.Combine(_environment.WebRootPath, "Images");
        //        if (image.Length > 0)
        //        {
        //            var fileName = DateTime.Now.ToString("yyyymmddMMss") + Path.GetExtension(image.FileName);

        //            using (var fileStream = new FileStream(Path.Combine(imgDir, fileName), FileMode.Create))
        //            {
        //                await image.CopyToAsync(fileStream);
        //            }

        //            EmosUser emosUser = _appDbContext.EmosUsers.SingleOrDefault(u => u.Id == user.Id);

        //        }
        //    }
        //}
    }
}