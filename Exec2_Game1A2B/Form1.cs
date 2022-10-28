using System.Drawing.Text;

namespace Exec2_Game1A2B
{
	public partial class Form1 : Form
	{
		private Game1A2B game;
		public Form1()
		{
			InitializeComponent();
			game = new Game1A2B();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			game.NewGame();
			label2.Text = game.DisplayGameSet();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int[] input = new int[4];
			try
			{
				input[0] = SetNumber1();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}

			try
			{
				input[1] = SetNumber2();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}

			try
			{
				input[2] = SetNumber3();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}

			try
			{
				input[3] = SetNumber4();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}

			game.SetInput(input);
			game.Check();
			label1.Text = game.Result();
			input = new int[] { 0, 0, 0, 0 };
		}
		private int SetNumber1()
		{
			TextBox txt = textBox1;
			string input = txt.Text;
			return GetInt(txt, input);
		}
		private int SetNumber2()
		{
			TextBox txt = textBox2;
			string input = txt.Text;
			return GetInt(txt, input);
		}
		private int SetNumber3()
		{
			TextBox txt = textBox3;
			string input = txt.Text;
			return GetInt(txt, input);
		}
		private int SetNumber4()
		{
			TextBox txt = textBox4;
			string input = txt.Text;
			return GetInt(txt, input);
		}
		private int GetInt(TextBox txt, string input)
		{
			string value = txt.Text;
			bool Isint = int.TryParse(value, out int number);
			return Isint ? number : throw new Exception($"{input}¥²¶·­n¶ñ­È");
		}
	}
	public class Game1A2B
	{
		private int[] answer = new int[4];
		private int[] userinput = new int[4];
		private int countforsame = 0;
		private int countforposition = 0;
		public void NewGame()
		{
			int seed = Guid.NewGuid().GetHashCode();
			Random random = new Random(seed);
			answer[0] = random.Next(0, 10);

			seed = Guid.NewGuid().GetHashCode();
			random = new Random(seed);
			answer[1] = random.Next(0, 10);

			seed = Guid.NewGuid().GetHashCode();
			random = new Random(seed);
			answer[2] = random.Next(0, 10);

			seed = Guid.NewGuid().GetHashCode();
			random = new Random(seed);
			answer[3] = random.Next(0, 10);
		}
		public string DisplayGameSet()
		{
			return $"{answer[0]} - {answer[1]} - {answer[2]} - {answer[3]}";
		}
		public void SetInput(int[] set)
		{
			for (int i = 0; i < set.Length; i++)
			{
				userinput[i] = set[i];
			}
		}
		public void Check()
		{
			for (int i = 0; i < answer.Length; i++)
			{
				for (int j = 0; j < answer.Length; j++)
				{
					if (userinput[i] == answer[j])
					{
						countforsame++;
						break;
					}
				}
			}

			for (int i = 0; i < answer.Length; i++)
			{
				if (userinput[i] == answer[i]) countforposition++;
			}
		}
		public string Result()
		{
			return $"{countforposition}A-{countforsame - countforposition}B";
		}
	}
}