using System;
using OnlinePayment.Contract;

namespace OnlinePayment.TejarateleParsian
{
    public class TejaratParsianGateway : Payment, IPayment 
    {
        public string Pin { get; set; }
        public string Amount { get; set; }
        public string OrderId { get; set; }
        public string ReturnUrl { get; set; }
        public string PurchaseLink { get; set; }
        public string Token { get; set; }
        

        public override void AcceptVisitor(IVisitor visitor, PaymentParameters parameters)
        {
            visitor.Visit(this, parameters);
        }

        public TokenInfo DoPayment(out string token)
        {
            var result = new TokenInfo("", "", "", "GET");
            token = "";
            using (var obj = new TejaratElecParsianService.SaleServiceSoapClient())
            {
                var data = new TejaratElecParsianService.ClientSaleRequestData()
                {
                    Amount = int.Parse(Amount),
                    CallBackUrl = ReturnUrl,
                    OrderId = int.Parse(OrderId),
                    LoginAccount = Pin,
                    AdditionalData = Amount
                };
                var callback = obj.SalePaymentRequest(data);
                result.Result = callback.Message; //GetDescription(1003, callback.Status);
                result.Code = callback.Status.ToString();
                if (callback.Status == 0)
                {
                    token = callback.Token.ToString();
                    result.Tokenitems.Add(new TokenInfo.TokenItems("Token", token));
                    result.Action = PurchaseLink + "?Token=" + token;
                }
            }
            return result;
        }

        public VerifyResult Refund()
        {
            var result = new VerifyResult { Description = "دوباره تلاش کنید. تایید از بانک انجام نگرفت." };
            using (var tejarat = new TejaratElecParsianConfirm.ConfirmServiceSoapClient())
            {
                var data = new TejaratElecParsianConfirm.ClientConfirmRequestData()
                {
                    LoginAccount = Pin,
                    Token = long.Parse(Token)
                };
                var callback = tejarat.ConfirmPayment(data);

                result.Description = GetDescription(1003, callback.Status);
                if (callback.Status != 0) return result;

                result.Status = callback.Status.ToString();
                result.RefrenceNumber = callback.RRN.ToString();
                result.OrderId = long.Parse(OrderId);
                result.CustomerCardNumber = callback.CardNumberMasked;
                result.Amount = long.Parse(Amount);
                result.BankReciptNumber = callback.Token.ToString();
            }
            return result;
        }
    }
}
