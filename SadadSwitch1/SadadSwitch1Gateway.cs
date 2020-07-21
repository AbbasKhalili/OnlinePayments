using OnlinePayment.Contract;
using System;

namespace OnlinePayment.SadadSwitch1
{
    public class SadadSwitch1Gateway : Payment , IPayment 
    {
        public string MerchantId { get; set; }
        public string TerminalId { get; set; }
        public string TransactionKey { get; set; }
        public long Amount { get; set; }
        public long OrderId { get; set; }
        public string ReturnUrl { get; set; }
        public string PurchaseLink { get; set; }
        public string RequestKey { get; set; }
        

        public override void AcceptVisitor(IVisitor visitor, PaymentParameters parameters)
        {
            visitor.Visit(this, parameters);
        }

        public TokenInfo DoPayment(out string token)
        {
            var tokenresult = new TokenInfo("", "", "", "");
            try
            {
                var service = new SadadServiceSwitch1.MerchantUtility();
                
                var timestamp = service.CalcTimeStamp();
                var fp = Calculate.CalcFpOrder(MerchantId, Amount, TransactionKey, OrderId, timestamp);

                token = Calculate.CalcRequestKey(MerchantId, TransactionKey, OrderId, fp, timestamp);

                tokenresult.Code = "0";
                tokenresult.Result = GetDescription(1008, 0);
                tokenresult.Action = PurchaseLink;
                tokenresult.ActionType = "POST";
                tokenresult.Tokenitems.Add(new TokenInfo.TokenItems("CardAcqID", MerchantId));
                tokenresult.Tokenitems.Add(new TokenInfo.TokenItems("AmountTrans", Amount.ToString()));
                tokenresult.Tokenitems.Add(new TokenInfo.TokenItems("ORDERID", OrderId.ToString()));
                tokenresult.Tokenitems.Add(new TokenInfo.TokenItems("TerminalID", TerminalId));
                tokenresult.Tokenitems.Add(new TokenInfo.TokenItems("TimeStamp", timestamp));
                tokenresult.Tokenitems.Add(new TokenInfo.TokenItems("FP", fp));
                tokenresult.Tokenitems.Add(new TokenInfo.TokenItems("RedirectURL", ReturnUrl));
                tokenresult.Tokenitems.Add(new TokenInfo.TokenItems("CustomerEmailAddress", ""));
                tokenresult.Tokenitems.Add(new TokenInfo.TokenItems("OptionalPaymentParameter", ""));
            }
            catch (Exception ex)
            {
                tokenresult.Result = ex.Message;
                token = null;
                return tokenresult;
            }

            return tokenresult;
        }

        public VerifyResult Refund()
        {
            var result = new VerifyResult();
            if (RequestKey == null)
            {
                result.Description = "توکن امنیتی در سیستم وجود ندارد.";
                return result;
            }
                
            var res = new SadadServiceSwitch1.MerchantUtility();
            var verifyresult = res.CheckRequestStatusResult(OrderId, MerchantId, TerminalId, TransactionKey, RequestKey, Amount);
            result.Status = verifyresult.AppStatusCode.ToString();
            result.Amount = Amount;
            result.OrderId = OrderId;
            result.BankReciptNumber = verifyresult.BankReciptNumber;
            result.CardHolderAccNumber = verifyresult.CardHolderAccNumber;
            result.CardHolderName = verifyresult.CardHolderName;
            result.CustomerCardNumber = verifyresult.CustomerCardNumber;
            result.RefrenceNumber = verifyresult.RefrenceNumber;
            result.Description = GetDescription(1008, verifyresult.AppStatusCode);
            return result;
        }
    }
}
