using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

using SocialNetwork.PLL.Views;
using SocialNetwork.PLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{
    class Program
    {
        static MessageService messageService;
        static UserService userService ;
        static FriendService friendService;
        
        public static AuthenticationView authenticationView;
        public static MainView mainView;
        public static MessageSendingView messageSendingView;
        public static RegistrationView registrationView;
        public static UserDataUpdateView userDataUpdateView;
        public static UserIncomingMessageView userIncomingMessageView;
        public static UserInfoView userInfoView;
        public static UserMenuView userMenuView;
        public static UserOutcomingMessageView userOutcomingMessageView;
        public static UserFriendsView userFriendsView;
        public static ViewAllAddUsers viewAllAddUsers;

        static void Main(string[] args)
        {
           
            userService = new UserService();
            messageService = new MessageService();
            friendService = new FriendService();

            mainView = new MainView();
            authenticationView = new AuthenticationView(userService);
            registrationView = new RegistrationView(userService);
            userMenuView = new UserMenuView(userService);
            userInfoView = new UserInfoView();
            userDataUpdateView = new UserDataUpdateView(userService);
            messageSendingView = new MessageSendingView(messageService,userService);
            userIncomingMessageView = new UserIncomingMessageView();
            userOutcomingMessageView = new UserOutcomingMessageView();
            userFriendsView = new UserFriendsView(friendService);
            viewAllAddUsers = new ViewAllAddUsers(userService);



            while (true)
            {
                mainView.Show();
            }
            


            
           
           
        }
    }

}