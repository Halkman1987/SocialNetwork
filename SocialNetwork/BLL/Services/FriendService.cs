using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository;
        UserRepository userRepository;
        public FriendService()
        {
            friendRepository = new FriendRepository();
            userRepository = new UserRepository();
        }
        public void AddFriend(Friend friend)
        {
            var findUserEntity = userRepository.FindByEmail(friend.FriendEmail);//поиск по Майлу с возвратом пользователя-UserEntity 
            if (findUserEntity is null) throw new UserNotFoundException();
            var userFriend = new FriendEntity()
            {
                user_id = friend.UserId,//кто дружит
                friend_id = findUserEntity.id //с кем дружит
            };
            if(this.friendRepository.Create(userFriend) == 0)//запись в репозиторий и бд сущности связки друг-друг
                throw new Exception();
        }

       

    }
}
