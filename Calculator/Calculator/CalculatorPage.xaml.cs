using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Calculator
{
    public partial class CalculatorPage : ContentPage
    {
        public CalculatorPage()
        {
            InitializeComponent();
        }

        #region Methods

        public void OnDigitButtonPressed(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            if (output.Text.Replace("-", "") == "0")
                output.Text = output.Text.Replace("0", button.Text);
            else
                output.Text += button.Text;
        }

        public void OnOperatorButtonPressed(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            string result = DoMath();
            lhs.Text = result;
            output.Text = "0";
            @operator.Text = button.StyleId;
        }

        public void OnEqualsButtonPressed(object sender, EventArgs args)
        {
            string result = DoMath();
            output.Text = result;
            @operator.Text = "+";
            lhs.Text = "0";
        }

        public void OnDecimalButtonPressed(object sender, EventArgs args)
        {
            if (!output.Text.Contains("."))
            {
                if (output.Text.Replace("-", "") == "")
                    output.Text += "0.";
                else
                    output.Text += ".";
            }
        }

        public void OnSignChangePressed(object sender, EventArgs args)
        {
            if (!output.Text.Contains("-"))
                output.Text = "-" + output.Text;
            else
                output.Text = output.Text.Replace("-", "");
        }

        public void OnClearPressed(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            string clearType = button.StyleId;
            if (clearType == "Back")
            {
                output.Text = output.Text.Remove(output.Text.Length - 1);
                if (output.Text.Replace("-", "") == "")
                    output.Text += "0";
            }
            else if (clearType == "Clear")
                output.Text = "0";
            else
            {
                output.Text = "0";
                lhs.Text = "0";
                @operator.Text = "+";
            }
        }

        private string DoMath()
        {
            string result = "0";
            string operation = @operator.Text;
            double lhs, rhs;

            if (double.TryParse(this.lhs.Text, out lhs) && double.TryParse(output.Text, out rhs))
            {
                if (operation == "+")
                    result = (lhs + rhs).ToString();

                else if (operation == "-")
                    result = (lhs - rhs).ToString();

                else if (operation == "×")
                    result = (lhs * rhs).ToString();

                else if (operation == "÷")
                    if (rhs != 0)
                        result = (lhs / rhs).ToString();
            }

            return result;
        }

        #endregion
    }
}
