using System;
using OnlinePayment.IranKishTokenWS;

namespace OnlinePayment.IranKish
{
    public class IranKishGate
    {
        private readonly string _merchantId;
        
        public IranKishGate(string merchandId)
        {
            _merchantId = merchandId;
        }
        
        //public TokenInfo TakeTokenService(PaymentParameters param, out string tokenstring)
        //{
        //    var res = new TokensClient().MakeToken(param.Amount.ToString(), _merchantId, 
        //        param.OrderId.ToString(), param.PeymentId, param.SpecialPeymentId, param.ReturnUrl, param.Description);

        //    var result = new TokenInfo("-30000", ResCodeDescription.GetDescription(1001, -30000) , "", "");
        //    tokenstring = "";
        //    if (res.result)
        //    {
        //        tokenstring = res.token;
        //        result.ActionType = "POST";
        //        result.Action = param.PurchaseLink;
        //        result.Code = "0";
        //        result.Result = res.message;
        //        result.Tokenitems.Add(new TokenInfo.TokenItems("Token", res.token));
        //        result.Tokenitems.Add(new TokenInfo.TokenItems("MerchantId", _merchantId));
        //    }
        //    return result;
        //}

        //public VerifyResult VerifyService(string token, string referenceNumber, string sha1Key,long amount)
        //{
        //    var result = new VerifyResult();
        //    try
        //    {
        //        var tt = new IranKishVerifyWebService.VerifyClient().KicccPaymentsVerification(token, _merchantId, referenceNumber, sha1Key);
        //        result.Description = ResCodeDescription.GetDescription(1001, (int)tt);   //SetResultValue(tt);
        //        result.Status = tt.ToString();
        //        result.RefrenceNumber = referenceNumber;
        //        if (tt == amount)
        //            result.Description= ResCodeDescription.GetDescription(1001, 100);    //SetResultValue(100);
        //    }
        //    catch (Exception)
        //    {
        //        result.Description = "دوباره تلاش کنید. تایید از بانک انجام نگرفت.";
        //    }
        //    return result;
        //}
    }
}
