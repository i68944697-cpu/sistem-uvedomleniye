using System;
using System.Collections.Generic;

namespace NotificationSystem
{
    public interface INotifier
    {
        void Send(string message);
    }
    public class EmailNotifier : INotifier
    {
        public void Send(string message) =>
            Console.WriteLine($"[Email]: Отправлено письмо. Текст: \"{message}\"");
    }
    public class SmsNotifier : INotifier
    {
        public void Send(string message) =>
            Console.WriteLine($"[SMS]: Отправлено сообщение на телефон. Текст: \"{message}\"");
    }

    public class TelegramNotifier : INotifier
    {
        public void Send(string message) =>
            Console.WriteLine($"[Telegram]: Отправлено сообщение в чат. Текст: \"{message}\"");
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<INotifier> notifiers = new List<INotifier>
            {
                new EmailNotifier(),
                new SmsNotifier(),
                new TelegramNotifier()
            };
            Console.Write("Введите текст уведомления: ");
            string userMessage = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userMessage))
            {
                userMessage = "Интерфейсы — это круто!";
            }

            Console.WriteLine("\n--- Запуск рассылки ---");
            foreach (var notifier in notifiers)
            {
                notifier.Send(userMessage);
            }
        }
    }
}
