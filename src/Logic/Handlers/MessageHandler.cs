using System;
using System.Linq;
using Spoofi.FreudBot.Data.Services;
using Spoofi.FreudBot.Logic.Bot;
using Spoofi.FreudBot.Logic.Handlers.Interfaces;
using Spoofi.FreudBot.Utils.Extensions;
using Telegram.Bot.Types;

namespace Spoofi.FreudBot.Logic.Handlers
{
    public class MessageHandler : IMessageHandler
    {
        private readonly IBotManager _bot;
        private readonly IDatabaseService _db;
        private readonly IUserCommandHandler _commandHandler;

        public MessageHandler(IDatabaseService databaseService, IBotManager botManager, IUserCommandHandler commandHandler)
        {
            _bot = botManager;
            _db = databaseService;
            _commandHandler = commandHandler;
        }

        public void Handle(Message message)
        {
            try
            {
                //TODO fix dublicate messages
                if (!CheckPermission(message)) return;

                if (message.IsText())
                    HandleText(message);

                if (message.IsCommand())
                    HandleCommand(message);
            }
            catch (Exception exception)
            {
                _db.SaveError(exception);
            }
        }

        private static bool CheckPermission(Message message)
        {
            return Config.BotAllowedUsers.Contains(message.Chat.Id);
        }

        private void HandleText(Message message)
        {
            //_bot.SendText(message.Chat.Id, string.Format("Ответ на {0} - {1}", message.MessageId, message.Text));
        }

        private void HandleCommand(Message message)
        {
            switch (message.Text.Split(' ').First())
            {
                case "/start":
                    _bot.SendText(message.Chat.Id, "Привет! Я еще мало что умею, поэтому сильно меня мучить не нужно :)");
                    break;
                case "/help":
                    _bot.SendText(message.Chat.Id, string.Format("Доступные команды можно просмотреть, набрав команду /list \n\n" +
                                                                 "Примечение: чтобы использовать все доступные команды, нужно быть в списке разрешенных пользователей.\n\n" +
                                                                 "Ваш идентификатор чата {0} - передайте его @spoofi, чтобы внести Вас в список.", message.Chat.Id));
                    break;
                case "/add":
                    _commandHandler.AddCommand(message);
                    break;
                case "/list":
                    var commands = _commandHandler.GetCommandsByChat(message.Chat.Id).Select(x => x.Command);
                    _bot.SendText(message.Chat.Id, string.Format("Доступные вам команды:\n{0}", string.Join("\n", commands)));
                    break;
                default:
                    if (_commandHandler.Execute(message))
                        break;
                    _bot.SendText(message.Chat.Id, "Извините, я не умею выполнять эту команду :(");
                    break;
            }
        }
    }
}