using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace SchoolAPI.Utils
{
    public class CustomResetPasswordTokenProvider<TUser> : DataProtectorTokenProvider<TUser> where TUser : class
    {
        public CustomResetPasswordTokenProvider(IDataProtectionProvider dataProtectionProvider,
            IOptions<CustomResetPasswordTokenProviderOptions> options, ILogger<DataProtectorTokenProvider<TUser>> logger)
            : base(dataProtectionProvider, options, logger)
        {

        }
    }
}
