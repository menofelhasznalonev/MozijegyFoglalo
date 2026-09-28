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

namespace MozijegyFoglalo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void FoglalasValidacio(object sender, RoutedEventArgs e)
        {
            bool hiba = false;

            string nev = txtNev.Text;
            if (nev.Length < 3)
            {
                hiba = true;
            }

            int eletkor = 0;
            try
            {
                eletkor = Convert.ToInt32(txtEletkor.Text);
            }
            catch (FormatException)
            {
                hiba = true;
            }

            string film = comboFilmKivalasztas.Text;
            if (film.Length == 0)
            {
                hiba = true;
            }

            int jegyekSzama = 0;
            try
            {
                jegyekSzama = Convert.ToInt32(txtJegyszam.Text);
            }
            catch (FormatException)
            {
                hiba = true;
            }
            if (jegyekSzama < 1 || jegyekSzama > 10)
            {
                hiba = true;
            }

            if (checkFeltetelek.IsChecked == false)
            {
                hiba = true;
            }

            if (hiba)
            {
                hibaJelzo.Text = "Egy, vagy több helyen nem megfelelő adat lett megadva";
            } else
            {
                hibaJelzo.Text = "";
                FoglalasKiszamitas(nev, eletkor, film, jegyekSzama);
            }
        }

        private void FoglalasKiszamitas(string nev, int eletkor, string film, int jegyekSzama)
        {
            
            int jegyAr = 0;
            string jegyTipusString = "";
            if (radioNormal.IsChecked == true)
            {
                jegyAr = 2500;
                jegyTipusString = "Normál";
            }
            else if (radioDiak.IsChecked == true)
            {
                jegyAr = 1900;
                jegyTipusString = "Diák";
            }
            else
            {
                jegyAr = 4000;
                jegyTipusString = "VIP";
            }


            int ossz = jegyAr * jegyekSzama;

            string extrakString = "";
            if (checkPopcorn.IsChecked == true)
            {
                ossz += 1200;
                extrakString += "Popcorn";
            }
            if (checkUdito.IsChecked == true)
            {
                ossz += 800;

                if (extrakString != "")
                {
                    extrakString += ", ";
                }

                extrakString += "Üdítő";
            }
            if (checkSzemuveg.IsChecked == true)
            {
                ossz += 500;

                if (extrakString != "")
                {
                    extrakString += ", ";
                }

                extrakString += "Szemüveg";
            }

            MessageBox.Show($"Sikeres foglalás! \n\n Név: {nev} \n Életkor: {eletkor} \n Film: {film} \n Jegytípus: {jegyTipusString} \n Jegyek száma: {jegyekSzama} \n Extrák: {extrakString} \n \n Fizetendő: {ossz}", "Foglalás", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}