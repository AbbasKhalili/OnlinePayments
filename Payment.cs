using System;
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
    public abstract class Payment
    {
        public abstract void AcceptVisitor(IVisitor visitor, PaymentParameters parameters);

        public string GetDescription(int ipgId, int resCode)
        {
            var code = resCode >= 0 ? "plus" + resCode : "_" + Math.Abs(resCode);
            switch (ipgId)
            {
                case 1001: { return IKCResource.ResourceManager.GetString(code); }
                case 1002: { return SadadResource.ResourceManager.GetString(code); }
                case 1003: { return TejarateleParsianResource.ResourceManager.GetString(code); }
                case 1004: { return BehPardakhtResource.ResourceManager.GetString(code); }
                case 1006: { return AsanPardakhtResource.ResourceManager.GetString(code); }
                case 1007: { return MabnaCardResource.ResourceManager.GetString(code); }
                case 1008: { return SadadResourceSwitch1.ResourceManager.GetString(code); }
            }
            return "";
        }
    }
}
