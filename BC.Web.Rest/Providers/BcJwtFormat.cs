using MSTokens = Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Web;
using Thinktecture.IdentityModel.Tokens;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System.Text;

namespace BC.Web.Rest.Providers
{
    public class BcJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {

        private readonly string _issuer = string.Empty;

        public BcJwtFormat(string issuer)
        {
            _issuer = issuer;
        }

        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            string audienceId = ConfigurationManager.AppSettings["AudienceId"];

            //string symmetricKeyAsBase64 = "my best key my best key my best key my best key my best key my best key";//ConfigurationManager.AppSettings["as:AudienceSecret"];

            //var keyByteArray = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["AudienceSecret"]);
            //var audienceSecret = Convert.FromBase64String(ConfigurationManager.AppSettings["AudienceSecret"].Substring(0, 44));


            //var audienceSecret = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["AudienceSecret"].Substring(0, 32).ToCharArray());

            byte[] audienceSecret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["AudienceSecret"]);

            //SigningCredentials signingKey = new SigningCredentials(new SymmetricSecurityKey(audienceSecret), );
            HmacSigningCredentials signingKey = new HmacSigningCredentials(audienceSecret);
            //MSTokens.SigningCredentials signingKey = new MSTokens.SigningCredentials(new MSTokens.SymmetricSecurityKey(audienceSecret), MSTokens.SecurityAlgorithms.HmacSha256);

            var issued = data.Properties.IssuedUtc;

            var expires = data.Properties.ExpiresUtc;

            var token = new JwtSecurityToken(_issuer, audienceId, data.Identity.Claims, issued.Value.UtcDateTime, expires.Value.UtcDateTime, signingKey);

            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.WriteToken(token);

            return jwt;
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}