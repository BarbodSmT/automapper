using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Common
{
    public class SiteSettings
    {
        public JwtSettings JwtSettings { get; set; }
        public IdentitySettings IdentitySettings { get; set; }
    }

    public class IdentitySettings
    {
        public bool PasswordRequireDigit { get; set; }
        public int PasswordRequiredLength { get; set; }
        public bool PasswordRequireNonAlphanumic { get; set; }
        public bool PasswordRequireUppercase { get; set; }
        public bool PasswordRequireLowercase { get; set; }
        public bool RequireUniqueEmail { get; set; }
    }
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public string Encryptkey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int NotBeforeMinutes { get; set; }
        public int ExpirationMinutes { get; set; }
    }

    public class GetSiteSettings
    {
        private readonly SiteSettings _siteSettings;
        public GetSiteSettings(IOptions<SiteSettings> options)
        {
            _siteSettings = options.Value;
        }
        public SiteSettings GetSiteValues() => _siteSettings;
    }
}
