using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class UserFriendsView
    {
        FriendService friendService;

        public UserFriendsView(FriendService friendService)
        {
            this.friendService = friendService;
        }

       
        public void AddFriend(User user)
        {
            try
            {
                var addFriend = new Friend();
                Console.WriteLine("Введите Email-адресс пользователя для добавления в друзья :");
                addFriend.FriendEmail = Console.ReadLine();
                addFriend.FriendId = user.Id;
                this.friendService.AddFriend(addFriend);
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователя с таким Email нету");
            }
            catch (Exception)
            {
                AlertMessage.Show("Ошибка при добалении");
            }
        }
        public void ViewAllFriends(User user)
        {
           var all = friendService.ViewAllFriend(user);//ВОЗВРАЩАЕМ FriendEntity 
            all.ToList().ForEach(friend =>
            {
                Console.WriteLine("Почтовый адрес друга: {0}. Имя друга: {1}", friend.user_id, friend.friend_id);
            });
            Console.WriteLine("-----");
        }
    }
}
  