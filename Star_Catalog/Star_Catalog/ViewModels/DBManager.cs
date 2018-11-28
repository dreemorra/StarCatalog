using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using CsvHelper;
using System.Globalization;
using Star_Catalog.Models;
using System.Threading;

namespace Star_Catalog.ViewModels
{
    class DBManager
    {
        //public void DownloadCSV()
        //{
        //    try
        //    {
        //        var client = CrossDownloadManager.Current;
        //        //Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "download"));
        //        client.PathNameForDownloadedFile = (s) => { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "hygdata_v3.csv"); };
        //        var file = client.CreateDownloadFile("https://raw.githubusercontent.com/astronexus/HYG-Database/master/hygdata_v3.csv");
        //        client.Start(file);
        //        //while (true)
        //        //{
        //        //    System.Diagnostics.Debug.WriteLine(file.Status);
        //        //    System.Diagnostics.Debug.WriteLine(file.TotalBytesExpected);
        //        //    System.Diagnostics.Debug.WriteLine(file.DestinationPathName);
        //        //    System.Diagnostics.Debug.WriteLine(csvPath);
        //        //    Thread.Sleep(1000);
        //        //}
        //        File.Move(file.DestinationPathName, csvPath);
        //        System.Diagnostics.Debug.WriteLine(csvPath);
        //        System.Diagnostics.Debug.WriteLine(new FileInfo(csvPath).Length);
        //    }
        //    catch (Exception e)
        //    {
        //        System.Diagnostics.Debug.WriteLine(e.StackTrace);
        //        if (!(e is NullReferenceException))
        //            throw e;
        //    }
        //}

        NumberFormatInfo nfi = NumberFormatInfo.InvariantInfo;
        public string csvPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "hygdata_v3.csv");
        private string DBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Database.db3");

        private SQLiteAsyncConnection database = null;

        public SQLiteAsyncConnection Database
        {
            get
            {
                if (database == null)
                {
                    database = new SQLiteAsyncConnection(DBPath);
                    database.CreateTableAsync<Star>().Wait();
                }
                return database;
            }
        }

        public async Task RemoveAsync(Star entry)
        {
            await Database.DeleteAsync(entry);
        }

        public async Task AddAsync(Star entry)
        {
            if ((await Database.QueryAsync<Star>($"SELECT * FROM [Star] WHERE ID = {entry.ID} LIMIT 1")).Count != 0)
                await Database.UpdateAsync(entry);
            else
                await Database.InsertAsync(entry);
        }

        public void Add(Star entry)
        {
            Task.Run(() => AddAsync(entry)).GetAwaiter().GetResult();
        }

        public async Task UpdateDatabaseFromCSV(string csvPath)
        {
            int counter = 0;
            var reader = new CsvParser(File.OpenText(csvPath));
            var headers = await reader.ReadAsync();
            for (var line = await reader.ReadAsync(); line != null; line = await reader.ReadAsync())
            {
                var dict = new Dictionary<string, string>();
                for (int i = 0; i < headers.Length; i++)
                    dict.Add(headers[i], line[i]);

                try
                {
                    var newStar = new Star()
                    {
                        ID = int.Parse(dict["id"]),
                        ProperName = dict["proper"],
                        HIP = dict["hip"],
                        Magnitude = double.Parse(dict["mag"], nfi),
                        Distance = double.Parse(dict["dist"], nfi),
                        Luminocity = double.Parse(dict["lum"], nfi),
                        RadialVelocity = double.Parse(dict["rv"], nfi),
                        Spectrum = dict["spect"],
                        ColorIndex = (dict["ci"].Length == 0 ? 1.15 : double.Parse(dict["ci"], nfi)),
                        ConstellationName = dict["con"]
                    };
                    if (newStar.ProperName.Length != 0)
                    {
                        await AddAsync(newStar);
                        System.Diagnostics.Debug.WriteLine($"Added {++counter} stars");
                        //Console.SetCursorPosition(0, Console.CursorTop - 1);
                    }
                }
                catch
                {
                    for (int i = 0; i < headers.Length; i++)
                        System.Diagnostics.Debug.WriteLine($"{headers[i]}, {line[i]}");
                    return;
                }
            }
        }
    }
}