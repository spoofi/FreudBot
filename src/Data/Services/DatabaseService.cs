using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        
        public DatabaseService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
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
                var userRepository = _repositoryFactory.GetRepository<User>();
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

        private IQueryable<User> GetUsers()
        {
            return _repositoryFactory.GetRepository<User>();
        }

        public IEnumerable<User> GetAllowedUsers()
        {
            return GetUsers().Where(u => u.IsAllowed);
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