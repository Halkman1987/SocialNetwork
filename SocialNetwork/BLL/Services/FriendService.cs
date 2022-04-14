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
            var findUserEntity = userRepository.FindByEmail(friend.FriendEmail);
            if (findUserEntity is null) throw new UserNotFoundException();
            var userFriend = new FriendEntity()
            {
                user_id = friend.UserId,
                friend_id = findUserEntity.id
            };
            if(this.friendRepository.Create(userFriend) == 0)
                throw new Exception();
        }
       
        public IEnumerable<User> ViewAllFriend(User user)
        {
            var allFriend = friendRepository.FindAllByUserId(user.Id)
                .Select(fr => fr.friend_id);


            return allFriend;
        }

    }
}
