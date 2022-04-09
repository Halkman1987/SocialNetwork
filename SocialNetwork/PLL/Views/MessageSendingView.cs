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
    public class MessageSendingView
    {
        UserService userService;
        MessageService messageService;

        public MessageSendingView(MessageService messageService, UserService userService)
        {
            this.userService = userService;
            this.messageService = messageService;
        }
        public void Show(User user)
        {
            var messageSendingData = new MessageSendingData();
            Console.WriteLine("Введите почтовый адресс получателя");
            messageSendingData.RecipientEmail = Console.ReadLine();
            Console.WriteLine("Введите сообщения (не больше 5000 символов)");
            messageSendingData.Content = Console.ReadLine();
            messageSendingData.SenderId = user.Id;
            try
            {
                messageService.SendMessage(messageSendingData);
                SuccessMessage.Show("Сообщение успешно отправленно");
                user = userService.FindByEmail(user.Id);
            }
            catch (UserNotFoundException)
            {
                Console.WriteLine("Пользователь не найден");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Введите корректное значение");
            }
            catch (Exception)
            {
                Console.WriteLine("произошла ошибка при отправке сообщения");
            }
        }
    }
}
