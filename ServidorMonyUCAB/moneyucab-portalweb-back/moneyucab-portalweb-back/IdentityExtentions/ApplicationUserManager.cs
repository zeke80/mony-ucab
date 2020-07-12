using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using moneyucab_portalweb_back.EntitiesForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.IdentityExtentions
{
    public class ApplicationUserManager : UserManager<Usuario>
    {
        private const int PASSWORD_HISTORY_LIMIT = 3;

        public ApplicationUserManager(
            IUserStore<Usuario> store,
            IOptions<IdentityOptions> optionsAccesor,
            IPasswordHasher<Usuario> passwordHasher,
            IEnumerable<IUserValidator<Usuario>> userValidators,
            IEnumerable<IPasswordValidator<Usuario>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<Usuario>> logger
            ) : base(
                store, optionsAccesor, passwordHasher, userValidators,
                passwordValidators, keyNormalizer, errors, services, logger
                )
        {
        }

        public override async Task<IdentityResult> CreateAsync(Usuario User, string Password)
        {
            await base.CreateAsync(User, Password);
            var user = await FindByEmailAsync(User.Email);
            await AddToPreviousPasswordsAsync(user, Password);
            return await Task.FromResult(IdentityResult.Success);
        }

        public override async Task<IdentityResult> ChangePasswordAsync(Usuario User, string CurrentPassword, string NewPassword)
        {
            if (await IsPreviousPassword(User.Id, NewPassword))
            {
                return await Task.FromResult(IdentityResult.Failed());
            }
            var result = await base.ChangePasswordAsync(User, CurrentPassword, NewPassword);
            if (result.Succeeded)
            {
                await AddToPreviousPasswordsAsync(await FindByIdAsync(User.Id), NewPassword);
            }
            return result;
        }

        public override async Task<IdentityResult> ResetPasswordAsync(Usuario User, string Token, string NewPassword)
        {
            if (await IsPreviousPassword(User.Id, NewPassword))
            {
                return await Task.FromResult(IdentityResult.Failed());
            }
            var result = await base.ResetPasswordAsync(User, Token, NewPassword);
            if (result.Succeeded)
            {
                await AddToPreviousPasswordsAsync(await FindByIdAsync(User.Id), NewPassword);
            }
            return result;
        }

        public Task AddToPreviousPasswordsAsync(Usuario User, string Password)
        {
            User.PreviousUserPasswords.Add(
                new PreviousPasswords()
                {
                    UsuarioID = User.Id,
                    PasswordHash = Password
                }
            );
            return UpdateAsync(User);
        }

        private async Task<bool> IsPreviousPassword(string IdUsuario, string NewPassword)
        {
            var user = await FindByIdAsync(IdUsuario);
            if (
                user.PreviousUserPasswords
                .OrderByDescending(x => x.FechaCreacion)
                .Select(x => x.PasswordHash)
                .Take(PASSWORD_HISTORY_LIMIT)
                .Where(x => x.Equals(NewPassword))
                .Any()
            )
            {
                return true;
            }
            return false;
        }
    }
}
