using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;using System.Collections.Generic;


namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey key)
        {
            return new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
