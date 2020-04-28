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

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace Trader
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ApiHelper.InitializeClient();
        }

        private async void LoadTrades_Click(object sender, RoutedEventArgs e)
        {
            var trade = await TradeProcessor.LoadTrades();

            Price.Text = $"Cena: {trade[0].R}";
            Amoundof.Text = $"Ilosc: {trade[0].A}";
            Time.Text = $"Czas: {trade[0].T}";
            Type.Text = $"Typ: {trade[0].Ty}";
        }
    }
}
