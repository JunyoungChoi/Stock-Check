using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace JY
{
    class Crypto
    {
        private string generatorAuthPW(string message, int count)
        {
            if (count <= 0)
            {
                return message;
            }

            //입력받은 문자열을 바이트배열로 변환
            byte[] array = Encoding.Default.GetBytes(message);
            byte[] hashValue;
            string result = string.Empty;

            //바이트배열을 암호화된 32byte 해쉬값으로 생성
            using (SHA256 mySHA256 = SHA256.Create())
            {
                hashValue = mySHA256.ComputeHash(array);
            }
            //32byte 해쉬값을 16진수로변환하여 64자리로 만듬
            for (int i = 0; i < hashValue.Length; i += 2)
            {
                result += hashValue[i + 1].ToString("x2");
                result += hashValue[i].ToString("x2");
            }

            return generatorAuthPW(result, count - 1);
        }

        public string GenerateHash(string message, int count)
        {
            if (count <= 0)
            {
                return message;
            }

            //입력받은 문자열을 바이트배열로 변환
            byte[] array = Encoding.Default.GetBytes(message);
            byte[] hashValue;
            string result = string.Empty;

            //바이트배열을 암호화된 32byte 해쉬값으로 생성
            using (SHA256 mySHA256 = SHA256.Create())
            {
                hashValue = mySHA256.ComputeHash(array);
            }
            //32byte 해쉬값을 16진수로변환하여 64자리로 만듬
            for (int i = 0; i < hashValue.Length; i += 2)
            {
                result += hashValue[i + 1].ToString("x2");
                result += hashValue[i].ToString("x2");
            }

            if (count % 2 == 0)
            {
                result = result.Substring(0, result.Length - 1);
            }
            else
            {
                result += hashValue[0].ToString("x2");
            }

            return generatorAuthPW(result, count - 1);
        }
    }
}
