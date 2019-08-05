using AIPXiaoTong.Model;
using AIPXiaoTong.Model.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.IService
{
    public interface IOrderBookingService : IBusinessService<OrderBooking>
    {
        List<OrderBookingEM> Export(OrderBookingQM model = null);
    }
}
