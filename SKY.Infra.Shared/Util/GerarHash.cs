using System;
using System.Security.Cryptography;
using System.Text;

namespace SKY.Infra.Shared.Util
{
	public static class GerarHash
	{
		public static string RetornarHash(this string senha)
		{
            byte[] hashValue;

            UnicodeEncoding ue = new UnicodeEncoding();
            byte[] messageBytes = ue.GetBytes(senha);
            SHA1Managed shHash = new SHA1Managed();

            hashValue = shHash.ComputeHash(messageBytes);

            string hash = string.Empty;

            foreach (byte b in hashValue)
            {
                hash += b;
            }

            return hash;

        }
	}
}
