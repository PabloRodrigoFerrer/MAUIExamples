using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace colorMakerWPF
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

        private bool isRandom = false;



        private void setColor(Color color)
        {
            //Container.Background = color;
            //btnRandom.Background = color;

            //lblHex.Text = color;
            //lblMainTitle.TextColor = color;

         
        }

        private void btnRandom_Clicked(object sender, EventArgs e)
        {
            isRandom = true;
            var random = new Random();

            var color = Color.FromRgb(
                (byte)random.Next(0, 256),
                (byte)random.Next(0, 256),
                (byte)random.Next(0, 256)
                );

            setColor(color);

            sldRed.Value = color.R;
            sldBlue.Value = color.B;
            sldGreen.Value = color.G;

            isRandom = false;
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!isRandom)
            {
                var red = sldRed.Value;
                var blue = sldBlue.Value;
                var green = sldGreen.Value;

                Color color = Color.FromRgb((byte)red, (byte)green, (byte)blue);

                setColor(color);
            }
        }

        //private async void btnCopy_Clicked(object sender, EventArgs e)
        //{
        //    await Clipboard.SetTextAsync(lblHex.Text);
        //    var toast = Toast.Make("Color code copied to clipboard!", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
        //    await toast.Show();
        //}
    }
}
