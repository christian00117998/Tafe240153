using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CurrencyConversionCalculator : Page
	{
		public CurrencyConversionCalculator()
		{
			this.InitializeComponent();
		}

		private async void conversionButton_Click(object sender, RoutedEventArgs e)
		{
			double amount = 0;
			double total = 0;

			double[] us = new double[] { 0.85189982, 0.72872436, 74.257327 };
			double[] euro = new double[] { 1.1739732, 0.8556672, 87.00755 };
			double[] brit = new double[] { 1.371907, 1.1686692, 101.68635 };
			double[] rup = new double[] { 0.011492628, 0.013492774, 0.0098339397 };

			try
			{
				amount = double.Parse(amountTextBox.Text);
			}
			catch (Exception)
			{
				var dialogMessage = new MessageDialog("Error! Please Enter a number.");
				await dialogMessage.ShowAsync();
				amountTextBox.Focus(FocusState.Programmatic);
				return;
			}

			if (fromComboBox.SelectedIndex == toComboBox.SelectedIndex)
			{
				resultTextBlock.Text = amount + " =" + amount.ToString();
				result1TextBlock.Text = "";
				result2TextBlock.Text = "";
				return;
			}

			// US Dollars
			if (fromComboBox.SelectedIndex == 0)
			{
				if (toComboBox.SelectedIndex == 1)
				{
					total = amount * us[0];
					resultTextBlock.Text = amount + " US Dollars =" + "€ " + total.ToString() + " Euro";
					result1TextBlock.Text = "1 US Dollar = €" + us[0].ToString() + " Euro";
					result2TextBlock.Text = "1 Euro = $" + euro[0].ToString() + " US Dollar";
					return;
				}
				else if (toComboBox.SelectedIndex == 2)
				{
					total = amount * us[1];
					resultTextBlock.Text = amount + " US Dollars =" + "$ " + total.ToString() + " British Pounds";
					result1TextBlock.Text = "1 US Dollar = £" + us[1].ToString() + " British Pounds";
					result2TextBlock.Text = "1 British Pound = $" + brit[0].ToString() + " US Dollar";
					return;
				}
				else if (toComboBox.SelectedIndex == 3)
				{
					total = amount * us[2];
					resultTextBlock.Text = amount + " US Dollars =" + "₹ " + total.ToString() + " Indian Rupees";
					result1TextBlock.Text = "1 US Dollar = ₹" + us[2].ToString() + " Indian Rupees";
					result2TextBlock.Text = "1 Indian Rupee = $" + rup[0].ToString() + " US Dollar";
					return;
				}
			}
			// Euro
			else if (fromComboBox.SelectedIndex == 1)
			{
				if (toComboBox.SelectedIndex == 0)
				{
					total = amount * euro[0];
					resultTextBlock.Text = amount + " Euro =" + "$ " + total.ToString() + " US Dollars";
					result1TextBlock.Text = "1 Euro = $" + euro[0].ToString() + " US Dollar";
					result2TextBlock.Text = "1 US Dollar = €" + us[0].ToString() + " Euro";
					return;
				}
				else if (toComboBox.SelectedIndex == 2)
				{
					total = amount * euro[1];
					resultTextBlock.Text = amount + " Euro =" + "£ " + total.ToString() + " British Pounds";
					result1TextBlock.Text = "1 Euro = £" + euro[1].ToString() + " British Pound";
					result2TextBlock.Text = "1 British Pound = €" + brit[1].ToString() + " Euro";
					return;
				}
				else if (toComboBox.SelectedIndex == 3)
				{
					total = amount * euro[2];
					resultTextBlock.Text = amount + " Euro =" + "₹ " + total.ToString() + " Indian Rupees";
					result1TextBlock.Text = "1 Euro = ₹" + euro[2].ToString() + " Indian Rupee";
					result2TextBlock.Text = "1 Indian Rupee = €" + rup[1].ToString() + " Euro";
					return;
				}
			}
			// British Pounds
			else if (fromComboBox.SelectedIndex == 2)
			{
				if (toComboBox.SelectedIndex == 0)
				{
					total = amount * brit[0];
					resultTextBlock.Text = amount + " British Pounds =" + "$ " + total.ToString() + " US Dollars";
					result1TextBlock.Text = "1 British Pound = $" + brit[0].ToString() + " US Dollar";
					result2TextBlock.Text = "1 US Dollar = £" + us[1].ToString() + " British Pound";
					return;
				}
				else if (toComboBox.SelectedIndex == 1)
				{
					total = amount * brit[1];
					resultTextBlock.Text = amount + " British Pounds =" + "€ " + total.ToString() + " Euros";
					result1TextBlock.Text = "1 British Pound = €" + brit[1].ToString() + " Euro";
					result2TextBlock.Text = "1 Euro = £" + euro[1].ToString() + " British Pound";
					return;
				}
				else if (toComboBox.SelectedIndex == 3)
				{
					total = amount * brit[2];
					resultTextBlock.Text = amount + " British Pounds =" + "₹ " + total.ToString() + " Indian Rupees";
					result1TextBlock.Text = "1 British Pound = ₹" + brit[2].ToString() + " Indian Rupees";
					result2TextBlock.Text = "1 Indian Rupee = £" + rup[2].ToString() + " British Pound";
					return;
				}
			}
			// Indian Rupee
			else
			{
				if (toComboBox.SelectedIndex == 0)
				{
					total = amount * rup[0];
					resultTextBlock.Text = amount + " Indian Rupees =" + "$ " + total.ToString() + " US Dollars";
					result1TextBlock.Text = "1 Indian Rupee = $" + rup[0].ToString() + " US Dollar";
					result2TextBlock.Text = "1 US Dollar = ₹" + us[2].ToString() + " Indian Rupees";
					return;
				}
				else if (toComboBox.SelectedIndex == 1)
				{
					total = amount * rup[1];
					resultTextBlock.Text = amount + " Indian Rupees =" + "€ " + total.ToString() + " Euros";
					result1TextBlock.Text = "1 Indian Rupee = €" + rup[1].ToString() + " Euro";
					result2TextBlock.Text = "1 Euro = ₹" + euro[2].ToString() + " Indian Rupees";
					return;
				}
				else if (toComboBox.SelectedIndex == 2)
				{
					total = amount * rup[2];
					resultTextBlock.Text = amount + " Indian Rupees =" + "£ " + total.ToString() + " British Pounds";
					result1TextBlock.Text = "1 Indian Rupee = £" + rup[2].ToString() + " British Pound";
					result2TextBlock.Text = "1 British Pound = ₹" + brit[2].ToString() + " Indian Rupees";
					return;
				}
			}
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(UniversalCalculator));
		}
	}
}
