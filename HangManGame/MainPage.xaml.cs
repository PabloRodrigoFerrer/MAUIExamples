namespace HangManGame
{
    public partial class MainPage : ContentPage
    {

        HangMan HangManVm = new HangMan();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = HangManVm;
            HangManVm.ResetGame();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;

            if (btn is Button)
            {
                HangManVm.CalculateWord(btn.Text[0]);
                btn.IsEnabled = false;

                if (HangManVm.CheckLoose() || HangManVm.CheckWin())
                    DisableLetters();
            }

        }

        private void Reset_Clicked(object sender, EventArgs e)
        {
            HangManVm.ResetGame();
            EnableLetters();
        }

        private void DisableLetters()
        {
            foreach(var children in LettersContainer)
            {
                var btn = children as Button;

                if(btn is Button)
                {
                    btn.IsEnabled = false;
                }
            }
        }

        private void EnableLetters()
        {
            foreach (var children in LettersContainer)
            {
                var btn = children as Button;

                if (btn is Button)
                {
                    btn.IsEnabled = true;
                }
            }
        }


      
    }
}
