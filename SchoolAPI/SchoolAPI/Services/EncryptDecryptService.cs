using Microsoft.Extensions.Options;
using SchoolAPI.Dto;
using SchoolAPI.Interfaces.Services;
using System.Security.Cryptography;
using System.Text;

namespace SchoolAPI.Services
{
    public class EncryptDecryptService : IEncryptDecryptService
    {
        private Authentication Authentication;

        public EncryptDecryptService(IOptionsMonitor<Authentication> options)
        {
            Authentication = options.CurrentValue;
        }
        public string Encrypt(string pass)
        {
            byte[] keyArray;
            byte[] encriptar = Encoding.UTF8.GetBytes(pass);

            keyArray = Encoding.UTF8.GetBytes(Authentication.Key);
            var tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultado = cTransform.TransformFinalBlock(encriptar, 0, encriptar.Length);

            return Convert.ToBase64String(resultado, 0, resultado.Length);
        }

        public string Decrypt(string pass)
        {
            byte[] keyArray;
            byte[] decriptar = Convert.FromBase64String(pass);

            keyArray = Encoding.UTF8.GetBytes(Authentication.Key);
            var tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultado = cTransform.TransformFinalBlock(decriptar, 0, decriptar.Length);

            return Encoding.UTF8.GetString(resultado);
        }
    }
}
