using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class UserIncomingMessageView
    {
       
        public void Show(IEnumerable<Message> incomingmess)
        {
            Console.WriteLine("Входящие сообщения");
            if(incomingmess.Count() == 0)
            {
                Console.WriteLine(" Входящих нет сообщений");
                return;
            }
            incomingmess.ToList().ForEach(m =>
            {
                Console.WriteLine("От кого :{0}, Текст сообщения : {1}", m.SenderEmail, m.Content);
            });

        }
    }
}
