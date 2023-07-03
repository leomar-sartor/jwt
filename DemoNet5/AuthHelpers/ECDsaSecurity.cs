using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Cryptography;

namespace DemoNet5.AuthHelpers
{
    public static class ECDsaSecurity
    {
        private readonly static ECCurve DefaultCurve = ECCurve.NamedCurves.nistP256;
        private static ECDsaSecurityKey _ecdssaKeyPrivada;
        private static ECDsaSecurityKey _ecdssaKeyPublica;
        public static ECDsaSecurityKey ObterECDsaPublica()
        {
            if (_ecdssaKeyPublica != null) return _ecdssaKeyPublica;

            GerarChaves();
            return _ecdssaKeyPublica;
        }
        public static ECDsaSecurityKey ObterECDsaPrivada()
        {
            if (_ecdssaKeyPrivada != null) return _ecdssaKeyPrivada;

            GerarChaves();
            return _ecdssaKeyPrivada;
        }

        private static void GerarChaves()
        {
            var ecdsa = new ECDsaSecurityKey(ECDsa.Create(DefaultCurve))
            {
                KeyId = "Leomar" //Guid.NewGuid().ToString()
            };

            var parametrosPrivados = ecdsa.ECDsa.ExportParameters(true);
            _ecdssaKeyPrivada = new ECDsaSecurityKey(ECDsa.Create(parametrosPrivados));

            var parametrosPublicos = ecdsa.ECDsa.ExportParameters(false);
            _ecdssaKeyPublica = new ECDsaSecurityKey(ECDsa.Create(parametrosPublicos));
        }
    }
}
