namespace CodeQuotes
{
    public partial class MainPage : ContentPage
    {
        private List<string> frases = new();
        Random random = new();

        public MainPage()
        {
            InitializeComponent();
            LoadTextFromFileAsync("quotes.txt", frases);
        }

        private void btnQuoteGenerator_Clicked(object sender, EventArgs e)
        {
            var colors = GenerateRandomColors();

            var stops = GenerateGradientStops(0.0f, colors);

            var gradientColor = new LinearGradientBrush(stops, new Point(0, 0), new Point(1, 0));

            container.Background = gradientColor;

            var quote = RandomIndexFromList(frases);
            lblQuote.Text = quote;

        }

        private async Task LoadTextFromFileAsync(string fileName, List<string> list)
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync(fileName);
            using var reader = new StreamReader(stream);

            while (reader.Peek() != -1)
            {
                list.Add(reader.ReadLine() ?? "");
            }

        }

        private System.Drawing.Color GenerateColor()
        {
            return System.Drawing.Color.FromArgb(
                    random.Next(256),
                    random.Next(256),
                    random.Next(256));
        }

        private List<System.Drawing.Color> GenerateRandomColors() => ColorUtility.ColorControls.GetColorGradient(GenerateColor(), GenerateColor(), 6);

        private GradientStopCollection GenerateGradientStops(float offSet, List<System.Drawing.Color> colors)
        {
            var stops = new GradientStopCollection();
            foreach (var c in colors)
            {
                stops.Add(new GradientStop(Color.FromArgb(c.Name), offSet));
                offSet += 0.2f;
            }

            return stops;
        }

        private string RandomIndexFromList(List<string> list) 
        {
       
            int index = random.Next(list.Count);
            var quote = frases[index];

            return quote;

        }
    }
}
