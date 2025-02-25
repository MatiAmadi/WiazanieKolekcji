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

namespace WiazanieKolekcji
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Produkt> ListaProduktow = null;

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

            lstProdukty.ItemsSource = ListaProduktow;

   
            CollectionView widok = (CollectionView)CollectionViewSource.GetDefaultView(lstProdukty.ItemsSource);

            widok.SortDescriptions.Add(new SortDescription("Magazyn", ListSortDirection.Ascending));
            widok.SortDescriptions.Add(new SortDescription("Nazwa", ListSortDirection.Ascending));
        }
    }

}
