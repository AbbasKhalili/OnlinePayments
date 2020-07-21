using OnlinePayment.AsanPardakht;
using OnlinePayment.BehPardakht;
using OnlinePayment.Contract;
using OnlinePayment.IranKish;
using OnlinePayment.MabnaCard;
using OnlinePayment.Sadad;
using OnlinePayment.SadadSwitch1;
using OnlinePayment.TejarateleParsian;

namespace OnlinePayment
{
    public class FillRequiredFields : IVisitor
    {
        public void Visit(IranKishGateway iranKish, PaymentParameters parameters)
        {
            iranKish.Amount = parameters.Amount.ToString();
            iranKish.Description = parameters.Description;
            iranKish.MerchantId = parameters.MerchantId;
            iranKish.OrderId = parameters.OrderId.ToString();
            iranKish.PeymentId = parameters.PeymentId;
            iranKish.PurchaseLink = parameters.PurchaseLink;
            iranKish.ReturnUrl = parameters.ReturnUrl;
            iranKish.SpecialPeymentId = parameters.SpecialPeymentId;
            iranKish.Sha1Key = parameters.Sha1Key;
            iranKish.Token = parameters.Token;
            iranKish.ReferenceNumber = parameters.ReferenceNumber;
        }

        public void Visit(SadadSwitch2Gateway sadadSwitch2Gateway, PaymentParameters parameters)
        {
            sadadSwitch2Gateway.MerchantId = parameters.MerchantId;
            sadadSwitch2Gateway.TerminalId = parameters.TerminalId;
            sadadSwitch2Gateway.TransactionKey = parameters.TransactionKey;
            sadadSwitch2Gateway.Amount = parameters.Amount;
            sadadSwitch2Gateway.OrderId = parameters.OrderId.ToString();
            sadadSwitch2Gateway.RestTokenWebservice = parameters.RestTokenWebservice;
            sadadSwitch2Gateway.RestVerifyWebservice = parameters.RestVerifywebServicelink;
            sadadSwitch2Gateway.ReturnUrl = parameters.ReturnUrl;
            sadadSwitch2Gateway.PurchaseLink = parameters.PurchaseLink;
            sadadSwitch2Gateway.Token = parameters.Token;
            sadadSwitch2Gateway.PaymentIdentity = parameters.PaymentIdentity;
        }

        public void Visit(TejaratParsianGateway tejaratParsianGateway, PaymentParameters parameters)
        {
            tejaratParsianGateway.Pin = parameters.Pin;
            tejaratParsianGateway.Amount = parameters.Amount.ToString();
            tejaratParsianGateway.PurchaseLink = parameters.PurchaseLink;
            tejaratParsianGateway.Token = parameters.Token;
            tejaratParsianGateway.OrderId = parameters.OrderId.ToString();
            tejaratParsianGateway.ReturnUrl = parameters.ReturnUrl;
        }

        public void Visit(BehPardakhtGateway behPardakhtGateway, PaymentParameters parameters)
        {
            behPardakhtGateway.TerminalId = parameters.TerminalId;
            behPardakhtGateway.UserName = parameters.Username;
            behPardakhtGateway.UserPassword = parameters.Password;
            behPardakhtGateway.Amount = parameters.Amount.ToString();
            behPardakhtGateway.OrderId = parameters.OrderId.ToString();
            behPardakhtGateway.ReturnUrl = parameters.ReturnUrl;
            behPardakhtGateway.PurchaseLink = parameters.PurchaseLink;
            behPardakhtGateway.Token = parameters.Token;
            behPardakhtGateway.AdditionalData = parameters.AdditionalData;
            behPardakhtGateway.PayerId = parameters.PayerId;
            behPardakhtGateway.SaleReferenceId = parameters.SaleReferenceId;
        }

        public void Visit(AsanPardakhtGateway asanPardakhtGateway, PaymentParameters parameters)
        {
            asanPardakhtGateway.MerchantId = int.Parse(parameters.MerchantId);
            asanPardakhtGateway.Username = parameters.Username;
            asanPardakhtGateway.Password = parameters.Password;
            asanPardakhtGateway.Key = parameters.Key;
            asanPardakhtGateway.Iv = parameters.Iv;
            asanPardakhtGateway.Amount = parameters.Amount.ToString();
            asanPardakhtGateway.OrderId = parameters.OrderId.ToString();
            asanPardakhtGateway.ReturnUrl = parameters.ReturnUrl;
            asanPardakhtGateway.ExtraInfo = parameters.ExtraInfo;
            asanPardakhtGateway.PurchaseLink = parameters.PurchaseLink;
            asanPardakhtGateway.ReturningParams = parameters.ReturningParams;
        }

        public void Visit(MabnaCardGateway mabnaCardGateway, PaymentParameters parameters)
        {
            mabnaCardGateway.Crn = parameters.Crn;
            mabnaCardGateway.Mid = parameters.Mid;
            mabnaCardGateway.Tid = parameters.Tid;
            mabnaCardGateway.PrivateKey = parameters.Privatekey;
            mabnaCardGateway.PublicKey = parameters.Publickey;
            mabnaCardGateway.Amount = parameters.Amount.ToString();
            mabnaCardGateway.Trn = parameters.Trn;
            mabnaCardGateway.ReturnUrl = parameters.ReturnUrl;
            mabnaCardGateway.PurchaseLink = parameters.PurchaseLink;
        }

        public void Visit(SadadSwitch1Gateway sadadSwitch1Gateway, PaymentParameters parameters)
        {
            sadadSwitch1Gateway.MerchantId = parameters.MerchantId;
            sadadSwitch1Gateway.TerminalId = parameters.TerminalId;
            sadadSwitch1Gateway.TransactionKey = parameters.TransactionKey;
            sadadSwitch1Gateway.Amount = parameters.Amount;
            sadadSwitch1Gateway.OrderId = parameters.OrderId;
            sadadSwitch1Gateway.ReturnUrl = parameters.ReturnUrl;
            sadadSwitch1Gateway.PurchaseLink = parameters.PurchaseLink;
            sadadSwitch1Gateway.RequestKey = parameters.RequestKey;
        }
    }
}
            