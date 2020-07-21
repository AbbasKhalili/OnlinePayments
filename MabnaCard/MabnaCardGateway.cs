using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using OnlinePayment.Contract;
using OnlinePayment.MabnaCardTokenService;
using OnlinePayment.MabnaCardVerifyService;

namespace OnlinePayment.MabnaCard
{
    public class MabnaCardGateway : Payment , IPayment 
    {
        public string Crn { get; set; }
        public string Mid { get; set; }
        public string Tid { get; set; }
        public string PrivateKey { get; set; }
        public string PublicKey { get; set; }
        public string Amount { get; set; }
        public string Trn { get; set; }
        public string ReturnUrl { get; set; }
        public string PurchaseLink { get; set; }
        

        public override void AcceptVisitor(IVisitor visitor, PaymentParameters parameters)
        {
            visitor.Visit(this,parameters);
        }

        public TokenInfo DoPayment(out string token)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(PrivateKey);
            byte[] signMain = rsa.SignData(Encoding.UTF8.GetBytes(Amount + Crn + Mid + ReturnUrl + Tid), new SHA1CryptoServiceProvider());
            var signature = Convert.ToBase64String(signMain);


            RSACryptoServiceProvider cipher = new RSACryptoServiceProvider();
            cipher.FromXmlString(PublicKey);

            byte[] data = Encoding.UTF8.GetBytes(Amount);
            byte[] cipherText = cipher.Encrypt(data, false);
            var enAmount = Convert.ToBase64String(cipherText);


            data = Encoding.UTF8.GetBytes(Mid);
            cipherText = cipher.Encrypt(data, false);
            var enMid = Convert.ToBase64String(cipherText);


            data = Encoding.UTF8.GetBytes(Crn);
            cipherText = cipher.Encrypt(data, false);
            var enCrn = Convert.ToBase64String(cipherText);


            data = Encoding.UTF8.GetBytes(ReturnUrl);
            cipherText = cipher.Encrypt(data, false);
            var enReferaladress = Convert.ToBase64String(cipherText);


            data = Encoding.UTF8.GetBytes(Tid);
            cipherText = cipher.Encrypt(data, false);
            var enTid = Convert.ToBase64String(cipherText);

            MabnaCardTokenService.TokenService services = new TokenServiceClient();
            MabnaCardTokenService.tokenDTO tokenParm = new MabnaCardTokenService.tokenDTO
            {
                AMOUNT = enAmount,
                CRN = enCrn,
                MID = enMid,
                REFERALADRESS = enReferaladress,
                SIGNATURE = signature,
                TID = enTid
            };
            var reservationRequest = new reservationRequest(tokenParm);
            var tokenResponse = services.reservation(reservationRequest);

            var result = new TokenInfo("-30000", GetDescription(1007, -30000), "", "");
            
            token = "";
            if (tokenResponse.@return.result == 0)
            {
                token = tokenResponse.@return.token;
                result.ActionType = "POST";
                result.Action = PurchaseLink;
                result.Code = tokenResponse.@return.result.ToString();
                result.Result = GetDescription(1007, tokenResponse.@return.result);
                result.Tokenitems.Add(new TokenInfo.TokenItems("Token", tokenResponse.@return.token));
            }
            return result;
        }

        public VerifyResult Refund()
        {
            ServicePointManager.ServerCertificateValidationCallback =
                            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            var cpsParameter = new CspParameters { Flags = CspProviderFlags.UseMachineKeyStore };

            var rsaProvider = new RSACryptoServiceProvider(1024, cpsParameter);
            RSACryptoServiceProvider.UseMachineKeyStore = true;

            rsa.FromXmlString(PrivateKey);
            byte[] signMain = rsa.SignData(Encoding.UTF8.GetBytes(Mid + Trn + Crn), new
            SHA1CryptoServiceProvider());
            var signature = Convert.ToBase64String(signMain);

            RSACryptoServiceProvider cipher = new RSACryptoServiceProvider();
            cipher.FromXmlString(PublicKey);


            //byte[] data = Encoding.UTF8.GetBytes(Amount);
            //byte[] cipherText = cipher.Encrypt(data, false);


            byte[] data = Encoding.UTF8.GetBytes(Mid);
            byte[] cipherText = cipher.Encrypt(data, false);
            var enMid = Convert.ToBase64String(cipherText);

            data = Encoding.UTF8.GetBytes(Crn);
            cipherText = cipher.Encrypt(data, false);
            var enCrn = Convert.ToBase64String(cipherText);

            data = Encoding.UTF8.GetBytes(Trn);
            cipherText = cipher.Encrypt(data, false);
            var enTrn = Convert.ToBase64String(cipherText);

            var confParam = new confirmationDTO
            {
                MID = enMid,
                CRN = enCrn,
                TRN = enTrn,
                SIGNATURE = signature
            };

            TransactionReference services = new TransactionReferenceClient();
            var configRequest = new sendConfirmationRequest(confParam);
            var tokenResponse = services.sendConfirmation(configRequest);

            var resVerify = new VerifyResult();
            if (tokenResponse.@return.RESCODE != null && tokenResponse.@return.RESCODE.ToString() != "")
            {
                var value = int.Parse(tokenResponse.@return.RESCODE);
                resVerify.Description = GetDescription(1007, value); 
                resVerify.Status = tokenResponse.@return.RESCODE;
                if (value == 0 || value == 101)
                {
                    resVerify.Amount = int.Parse(tokenResponse.@return.AMOUNT);
                    resVerify.RefrenceNumber = tokenResponse.@return.TRN;
                    resVerify.BankReciptNumber = tokenResponse.@return.STAN;
                }
            }
            return resVerify;
        }
    }
}
