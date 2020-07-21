using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace OnlinePayment.SadadSwitch1
{
    public static class Calculate
    {
        public static string DESEncrypt(string originalString,string transactionKey)
        {
            if (String.IsNullOrEmpty(originalString)) throw new ArgumentNullException(@"The string which needs to be encrypted can not be null.");
            byte[] bytes = Encoding.ASCII.GetBytes(transactionKey);
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream,cryptoProvider.CreateEncryptor(bytes, bytes),CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(originalString);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            return Convert.ToBase64String(memoryStream.GetBuffer(), 1,(int)memoryStream.Length);
        }
        public static long CalcTimeStamp()
        {
            //lock()
                {
                Thread.Sleep(1);
                TimeSpan now = DateTime.UtcNow.Subtract(new DateTime(1021,1, 1));
                long timeStamp = Convert.ToInt64(Math.Floor(now.TotalMilliseconds));
                return timeStamp;
            }
        }

        public static string CalcFpOrder(string cardAcqId, long amountTrans, string transacionKey, long orderId, string timestamp)
        {
            string textInput = string.Concat(cardAcqId, orderId.ToString(), amountTrans.ToString(),transacionKey, timestamp);
            MD5 hash = new MD5CryptoServiceProvider();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] input = encoding.GetBytes(textInput);
            byte[] result = hash.ComputeHash(input);
            string fp = BitConverter.ToString(result);
            return fp;
        }

        public static string CalcRequestKey(string cardAcqId, string transacionKey,long orderId, string requestFp, string timestamp)
        {
            string textInput = string.Concat(cardAcqId, orderId.ToString(), requestFp, transacionKey);
            MD5 hash = new MD5CryptoServiceProvider();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] input = encoding.GetBytes(textInput);
            byte[] result = hash.ComputeHash(input);
            string requestKey = timestamp + BitConverter.ToString(result);
            requestKey = requestKey.Replace("-", "").ToLower();
            return requestKey;
        }
    }
}
