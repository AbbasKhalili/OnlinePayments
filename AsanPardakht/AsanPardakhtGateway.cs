using System;
using OnlinePayment.Contract;

namespace OnlinePayment.AsanPardakht
{
    public class AsanPardakhtGateway  : Payment, IPayment
    {
        public int MerchantId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Key { get; set; }
        public string Iv { get; set; }
        public string Amount { get; set; }
        public string OrderId { get; set; }
        public string ReturnUrl { get; set; }
        public string ExtraInfo { get; set; }
        public string PurchaseLink { get; set; }
        public string ReturningParams { get; set; }
        

        public override void AcceptVisitor(IVisitor visitor, PaymentParameters parameters)
        {
            visitor.Visit(this, parameters);
        }

        public TokenInfo DoPayment(out string token)
        {
            var date = DateTime.Now.Date.ToString("yyyyMMdd HHmmss");

            var p1 = "1";                 // خرید =1
            var p2 = Username;            // نام کاربری
            var p3 = Password;            // رمز عبور
            var p4 = OrderId;             // شماره فاکتور 
            var p5 = Amount;              // مبلغ
            var p6 = date;                // تاریخ و ساعت
            var p7 = ExtraInfo;           // اطلاعات اضافی تا 100 کاراکتر
            var p8 = ReturnUrl;           // لینک برگشت
            var p9 = "";                  // درصورت وجود شناسه واریز


            var aes = new AES(Key, Iv);
            var encryptedRequest = "";
            var csvString = string.Join(",", p1, p2, p3, p4, p5, p6, p7, p8, p9);
            var aesEncrypt = aes.Encrypt(csvString, out encryptedRequest);

            var result = new TokenInfo("-30000", "", "", "");
            result.Result = GetDescription(1006, int.Parse(result.Code));
            token = "";
            if (aesEncrypt)
            {
                var asanpar = new AsanPardakhtService.merchantservicesSoapClient();
                var resStr = asanpar.RequestOperation(MerchantId, encryptedRequest);
                token = resStr;
                result.ActionType = "POST";
                result.Action = PurchaseLink;
                result.Code = "0";
                result.Result = GetDescription(1006, int.Parse(result.Code));
                result.Tokenitems.Add(new TokenInfo.TokenItems("RefID", resStr));
            }
            return result;
        }

        public VerifyResult Refund()
        {
            var result = new VerifyResult { Status = "-30000" };
            result.Description = GetDescription(1006, int.Parse(result.Status));

            if (ReturningParams.Length > 0)
            {
                var decryptedRequest = "";

                var aes = new AES(Key, Iv);
                var aesDecrypt = aes.Decrypt(ReturningParams, out decryptedRequest);
                if (aesDecrypt)
                {
                    var arry = decryptedRequest.Split(Convert.ToChar(","));
                    result.Amount = int.Parse(arry[0]);
                    result.OrderId = int.Parse(arry[1]);
                    //result.RefId = arry[2];
                    result.Status = arry[3];
                    result.Description = arry[4];
                    var payGateTranId = arry[5];
                    result.RefrenceNumber = arry[6];
                    result.CustomerCardNumber = arry[4] + "***" + arry[7];
                    result.Description = GetDescription(1006, int.Parse(result.Status));
                    if (int.Parse(result.Status) == 0)
                    {
                        result.Status = "-30001";
                        result.Description = GetDescription(1006, int.Parse(result.Status));

                        var userpassEncrypt = "";
                        aes.Encrypt(Username + "," + Password, out userpassEncrypt);
                        var ap = new AsanPardakhtService.merchantservicesSoapClient();
                        var verify = ap.RequestVerification(MerchantId, userpassEncrypt, uint.Parse(payGateTranId));
                        result.Status = verify;
                        result.Description = GetDescription(1006, int.Parse(result.Status));
                        if (int.Parse(verify) == 500)
                        {
                            result.Status = "-30002";
                            result.Description = GetDescription(1006, int.Parse(result.Status));

                            var recon = ap.RequestReconciliation(MerchantId, userpassEncrypt, uint.Parse(payGateTranId));
                            result.Status = recon;
                            result.Description = GetDescription(1006, int.Parse(result.Status));
                        }
                    }
                }
            }
            return result;
        }
    }
}
