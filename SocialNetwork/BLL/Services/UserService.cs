using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class UserService
    {
        IUserRepository userRepository;
        MessageService messageService;
        IFriendRepository friendRepository;
        public UserService()
        {
            userRepository = new UserRepository();
            messageService = new MessageService();
            friendRepository = new FriendRepository();
        }

        public void Register(UserRegistrationData userRegistrationData)
        {
            if (String.IsNullOrEmpty(userRegistrationData.FirstName))
                throw new ArgumentNullException();

            if (String.IsNullOrEmpty(userRegistrationData.LastName))
                throw new ArgumentNullException();

            if (String.IsNullOrEmpty(userRegistrationData.Password))
                throw new ArgumentNullException();

            if (String.IsNullOrEmpty(userRegistrationData.Email))
                throw new ArgumentNullException();

            if (userRegistrationData.Password.Length < 8)
                throw new ArgumentNullException();

           if (!new EmailAddressAttribute().IsValid(userRegistrationData.Email))
               throw new ArgumentNullException();

            if (userRepository.FindByEmail(userRegistrationData.Email) != null)
           throw new ArgumentNullException();

            var userEntity = new UserEntity()
            {
                firstname = userRegistrationData.FirstName,
                lastname = userRegistrationData.LastName,
                password = userRegistrationData.Password,
                email = userRegistrationData.Email
            };

            if (this.userRepository.Create(userEntity) == 0)
                throw new Exception();

        }

        
        
        public User Authenticate(UserAuthenticationData userAuthenticationData)
        {
            var findUserEntity = userRepository.FindByEmail(userAuthenticationData.Email);
            if (findUserEntity is null) throw new UserNotFoundException();

            if (findUserEntity.password != userAuthenticationData.Password)
            {
                throw new WrongPasswordException();

            }
            return ConstructUserModel(findUserEntity);
        }
       
        
        public User FindByEmail(string email)
        {
            var findUserEntity = userRepository.FindByEmail(email);
            if (findUserEntity is null) throw new UserNotFoundException();

            return ConstructUserModel(findUserEntity); 
        }
       
        
        public void Update(User user)
        {
            var updateUserEntity = new UserEntity()
            {
                id = user.Id,
                firstname = user.FirstName,
                lastname = user.LastName,
                password = user.Password,
                email = user.Email,
                photo = user.Photo,
                favorite_movie = user.FavoriteMovie,
                favorite_book = user.FavoriteBook
            };
            if (this.userRepository.Update(updateUserEntity) == 0)
                throw new Exception();
        }

        private User ConstructUserModel(UserEntity userEntity)
        {
            var incommes = messageService.GetIncomingMessagesUserId(userEntity.id);
            var outcommes = messageService.GetOutcomingMessagesUserId(userEntity.id);
            var friends = UserFriends(userEntity.id);
            var friendsOff = UserFriendsOff(userEntity.id);
            return new User(userEntity.id,
                userEntity.firstname,
                userEntity.lastname,
                userEntity.password,
                userEntity.email,
                userEntity.photo,
                userEntity.favorite_movie,
                userEntity.favorite_book,
                incommes,
                outcommes,
                friends,
                friendsOff
                );
        }
        public IEnumerable<User> UserFriends(int userid)//полученине 
        {
           var  friends = friendRepository.FindAllByUserId(userid).
                Select(fr => FindById(fr.friend_id));
            return friends;
        }
        public User FindById(int id)
        {
            var findUserEntity = userRepository.FindById(id);
            if (findUserEntity is null) throw new UserNotFoundException();

            return ConstructUserModel(findUserEntity);
        }
        public IEnumerable<User> UserFriendsOff(int userid)//полученине 
        {
            
            var friends = friendRepository.FindAllByUserId(userid).Where(fr => fr.friend_id == userid).
                 Select(fr => FindById(fr.user_id));
            return friends;
        }

        public IEnumerable<UserEntity> AllUserFriends()//полученине всех пользователей системы
        {
            var friends = userRepository.FindAll();
            return friends;
        }
    }
   
}
