using System;
using OnlinePayment.Contract;
using OnlinePayment.IranKishTokenWS;

namespace OnlinePayment.IranKish
{
    public class IranKishGateway : Payment , IPayment
    {
        public string MerchantId { get; set; }
        public string Amount { get; set; }
        public string OrderId { get; set; }
        public string PeymentId { get; set; }
        public string SpecialPeymentId { get; set; }
        public string ReturnUrl { get; set; }
        public string Description { get; set; }
        public string PurchaseLink { get; set; }
        public string Token { get; set; }
        public string ReferenceNumber { get; set; }
        public string Sha1Key { get; set; }



        public override void AcceptVisitor(IVisitor visitor, PaymentParameters parameters)
        {
            visitor.Visit(this, parameters);
        }

        public TokenInfo DoPayment(out string token)
        {
            token = "";
            var result = new TokenInfo("-30000", GetDescription(1001, -30000), "", "");
            try
            {
                var res = new TokensClient().MakeToken(Amount, MerchantId, OrderId, PeymentId, SpecialPeymentId, ReturnUrl, Description);
                if (!res.result) return result;
                token = res.token;
                result.ActionType = "POST";
                result.Action = PurchaseLink;
                result.Code = "0";
                result.Result = res.message;
                result.Tokenitems.Add(new TokenInfo.TokenItems("Token", res.token));
                result.Tokenitems.Add(new TokenInfo.TokenItems("MerchantId", MerchantId));
            }
            catch (Exception)
            {
                return result;
            }
            return result;
        }

        public VerifyResult Refund()
        {
            var result = new VerifyResult();
            try
            {
                var tt = new IranKishVerifyWebService.VerifyClient().KicccPaymentsVerification(Token, MerchantId, ReferenceNumber, Sha1Key);
                result.Description = GetDescription(1001, (int)tt);
                result.Status = tt.ToString();
                result.RefrenceNumber = ReferenceNumber;
                if (tt == long.Parse(Amount))
                    result.Description = GetDescription(1001, 100);
            }
            catch (Exception)
            {
                result.Description = "دوباره تلاش کنید. تایید از بانک انجام نگرفت.";
            }
            return result;
        }
    }
}
