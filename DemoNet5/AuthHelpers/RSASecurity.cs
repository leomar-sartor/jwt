using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Cryptography;

namespace DemoNet5.AuthHelpers
{
    public static class RSASecurity
    {
        private static RsaSecurityKey _rsaSecurityKeyPublic;
        private static RsaSecurityKey _rsaSecurityKeyPrivate;
        public static RsaSecurityKey ObterRsaPublica()
        {
            if (_rsaSecurityKeyPublic != null) return _rsaSecurityKeyPublic;

            GerarChavesPublicasEPrivadas();

            return _rsaSecurityKeyPublic;
        }
        public static RsaSecurityKey ObterRsaPrivada()
        {
            if (_rsaSecurityKeyPrivate != null) return _rsaSecurityKeyPrivate;

            GerarChavesPublicasEPrivadas();

            return _rsaSecurityKeyPrivate;
        }

        private static void GerarChavesPublicasEPrivadas()
        {
            var rsa = new RsaSecurityKey(RSA.Create(2048))
            {
                KeyId = Guid.NewGuid().ToString()
            };

            var parametrosPrivados = rsa.Rsa.ExportParameters(true);
            _rsaSecurityKeyPrivate = new RsaSecurityKey(RSA.Create(parametrosPrivados));

            var parametrosPublicos = rsa.Rsa.ExportParameters(false);
            _rsaSecurityKeyPublic = new RsaSecurityKey(RSA.Create(parametrosPublicos));
        }
    }
}
