using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rozklad.Core;
using Rozklad.Repos.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozklad.Repos
{
    public class UsersRepository
    {
        private readonly RozkladContext _ctx;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public UsersRepository(RozkladContext ctx, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _ctx = ctx;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<User> CreateUserAsync(string? firstName, string? lastName, string? password, string? email)
        {
            var newUser = new User
            {
                FirstName = firstName
                , LastName = lastName,
                Email = email,
                UserName = email,
                NormalizedEmail = email.ToUpper(),
                NormalizedUserName = email.ToUpper(),
                EmailConfirmed = true
            };
            await userManager.CreateAsync(newUser, password);
            return await _ctx.Users.FirstAsync(x => x.Email == email);
        }

        public async Task DeleteUserAsync(string id)
        {
            var user = _ctx.Users.Find(id);

            if((await userManager.GetRolesAsync(user)).Any())
            {
                await userManager.RemoveFromRolesAsync(user, await userManager.GetRolesAsync(user));
            }
            await userManager.DeleteAsync(user);
        }

        public async Task<IEnumerable<UserReadDto>> GetUsersAsync()
        {
            var users = new List<UserReadDto>();

            foreach (var u in _ctx.Users.ToList())
            {
                var userDto = new UserReadDto
                {
                    Id = u.Id,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    IsConfirmed = u.EmailConfirmed,
                    Roles = new List<IdentityRole>()
                };

                foreach(var role in await userManager.GetRolesAsync(u))
                {
                    userDto.Roles.Add(await _ctx.Roles.FirstAsync(x => x.Name.ToLower() == role.ToLower()));

                }
                users.Add(userDto);
            }
            return users;
        }

        public async Task<UserReadDto> GetUsersAsync(string id)
        {
            var u = await _ctx.Users.FirstAsync(x => x.Id == id);

           
                var userDto = new UserReadDto
                {
                    Id = u.Id,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    IsConfirmed = u.EmailConfirmed,
                    Roles = new List<IdentityRole>()
                };

                foreach (var role in await userManager.GetRolesAsync(u))
                {
                    userDto.Roles.Add(await _ctx.Roles.FirstAsync(x => x.Name.ToLower() == role.ToLower()));

                }
            return userDto;
            }
    }
}
