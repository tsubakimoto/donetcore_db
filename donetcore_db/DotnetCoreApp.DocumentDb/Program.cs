using DotnetCoreApp.Shared.Models;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using static System.Console;

namespace DotnetCoreApp.DocumentDb
{
    class Program
    {
        private static readonly Uri serviceEndpoint = new Uri("");
        private static readonly string authKey = "";

        static void Main(string[] args)
        {
            var client = new DocumentClient(serviceEndpoint, authKey);
            var collectionUri = UriFactory.CreateDocumentCollectionUri("fukuten", "users");

            // データ登録
            //client.CreateDocumentAsync(collectionUri, new User { Id = 1, Name = "yuta" });
            //client.CreateDocumentAsync(collectionUri, new User { Id = 2, Name = "tsubaki" });

            // データ取得
            var queryOptions = new FeedOptions { MaxItemCount = -1 };
            var findQuery = client.CreateDocumentQuery<dynamic>(collectionUri, queryOptions);
            foreach (var user in findQuery)
            {
                //WriteLine(user.ToString());
                WriteLine($"{user.Id}\t{user.Name}");
            }

            ReadLine();
        }
    }
}