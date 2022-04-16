using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    
    public class UserMenuView
    {
        UserService userService;
        public UserMenuView(UserService userService)
        {
            this.userService = userService;
        }
        
        public void Show(User user)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("Друзей добавленно :{0}", user.Friends.Count());
                Console.WriteLine("Вы в друзьях добавленны :{0}", user.FriendsOff.Count());
                Console.WriteLine("Входящие сообщения : {0}", user.IncomingMessages.Count());
                Console.WriteLine("Исходящие сообщения : {0}", user.OutgoingMessages.Count());
                Console.WriteLine("Посмотреть информацию о моем профиле ( нажмите 1 )");
                Console.WriteLine("Редактировать мой профиль ( нажмите 2 )");
                Console.WriteLine("добавить в Друзья ( нажмите 3 )");
                Console.WriteLine("Посмотреть Друзей ( нажмите 4 )");
                Console.WriteLine("Написать сообщение  ( нажмите 5 )");
                Console.WriteLine("Посмотреть входящие сообщения ( нажмите 6 )");
                Console.WriteLine("Посмотреть исходящие сообщения ( нажмите 7 )");
                Console.WriteLine("Выйти из профиля  ( нажмите 8 )");
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine();
                string keyValue = Console.ReadLine();
                
                if (keyValue == "8") break;
                switch (keyValue)
                {
                    case "1":
                        {
                            Program.userInfoView.Show(user);
                            break;
                        }
                    case "2":
                        {
                            Program.userDataUpdateView.Show(user);
                            break;
                        }
                    case "3":
                        {
                            Program.userFriendsView.AddFriend(user);
                            break;
                        }
                    case "4":
                        {
                            Program.userFriendsView.ViewAllFriends(user);
                            break;
                        }

                    case "5":
                        {
                            Program.messageSendingView.Show(user);
                            break;
                        }
                    case "6":
                        {
                            Program.userIncomingMessageView.Show(user.IncomingMessages);
                            break;
                        }
                    case "7":
                        {
                            Program.userOutcomingMessageView.Show(user.OutgoingMessages);
                            break;
                        }
                }
            }
        }
    }
}
