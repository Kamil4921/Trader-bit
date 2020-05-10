using System;
using System.Collections.Generic;
using System.Linq;
using TraderLibrary;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Models;
using System.IO;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace Trader
{
    public sealed partial  class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ApiHelper.InitializeClient();
        }
        
        private async void LoadTrades_Click(object sender, RoutedEventArgs e)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync("sample.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            var trademodels = await TradeProcessor.LoadTrades();
            using (StreamWriter streamW = new StreamWriter(sampleFile.Path, true))
            {
                streamW.WriteLine($"{DateTime.Now} Wczytano 300 tradow");
            }
            
            Price.Text = $"Cena: {trademodels[0].R}";
            Amoundof.Text = $"Ilosc: {trademodels[0].A}";
            Time.Text = $"Czas: {trademodels[0].T}";
            Type.Text = $"Typ: {trademodels[0].Ty}";
            Id.Text = $"Id: {trademodels[0].Id}";
            using (StreamWriter streamW = new StreamWriter(sampleFile.Path, true))
            {
                streamW.WriteLine($"{DateTime.Now} Wyświetlono ostatni trade");
            }
            var trades = new List<Trade>();
            foreach (var trade in trademodels)
            {
                trades.Add(trade.ToTrade());
            }

            TraderContext context = null;
            try
            {
                context = new TraderContext();
                foreach (var trade in trades)
                {
                    if (!context.Trades.Any(t => t.Tid == trade.Tid))
                    {
                        context.Trades.Add(trade);
                        using (StreamWriter streamW = new StreamWriter(sampleFile.Path, true))
                        {
                            streamW.WriteLine($"{DateTime.Now} Dodano do bazy trade {trade}");
                        }
                    }
                }
                context.SaveChanges();
            }
            finally
            {
                if (context != null) context.Dispose();
            }
            
        }
    }
}
