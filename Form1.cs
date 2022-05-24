using System;
using System.Windows.Forms;

namespace Calculator
{
	public partial class Form1 : Form
	{
		private string Action;//создаем переменую - действие - для кнопок +,=,*,/
		private string Number; // создаем переменную для того чтобы запоминать число, которое было набрано перед кнопкой действия
		private bool Erase;// условная переменная, которая будет использоваться тогда, когда надо стереть текстовое поле после нажатия знака действия
		public Form1()
		{
			Erase = false;
			InitializeComponent();
		}

		private void PerformingActions()
		{
			double dNumber1 = Convert.ToDouble(Number);
			double dNumber2 = Convert.ToDouble(tbBoard.Text);
			double result;
			if (Action == "+")
			{
				result = dNumber1 + dNumber2;
			}
			else if (Action == "-")
			{
				result = dNumber1 - dNumber2;
			}
			else if (Action == "×")
			{
				result = dNumber1 * dNumber2;
			}
			else
			{
				result = dNumber1 / dNumber2;
			}
			tbBoard.Text = result.ToString();
		}

		private void numberButtons_Click(object sender, EventArgs e)
		{
			Button B = (Button)sender;
			if (Erase)
			{
				Erase = false;
				tbBoard.Text = "0";
			}

			tbBoard.Text = tbBoard.Text == "0" ? B.Text : tbBoard.Text + B.Text;
		}

		private void clearButtons_Click(object sender, EventArgs e)
		{
			Number = string.Empty;
			tbBoard.Text = "0";
		}

		private void actionButtons_Click(object sender, EventArgs e)
		{
			Button B = (Button)sender;

			if (!string.IsNullOrEmpty(Number))
				PerformingActions();

			Action = B.Text; //записываем в переменную действие текст с нажатой кнопки
			Number = tbBoard.Text;// переменная Number1 = тексту в текстовом поле
			Erase = true;//после того как ввели действие  - табло стираем
		}
		
		private void resultButton_Click(object sender, EventArgs e)
		{
			PerformingActions();
			Number = string.Empty;
			Erase = true;
		}

		private void rootButton_Click(object sender, EventArgs e)
		{
			var dNumber  = Convert.ToDouble(tbBoard.Text);
			var resultRoot = Math.Sqrt(dNumber);
			tbBoard.Text = resultRoot.ToString();
		}

		private void squareButton_Click(object sender, EventArgs e)
		{
			var dNumber  = Convert.ToDouble(tbBoard.Text);
			var resultSquare = dNumber * dNumber;
			tbBoard.Text = resultSquare.ToString();
		}

		private void oneDivNumbButton_Click(object sender, EventArgs e)
		{
			var dNumber  = Convert.ToDouble(tbBoard.Text);
			var resultonedivnumb = 1 / dNumber;
			tbBoard.Text = resultonedivnumb.ToString();
		}
		
		private void plusMinusButton_Click(object sender, EventArgs e)
		{
			var dNumber = Convert.ToDouble(tbBoard.Text);
			var resultPlusminus = -dNumber;
			tbBoard.Text = resultPlusminus.ToString();
		}

		private void splitButton_Click(object sender, EventArgs e)
		{
			tbBoard.Text = !tbBoard.Text.Contains(",") ? tbBoard.Text + ",": tbBoard.Text;
		}
	
		private void deleteButton_Click(object sender, EventArgs e)
		{
			tbBoard.Text = tbBoard.Text.Substring(0, tbBoard.Text.Length - 1);
			if (tbBoard.Text == "")
				tbBoard.Text = "0";
		}

		private void percentButton_Click(object sender, EventArgs e)
		{
			var dNumber = Convert.ToDouble(tbBoard.Text);
			var resultPersents = dNumber / 100;
			tbBoard.Text = resultPersents.ToString();
		}

	}
}
