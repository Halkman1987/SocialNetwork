using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class Friend //для промежуточной инициализации сущности кто с кем дружить хочет
    {
       
        public int UserId { get; set; }//хозяин
        public string FriendEmail { get; set; }//друг
       
    }
}
