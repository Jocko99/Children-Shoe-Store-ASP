using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API.Core
{
    public class HashUsingSha256
    {
        public string ComputeSha256Hash(string rawData)
        {
            if(!string.IsNullOrEmpty(rawData) && !string.IsNullOrWhiteSpace(rawData))
            {
                SHA256 sha256Hash = SHA256.Create();
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
            return "";
        }
    }
}
