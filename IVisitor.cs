using OnlinePayment.AsanPardakht;
using OnlinePayment.BehPardakht;
using OnlinePayment.Contract;
using OnlinePayment.IranKish;
using OnlinePayment.MabnaCard;
using OnlinePayment.Sadad;
using OnlinePayment.TejarateleParsian;
using OnlinePayment.SadadSwitch1;

namespace OnlinePayment
{
    public interface IVisitor
    {
        void Visit(IranKishGateway iranKish, PaymentParameters parameters);
        void Visit(SadadSwitch2Gateway sadadSwitch2Gateway, PaymentParameters parameters);
        void Visit(TejaratParsianGateway tejaratParsianGateway, PaymentParameters parameters);
        void Visit(BehPardakhtGateway behPardakhtGateway, PaymentParameters parameters);
        void Visit(AsanPardakhtGateway asanPardakhtGateway, PaymentParameters parameters);
        void Visit(MabnaCardGateway mabnaCardGateway, PaymentParameters parameters);
        void Visit(SadadSwitch1Gateway sadadSwitch1Gateway, PaymentParameters parameters);
    }
}
