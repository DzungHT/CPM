using CPM_Website.Models;
using CPM_Website.Models.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CPM_Website.Models.DAOs
{
    public class AccountDAO
    {
        private dbContext db;

        public AccountDAO()
        {
            db = new dbContext();
        }

        /// <summary>
        /// Kiểm tra đăng nhập.
        /// Đăng nhập thành công trả về thông tin tài khoản
        /// </summary>
        /// <param name="loginViewModel">Thông tin đăng nhập</param>
        /// <param name="accInfo">Thông tin tài khoản</param>
        /// <returns>True: nếu đăng nhập thành công</returns>
        public User CheckLogin(LoginViewModel loginViewModel)
        {
            User accInfo = null;
            User acc = db.Users.FirstOrDefault(x => x.LoginName.Equals(loginViewModel.Username)
                                                       && x.Password.Equals(loginViewModel.Password)
                                                    );

            // Nếu acc != null => khớp username và password => đăng nhập thành công => chuyển hướng đến url
            // Nếu acc == null => không khớp username và password => đăng nhập thất bại => chuyển lại về trang đăng nhập
            if (acc != null)
            {
                accInfo = acc;
                accInfo.Password = null;
            }
            return accInfo;

        }
    }
}