using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

using System;

namespace Queue_In_Azure_Demo
{
    public class Program
    {
        private static string StorageAccountConnectionString = "DefaultEndpointsProtocol=https;AccountName=stsollersaccount;AccountKey=ajQ5sGYUVY5cVjpANpHeWxWkvF8cU7cO5OLn3Fao4kxdhJ9PNLgEYW+2ghSwIJ6O/QeXr9YADFrq+ASt3FYNYw==;EndpointSuffix=core.windows.net";
        private static string qName = "appqueuedemo";
        static void Main(string[] args)
        {
            QueueClient qClient = new QueueClient(StorageAccountConnectionString, qName);

            if(qClient.Exists())
            {
                PeekedMessage[] peekMessage = qClient.PeekMessages(3);
                foreach(PeekedMessage peekedMessage in peekMessage) 
                {
                    Console.WriteLine($"Message ID: {peekedMessage.MessageId}\nMessage Body:{peekedMessage.Body}\n" +
                        $"Time when Message will expires {peekedMessage.ExpiresOn}");
                }
                
            }
            Console.WriteLine("Message succesfully sent!");
            Console.ReadLine();
        }
    }
}
