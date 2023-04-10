using SHOPPINGCART.Domain.Entities;
using SHOPPINGCART.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOPPINGCART.Application.Services
{
    public class DashBoardReportService
    {
        private DashBoardReportRepository objdashboardReportRepository = new DashBoardReportRepository();

        public List<Reports> Sales(string startDate, string endingDate, string transactionId)
        {
            return objdashboardReportRepository.Sales(startDate, endingDate, transactionId);
        }

        public DashBoard ViewDashBoard()
        {
            return objdashboardReportRepository.ViewDashBoard();
        }



    }
}
