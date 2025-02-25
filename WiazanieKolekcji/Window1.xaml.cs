using System.Windows;

namespace WiazanieKolekcji
{
    public partial class Window1 : Window
    {
        private Produkt produkt;

        public Window1(Produkt produktDoEdycji)
        {
            InitializeComponent();
            produkt = produktDoEdycji;
            PrzygotujWiazanie();
        }

        private void PrzygotujWiazanie()
        {
            if (produkt != null)
            {
                txtSymbol.Text = produkt.Symbol;
                txtNazwa.Text = produkt.Nazwa;
                txtLiczbaSztuk.Text = produkt.LiczbaSztuk.ToString();
                txtMagazyn.Text = produkt.Magazyn;
            }
        }

        private void btnPotwierdz_Click(object sender, RoutedEventArgs e)
        {
            produkt.Symbol = txtSymbol.Text;
            produkt.Nazwa = txtNazwa.Text;
            if (int.TryParse(txtLiczbaSztuk.Text, out int liczba))
            {
                produkt.LiczbaSztuk = liczba;
            }
            produkt.Magazyn = txtMagazyn.Text;

            this.Close();
        }
    }
}
