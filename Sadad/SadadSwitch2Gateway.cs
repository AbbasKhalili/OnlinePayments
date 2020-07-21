using System;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using OnlinePayment.Contract;

namespace OnlinePayment.Sadad
{
    public class SadadSwitch2Gateway : Payment , IPayment 
    {
        public string MerchantId { get; set; }
        public string TerminalId { get; set; }
        public string TransactionKey { get; set; }
        public int Amount { get; set; }
        public string OrderId { get; set; }
        public string RestTokenWebservice { get; set; }
        public string RestVerifyWebservice { get; set; }
        public string ReturnUrl { get; set; }
        public string PurchaseLink { get; set; }
        public string Token { get; set; }
        public string PaymentIdentity { get; set; }


        public override void AcceptVisitor(IVisitor visitor, PaymentParameters parameters)
        {
            visitor.Visit(this, parameters);
        }

        private object CreateData(string signData)
        {
            if (!string.IsNullOrEmpty(PaymentIdentity))
                return new
                {
                    TerminalId = TerminalId,
                    MerchantId = MerchantId,
                    Amount = Amount,
                    SignData = signData,
                    ReturnUrl = ReturnUrl,
                    LocalDateTime = DateTime.Now,
                    OrderId = OrderId,
                    PaymentIdentity = PaymentIdentity
                };
            return new
                   {
                       TerminalId = TerminalId,
                       MerchantId = MerchantId,
                       Amount = Amount,
                       SignData = signData,
                       ReturnUrl = ReturnUrl,
                       LocalDateTime = DateTime.Now,
                       OrderId = OrderId,
                   };
        }

        public TokenInfo DoPayment(out string token)
        {
            var tokeninfo = new TokenInfo("", "", "", "");
            try
            {
                var dataBytes = Encoding.UTF8.GetBytes($"{TerminalId};{OrderId};{Amount}");

                var symmetric = SymmetricAlgorithm.Create("TripleDes");
                symmetric.Mode = CipherMode.ECB;
                symmetric.Padding = PaddingMode.PKCS7;

                var encryptor = symmetric.CreateEncryptor(Convert.FromBase64String(TransactionKey), new byte[10]);

                var signData = Convert.ToBase64String(encryptor.TransformFinalBlock(dataBytes, 0, dataBytes.Length));

                var data = CreateData(signData);

                var res = CallApi<PayResultData>(RestTokenWebservice, data);
                res.Wait();

                token = "";
                if (res.Result == null) throw new NullReferenceException("عدم پاسخگویی بانک مقصد.");

                if (res.Result != null)
                {
                    tokeninfo.Code = res.Result.ResCode;
                    tokeninfo.Result = GetDescription(1002, int.Parse(res.Result.ResCode));
                    if (res.Result.ResCode == "0")
                    {
                        token = res.Result.Token;
                        tokeninfo.Action = PurchaseLink + "/Index?token=" + res.Result.Token;
                        tokeninfo.ActionType = "GET";
                        tokeninfo.Tokenitems.Add(new TokenInfo.TokenItems("Token", res.Result.Token));
                    }
                }
            }
            catch (Exception ex)
            {
                tokeninfo.Result = ex.Message;
                token = "";
                return tokeninfo;
            }
            return tokeninfo;
        }

        public VerifyResult Refund()
        {
            var result = new VerifyResult();
            if (Token == null)
            {
                result.Description = "توکن امنیتی در سیستم وجود ندارد.";
                return result;
            }

            var dataBytes = Encoding.UTF8.GetBytes(Token);

            var symmetric = SymmetricAlgorithm.Create("TripleDes");
            symmetric.Mode = CipherMode.ECB;
            symmetric.Padding = PaddingMode.PKCS7;

            var encryptor = symmetric.CreateEncryptor(Convert.FromBase64String(TransactionKey), new byte[8]);

            var signedData = Convert.ToBase64String(encryptor.TransformFinalBlock(dataBytes, 0, dataBytes.Length));

            var data = new
            {
                Token = Token,
                SignData = signedData
            };

            var res = CallApi<VerifyResultData>(RestVerifyWebservice, data);
            if (res.Result != null)
            {
                result.Amount = long.Parse(res.Result.Amount);
                result.Status = res.Result.ResCode;
                result.OrderId = res.Result.OrderId != null ? long.Parse(res.Result.OrderId) : 0;
                result.RefrenceNumber = res.Result.SystemTraceNo;
                result.BankReciptNumber = res.Result.RetrivalRefNo;
                result.Description = GetDescription(1002, int.Parse(result.Status));
            }
            return result;
        }
        
        
        private static async Task<T> CallApi<T>(string apiUrl, object value)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                var w = client.PostAsJsonAsync(apiUrl, value);
                w.Wait();
                HttpResponseMessage response = w.Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsAsync<T>();
                    result.Wait();
                    return result.Result;
                }
                return default(T);
            }
        }
    }
}
