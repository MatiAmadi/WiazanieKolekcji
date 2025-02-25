using System.ComponentModel;

namespace WiazanieKolekcji
{
    public class Produkt : INotifyPropertyChanged
    {
        private string _symbol;
        public string Symbol
        {
            get => _symbol;
            set
            {
                _symbol = value;
                OnPropertyChanged(nameof(Symbol));
            }
        }

        private string _nazwa;
        public string Nazwa
        {
            get => _nazwa;
            set
            {
                _nazwa = value;
                OnPropertyChanged(nameof(Nazwa));
            }
        }

        private int _liczbaSztuk;
        public int LiczbaSztuk
        {
            get => _liczbaSztuk;
            set
            {
                _liczbaSztuk = value;
                OnPropertyChanged(nameof(LiczbaSztuk));
            }
        }

        private string _magazyn;
        public string Magazyn
        {
            get => _magazyn;
            set
            {
                _magazyn = value;
                OnPropertyChanged(nameof(Magazyn));
            }
        }

        public Produkt(string symbol, string nazwa, int liczbaSztuk, string magazyn)
        {
            Symbol = symbol;
            Nazwa = nazwa;
            LiczbaSztuk = liczbaSztuk;
            Magazyn = magazyn;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
