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
    public class PaymentFactory
    {
        public static IPayment GetIpgPayment(PaymentParameters parameters)
        {
            var visitor = new FillRequiredFields();            
            switch (parameters.IpgId)
            {
                case 1001:
                    {
                        var irankish = new IranKishGateway();
                        irankish.AcceptVisitor(visitor, parameters);
                        return irankish;
                    }
                case 1002:
                    {
                        var sdsw1 = new SadadSwitch1Gateway();
                        sdsw1.AcceptVisitor(visitor, parameters);
                        return sdsw1;
                    }
                case 1003:
                    {
                        var sadad2 = new SadadSwitch2Gateway();
                        sadad2.AcceptVisitor(visitor, parameters);
                        return sadad2;
                    }
                case 1004:
                    {
                        var tejaratparsian = new TejaratParsianGateway();
                        tejaratparsian.AcceptVisitor(visitor, parameters);
                        return tejaratparsian;
                    }
                case 1005:
                    {
                        var behpardakht = new BehPardakhtGateway();
                        behpardakht.AcceptVisitor(visitor, parameters);
                        return behpardakht;
                    }
                case 1007:
                    {
                        var asanpardakht = new AsanPardakhtGateway();
                        asanpardakht.AcceptVisitor(visitor, parameters);
                        return asanpardakht;
                    }
                case 1008:
                    {
                        var mabna = new MabnaCardGateway();
                        mabna.AcceptVisitor(visitor, parameters);
                        return mabna;
                    }
            }
            return null;
        }
    }
}
