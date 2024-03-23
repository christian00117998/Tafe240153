using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
	public sealed partial class MortgageCalculator : Page
	{
		public MortgageCalculator()
		{
			this.InitializeComponent();
		}

		private void calculateButton_Click(object sender, RoutedEventArgs e)
		{
			//input variables
			const double MONTHS_IN_YEAR = 12;
			double principal, yearRate, monthRate, monthRepaymentNum, monthRepaymentDen, monthsFinal, monthRepayment;
			int year, month;

			//principal = principalTextBox;
			//year = yearsTextBox;
			//month = monthsTextBox.Text;
			//yearRate = yearinterestTextBox.Text;
			//monthRate = monthinterestTextBox.Text;
			//monthRepayment = repaymentTextBox.Text;

			// Convert text box inputs to appropriate data types
			principal = double.Parse(principalTextBox.Text);
			year = int.Parse(yearsTextBox.Text);
			month = int.Parse(monthsTextBox.Text);
			yearRate = double.Parse(yearinterestTextBox.Text);
			//monthRate = yearRate / 12 / 100; // Convert annual interest rate to monthly and to decimal
			//monthRepayment = double.Parse(repaymentTextBox.Text);



			// Calculate monthly interest rate
			monthRate = yearRate / MONTHS_IN_YEAR;

			monthRate = monthRate * 0.01;

			// Calculate number of months
			monthsFinal = (year * 12) + month;

			// Calculate NUMERATOR of Monthly Repayment Calculation
			monthRepaymentNum = principal * (Math.Pow(1 + monthRate, monthsFinal)) * monthRate;

			// Calculate Denominator of Monthly Repayment Calculation
			monthRepaymentDen = Math.Pow(1 + monthRate, monthsFinal) - 1;

			// Calculate Monthly Repayment
			monthRepayment = monthRepaymentNum / monthRepaymentDen;



			//int monthsfinal = year * 12 + month;
			//monthRepayment = principal[monthRate(1 + monthRate)Math.Pow(monthsfinal) / [(1 + monthRate)Math.Pow(monthsfinal) - 1];
			monthinterestTextBox.Text = monthRate.ToString("N4") + "%";
			repaymentTextBox.Text = monthRepayment.ToString("C");
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(UniversalCalculator));
		}

	}
}
