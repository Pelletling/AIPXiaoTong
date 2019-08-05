using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model.Site
{
    public class MemberDM : BaseDetailsModel
    {
        public AccountGuangDa AccountGuangDa { get; set; }
        public AccountPingAn AccountPingAn { get; set; }
        public string Name { get; set; }
        public string IDNumber { get; set; }
        public string Mobile { get; set; }

        //--------------------光大 详情------------------------
        public string ProvinceCode { get; set; }
        public string ProvinceName { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
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
        public string BankCardNumber { get; set; }

        //------------------------平安 详情------------------------------------
        public decimal? PingAnBalance { get; set; }
        public decimal? PingAnFreezeBalance { get; set; }
        public DateTime? PingAnIdExpiredDate { get; set; }
        public string PingAnIDImageFront { get; set; }
        public string PingAnIDImageOpposite { get; set; }
        public string PingAnBankCardNumber { get; set; }
        public string PingAnOutCardNo { get; set; }

    }
}
