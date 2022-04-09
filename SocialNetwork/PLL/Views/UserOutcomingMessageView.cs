using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class UserOutcomingMessageView
    {
        public void Show(IEnumerable<Message> incomingmess)
        {
            Console.WriteLine("Исходящие сообщения");
            if (incomingmess.Count() == 0)
            {
                Console.WriteLine(" Исходящих нет сообщений");
                return;
            }
            incomingmess.ToList().ForEach(m =>
            {
                Console.WriteLine("От кого :{0}, Текст сообщения : {1}", m.RecipientEmail, m.Content);
            });

        }
    }
}
