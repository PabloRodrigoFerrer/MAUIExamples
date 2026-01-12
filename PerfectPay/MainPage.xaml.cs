using Microsoft.Maui.Controls.Platform;

namespace PerfectPay
{
    public partial class MainPage : ContentPage
    {
        private double bill, subTotal, tip;
        private int numPersonas;

        private void entryBill_Completed(object sender, EventArgs e)
        {
            bill = double.Parse(entryBill.Text);
            CalcularTotal();
        }

        public MainPage()
        {
            InitializeComponent();
            numPersonas = 1;
        }

        private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            tip = (int)sldTip.Value;
            lblTipPercent.Text = "Tip %: " + tip.ToString();
            CalcularTotal();
        }

        private void btnPlus_Clicked(object sender, EventArgs e)
        {
            numPersonas++;
            lblPersons.Text = numPersonas.ToString();
            CalcularTotal();
        }


        private void btnMinus_Clicked(object sender, EventArgs e)
        {
            if(numPersonas > 1)
            {
                numPersonas--;
                lblPersons.Text = numPersonas.ToString();
                CalcularTotal();
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(sender is Button)
            {
                var btn = (Button)sender;
                tip =double.Parse(btn.Text.Replace("%", ""));
                sldTip.Value = tip;
                CalcularTotal();
            }
        }

        private void CalcularTotal()
        {
            var total = (bill * tip / 100 + bill) / numPersonas;
            var subtotal = bill / numPersonas;
            var tipByPerson = (bill * tip / 100) / numPersonas;

            lblTotalPersona.Text = $"{total:C}";
            lblSubtotal.Text = $"{subtotal:C}";
            lblTip.Text = $"{tipByPerson:C}";
        }
    }
}
