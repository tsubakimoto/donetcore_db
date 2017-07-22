using MongoDB.Driver;
using DotnetCoreApp.Shared.Models;
using System.Collections.Generic;
using static System.Console;

namespace DotnetCoreApp.Mongo
{
    class Program
    {
        private static readonly string connectionString = "";

        static void Main(string[] args)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("fukuten");
            database.CreateCollectionAsync("users");

            var collection = database.GetCollection<User>("users");

            // データ削除
            collection.DeleteMany(_ => true);

            // データ取得
            var data1 = collection.Find(_ => true).ToList();
            data1.ForEach(user => WriteLine(user.ToString()));

            // データ登録
            var users = new List<User>
            {
                new User { Id = 1, Name = "yuta" },
                new User { Id = 2, Name = "tsubaki" },
            };
            collection.InsertMany(users);

            // データ取得
            var data2 = collection.Find(_ => true).ToList();
            data2.ForEach(user => WriteLine(user.ToString()));

            ReadLine();
        }
    }
}