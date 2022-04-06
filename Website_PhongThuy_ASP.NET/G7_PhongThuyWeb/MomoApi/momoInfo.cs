using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_MoMo
{
    public class momoInfo
    {
        public static readonly string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
        public static readonly string partnerCode = "MOMOJCMD20211121";
        public static readonly string accessKey = "3RnGB4R8by0oznIS";
        public static readonly string serectkey = "cbibiCOPOTmqW4mX0iVtfrbqoz94X8WK";
        public static readonly string orderInfo = "Shop Phong Thủi";
        public static readonly string returnUrl = "https://localhost:44322/Cart/confirm_orderPaymentOnline_momo";
        public static readonly string notifyurl = "https://localhost:44322/cancel-order";
    }
}