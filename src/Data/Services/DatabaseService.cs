using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoRepository;
using Spoofi.FreudBot.Data.Entities;
using Spoofi.FreudBot.Data.Mappings;
using Spoofi.FreudBot.Data.Mongo;
using TelegramMessage = Telegram.Bot.Types.Message;
using TelegramUser = Telegram.Bot.Types.User;

namespace Spoofi.FreudBot.Data.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly MongoRepository<User> _userRepository;

        public DatabaseService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
            _userRepository = _repositoryFactory.GetRepository<User>();
        }

        public Message SaveMessage(TelegramMessage telegramMessage, bool isReceived = true)
        {
            var messageRepository = _repositoryFactory.GetRepository<Message>();
            var message = telegramMessage.Convert();
            message.IsReceived = isReceived;
            messageRepository.Add(message);
            return message;
        }

        public void SaveOrUpdateUserAsync(TelegramUser telegramUser)
        {
            Task.Run(() =>
            {
                var userRepository = _userRepository;
                var user = userRepository.SingleOrDefault(u => u.UserId == telegramUser.Id);
                userRepository.Update(user ?? telegramUser.Convert());
            });
        }

        public void SaveErrorAsync(Exception exception)
        {
            Task.Run(() => _repositoryFactory.GetRepository<Error>().Add(exception.Convert()));
        }

        public IEnumerable<UserCommand> GetCommandsByChat(int chatId)
        {
            return _repositoryFactory.GetRepository<UserCommand>()
                .Where(x => x.ChatId == chatId);
        }

        private User GetUserByUserId(int userId)
        {
            return _userRepository.SingleOrDefault(u => u.UserId == userId);
        }

        private User GetUserByUsername(string username)
        {
            return _userRepository.SingleOrDefault(u => u.UserName == username);
        }

        public IEnumerable<User> GetAllowedUsers()
        {
            return _userRepository.Where(u => u.IsAllowed);
        }

        private User UserAllow(User user)
        {
            if (user == null) return null;
            user.IsAllowed = true;
            return _userRepository.Update(user);
        }

        public User UserAllow(int userId)
        {
            return UserAllow(GetUserByUserId(userId));
        }

        public User UserAllow(string username)
        {
            return UserAllow(GetUserByUsername(username));
        }

        private User UserDisallow(User user)
        {
            if (user == null) return null;
            user.IsAllowed = false;
            return _userRepository.Update(user);
        }

        public User UserDisallow(int userId)
        {
            return UserDisallow(GetUserByUserId(userId));
        }

        public User UserDisallow(string username)
        {
            return UserDisallow(GetUserByUsername(username));
        }

        public UserCommand GetCommandByChat(int chatId, string command)
        {
            return GetCommandsByChat(chatId).FirstOrDefault(x => x.ChatId == chatId && x.Command == command);
        }

        public void SaveUserCommand(UserCommand command)
        {
            _repositoryFactory.GetRepository<UserCommand>().Add(command);
        }
    }
}