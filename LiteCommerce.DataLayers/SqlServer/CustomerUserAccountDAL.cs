using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteCommerce.DomainModels;

namespace LiteCommerce.DataLayers.SqlServer
{
    public class CustomerUserAccountDAL : UserAccountDAL
    {
        private string connectionString;
        public CustomerUserAccountDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public UserAccount Authorize(string userName, string password)
        {
            //TODO: Kiểm tra thông tin đăng nhập dựa vào bảng customer
            return new UserAccount()
            {
                UserID = userName,
                FullName = "Hoang",
                Photo = "b6.jpg"
            };
        }

    
    }
}
