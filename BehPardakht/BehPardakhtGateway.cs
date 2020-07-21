using System;
using System.Net;
using OnlinePayment.Contract;

namespace OnlinePayment.BehPardakht
{
    public class BehPardakhtGateway : Payment ,IPayment 
    {
        public string TerminalId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string Amount { get; set; }
        public string OrderId { get; set; }
        public string ReturnUrl { get; set; }
        public string PurchaseLink { get; set; }
        public string Token { get; set; }
        public string AdditionalData { get; set; }
        public string PayerId { get; set; }
        public string SaleReferenceId { get; set; }

        public override void AcceptVisitor(IVisitor visitor, PaymentParameters parameters)
        {
            visitor.Visit(this,parameters);
        }

        public TokenInfo DoPayment(out string token)
        {
            token = "";
            var result = new TokenInfo("-30000", GetDescription(1004, -30000), "", "");
            try
            {
                BypassCertificateError();
                var localDate = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0');
                var localTime = DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0');

                var bpService = new BehPardakhtWebService.PaymentGatewayClient();
                var response = bpService.bpPayRequest(long.Parse(TerminalId), UserName, UserPassword, int.Parse(OrderId), int.Parse(Amount), 
                    localDate, localTime, AdditionalData, ReturnUrl, long.Parse(PayerId));

                String[] resultArray = response.Split(',');
                if (resultArray[0] == "0")
                {
                    token = resultArray[1];
                    result.ActionType = "POST";
                    result.Action = PurchaseLink;
                    result.Code = resultArray[0];
                    result.Result = GetDescription(1004, int.Parse(response));   
                    result.Tokenitems.Add(new TokenInfo.TokenItems("RefId", token));
                }
            }
            catch (Exception ex)
            {
                result = new TokenInfo("-50000", ex.Message, "", "");
            }

            return result;
        }

        public VerifyResult Refund()
        {
            var result = new VerifyResult();
            try
            {
                var bpService = new BehPardakhtWebService.PaymentGatewayClient();
                var response = bpService.bpVerifyRequest(long.Parse(TerminalId), UserName, UserPassword, long.Parse(OrderId), long.Parse(OrderId)
                    , long.Parse(SaleReferenceId));

                result.Status = response;
                result.Description = GetDescription(1004, int.Parse(response));
                if (response == "0")
                {
                    result.RefrenceNumber = Token;
                    result.OrderId = long.Parse(OrderId);
                }
            }
            catch (Exception)
            {
                result.Description = "پارامترهای مورد نیاز بانک صحیح نمی باشد.";
            }
            return result;
        }

        private void BypassCertificateError()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender1, certificate, chain, sslPolicyErrors) => true;
        }
    }
}
