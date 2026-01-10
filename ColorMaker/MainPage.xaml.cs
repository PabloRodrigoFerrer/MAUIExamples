using CommunityToolkit.Maui.Alerts;

namespace ColorMaker
{
    public partial class MainPage : ContentPage
    {

        private bool isRandom = false;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (!isRandom)
            {
                var red = sldRed.Value;
                var blue = sldBlue.Value;
                var green = sldGreen.Value;

                Color color = Color.FromRgb(red, green, blue);

                setColor(color);
            }
        }

        private void setColor(Color color)
        {
            Container.BackgroundColor = color;
            btnRandom.BackgroundColor = color;

            lblHex.Text = color.ToHex();
            lblMainTitle.TextColor = color;

            sldRed.ThumbColor = color;
            sldBlue.ThumbColor = color;
            sldGreen.ThumbColor = color;
        }

        private void btnRandom_Clicked(object sender, EventArgs e)
        {
            isRandom = true;
            var random = new Random();

            var color = Color.FromRgb(
                random.Next(0, 256),
                random.Next(0, 256),
                random.Next(0, 256)
                );

            setColor(color);

            sldRed.Value = color.Red;
            sldBlue.Value = color.Blue;
            sldGreen.Value = color.Green;

            isRandom = false;
        }

        private async void btnCopy_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(lblHex.Text);
            var toast = Toast.Make("Color code copied to clipboard!", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
            await toast.Show();
        }
    }
}
