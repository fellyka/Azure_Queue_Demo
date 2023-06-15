using Azure.Storage.Queues;

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

            string messageToQueue = String.Empty;
            if(qClient.Exists())
            {
                for (int i = 0; i <= 6; i++)
                {
                    messageToQueue = $"This is Message number {i+1}";
                    qClient.SendMessage(messageToQueue);
                }
            }
            Console.WriteLine("Message succesfully sent!");
            Console.ReadLine();
        }
    }
}
