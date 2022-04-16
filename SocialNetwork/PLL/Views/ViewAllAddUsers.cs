using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class ViewAllAddUsers
    {
        UserService userService;

        public ViewAllAddUsers(UserService userService)
        {
            this.userService = userService;
        }
        public void Show()
        {
            var all = userService.AllUserFriends();
            foreach(var f in all)
            {
              
                SuccessMessage.Show($"Почтовый адрес друга: {f.email}. Имя друга: {f.firstname}. Пароль {f.password}");
            }
        }
    }
}
