using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
        
    public interface IUserAccountDAL
    {
        /// <summary>
        ///  kiểm tra username và password có hợp lệ không
        ///  Nếu hợp lệ thì trả về hệ thống của user
        ///  Ngược lại thì trả về giá trị null
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        UserAccount Authorize(string userName, string password);
    }
}
