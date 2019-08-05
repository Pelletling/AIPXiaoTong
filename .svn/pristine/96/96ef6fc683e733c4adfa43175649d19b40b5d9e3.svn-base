using Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.Admin
{
    public class MemberLM : BaseListModel
    {
        private int? accountBank;
        public MemberLM()
        {
            accountBank = UserHelper.GetCurrentUser()?.AccountBank;
        }
        public string Name { get; set; }
        public string IDNumber { get; set; }
        public string Mobile { get; set; }
        public string ProvinceCode { get; set; }
        public string CityCode { get; set; }
        public string IDImageFront { get; set; }
        public string IDImageOpposite { get; set; }
        public string Address { get; set; }
        public string ClientId { get; set; }
        public string EnName { get; set; }
        public DateTime? IdExpiredDate { get; set; }
        public string PostCode { get; set; }
        public int IsCreateAccount { get; set; }

        public decimal? GuangDaBalance { get; set; }
        public decimal? GuangDaFreezeBalance { get; set; }
        public decimal? PingAnBalance { get; set; }
        public decimal? PingAnFreezeBalance { get; set; }
        public decimal? Balance
        {
            get
            {
                if (accountBank == AccountBankOption.GuangDa.ToInt())
                {
                    return GuangDaBalance;
                }
                if (accountBank == AccountBankOption.PingAn.ToInt())
                {
                    return PingAnBalance;
                }
                return 0;
            }
        }
        public decimal? FreezeBalance
        {
            get
            {
                if (accountBank == AccountBankOption.GuangDa.ToInt())
                {
                    return GuangDaFreezeBalance;
                }
                if (accountBank == AccountBankOption.PingAn.ToInt())
                {
                    return PingAnFreezeBalance;
                }
                return 0;
            }
        }

        public IList<OrderPaid> OrderPaidList { get; set; }

        public MerchantMember MerchantMember { get; set; }

    }
}
