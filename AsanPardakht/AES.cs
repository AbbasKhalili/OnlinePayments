using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace OnlinePayment.AsanPardakht
{
    public class AES
    {
        string AES_Key = string.Empty;
        string AES_IV = string.Empty;

        public AES(string AES_Key, string AES_IV)
        {
            this.AES_Key = AES_Key;
            this.AES_IV = AES_IV;
        }

        public bool Encrypt(string Input, out string encryptedString)
        {
            try
            {
                var aes = new RijndaelManaged
                          {
                              KeySize = 256,
                              BlockSize = 256,
                              Padding = PaddingMode.PKCS7,
                              Key = Convert.FromBase64String(this.AES_Key),
                              IV = Convert.FromBase64String(this.AES_IV)
                          };
                var encrypt = aes.CreateEncryptor(aes.Key, aes.IV);
                byte[] xBuff = null;
                using(var ms = new MemoryStream())
                {
                    using(var cs = new CryptoStream(ms, encrypt, CryptoStreamMode.Write))
                    {
                        byte[] xXml = Encoding.UTF8.GetBytes(Input);
                        cs.Write(xXml, 0, xXml.Length);
                    }
                    xBuff = ms.ToArray();
                }
                encryptedString = Convert.ToBase64String(xBuff);
                return true;
            }
            catch (Exception)
            {
                encryptedString = string.Empty;
                return false;
            }
        }

        public bool Decrypt(string Input, out string decodedString)
        {
            try
            {
                RijndaelManaged aes = new RijndaelManaged
                                      {
                                          KeySize = 256,
                                          BlockSize = 256,
                                          Mode = CipherMode.CBC,
                                          Padding = PaddingMode.PKCS7,
                                          Key = Convert.FromBase64String(this.AES_Key),
                                          IV = Convert.FromBase64String(this.AES_IV)
                                      };
                var decrypt = aes.CreateDecryptor();
                byte[] xBuff = null;
                using(var ms = new MemoryStream())
                {
                    using(var cs = new CryptoStream(ms, decrypt, CryptoStreamMode.Write))
                    {
                        byte[] xXml = Convert.FromBase64String(Input);
                        cs.Write(xXml, 0, xXml.Length);
                    }
                    xBuff = ms.ToArray();
                }
                decodedString = Encoding.UTF8.GetString(xBuff);
                return true;
            }
            catch (Exception)
            {
                decodedString = string.Empty;
                return false;
            }
        }
    }
}
