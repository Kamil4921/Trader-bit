using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TraderLibrary;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Models;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace Trader
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ApiHelper.InitializeClient();
        }

        private async void LoadTrades_Click(object sender, RoutedEventArgs e)
        {
            var trademodels = await TradeProcessor.LoadTrades();

            Price.Text = $"Cena: {trademodels[0].R}";
            Amoundof.Text = $"Ilosc: {trademodels[0].A}";
            Time.Text = $"Czas: {trademodels[0].T}";
            Type.Text = $"Typ: {trademodels[0].Ty}";
            Id.Text = $"Id: {trademodels[0].Id}";

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
