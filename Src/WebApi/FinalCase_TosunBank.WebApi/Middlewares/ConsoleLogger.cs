using System;

namespace WebAPI.Services
{
    public class ConsoleLogger : ILogService
    {
        public void Write(params object[] messageParams)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("[Console Logger]");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" | ");
            for (int i = 0; i < messageParams.Length; i += 2)
            {
                string text = messageParams[i + 1].ToString();

                Console.ForegroundColor = (ConsoleColor)messageParams[i]; 
                Console.Write(text);
            }

            Console.ResetColor();
            Console.WriteLine();
        }
    }
}