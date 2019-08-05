using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TltApi
{
    public static class Extend
    {
        public static StatusOption GetStatus(this Model.SingleOntimePayResponse response)
        {
            List<string> WaitCodeList = new List<string> { "2000", "2001", "2003", "2005", "2007", "2008", "1108", "1000" };

            if (response.INFO.RET_CODE == "0000" || response.INFO.RET_CODE == "4000")
            {
                return StatusOption.Success;
            }
            else if (WaitCodeList.Contains(response.INFO.RET_CODE))
            {
                return StatusOption.Wait;
            }
            else
            {
                return StatusOption.Fail;
            }
        }


        public static StatusOption GetStatus(this Model.QueryTltTradingResultResponse.Qtransrsp.Qtdetail qtdetail, string infoCode)
        {
            var detailCode = qtdetail.RET_CODE;

            if (infoCode == "0000" || infoCode == "4000")
            {
                if (detailCode == "0000" || detailCode == "4000")
                {
                    return StatusOption.Success;
                }
                else
                {
                    return StatusOption.Fail;
                }
            }
            else if (infoCode == "1000")
            {
                return StatusOption.Wait;
            }
            else if (infoCode == "1002")
            {
                return StatusOption.StopWait;
            }
            else if (infoCode == "2002" || infoCode == "2004" || infoCode == "2006")
            {
                return StatusOption.Fail;
            }
            else if (infoCode == "2000" || infoCode == "2001" || infoCode == "2003" || infoCode == "2005" || infoCode == "2007" || infoCode == "2008")
            {
                if (detailCode == "0000" || detailCode == "4000")
                {
                    return StatusOption.Success;
                }
                else
                {
                    return StatusOption.Fail;
                }
            }
            else
                return StatusOption.Wait;
        }
    }
}
