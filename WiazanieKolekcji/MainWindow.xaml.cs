using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace WiazanieKolekcji
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Produkt> ListaProduktow = null;
        private CollectionViewSource viewSource;

        public MainWindow()
        {
            InitializeComponent();
            PrzygotujWiazanie();
        }

        private void PrzygotujWiazanie()
        {
            ListaProduktow = new ObservableCollection<Produkt>
            {
                new Produkt("O1-11", "Ołówek", 8, "Katowice 1"),
                new Produkt("PW-20", "Pióro wieczne", 75, "Katowice 2"),
                new Produkt("DZ-10", "Długopis żelowy", 121, "Katowice 1"),
                new Produkt("DZ-12", "Długopis kulkowy", 280, "Katowice 2")
            };

            viewSource = new CollectionViewSource { Source = ListaProduktow };
            viewSource.View.Filter = FiltrUzytkownika;

            lstProdukty.ItemsSource = viewSource.View;

            viewSource.View.SortDescriptions.Add(new SortDescription("Magazyn", ListSortDirection.Ascending));
            viewSource.View.SortDescriptions.Add(new SortDescription("Nazwa", ListSortDirection.Ascending));
        }

        private bool FiltrUzytkownika(object item)
        {
            if (string.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as Produkt).Nazwa?.Contains(txtFilter.Text, StringComparison.OrdinalIgnoreCase) ?? false);
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewSource.View.Refresh();
        }

        private void btnUsunProdukt_Click(object sender, RoutedEventArgs e)
        {
            if (lstProdukty.SelectedItem is Produkt wybranyProdukt)
            {
                ListaProduktow.Remove(wybranyProdukt);
                viewSource.View.Refresh();
            }
        }

        private void btnDodajProdukt_Click(object sender, RoutedEventArgs e)
        {
            Produkt nowyProdukt = new Produkt("", "Nowy Produkt", 0, "Magazyn");
            ListaProduktow.Add(nowyProdukt);
            viewSource.View.Refresh();
        }
    }
}
