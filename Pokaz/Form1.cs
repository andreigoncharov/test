using System;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using System.Net;

namespace Pokaz
{
	public partial class Form1 : Form
	{
		string rah64 = "619100178"; string rah65 = "619100179";
		string FIO64 = ""; string FIO65 = "";
		public Form1()
		{
			InitializeComponent();

			if (kv64.Checked == true)
			{
				rah.Text = rah64;
				FIO.Text = FIO64;
			}
			else if (kv65.Checked == true)
			{
				rah.Text = rah65;
				FIO.Text = FIO65;
			}
			string dnow = DateTime.Now.ToString();
			date.Text = dnow;
			q11.Text = "F-";
			string dnow1 = DateTime.Now.ToString("dd:MM:yyyy");
			showd.Text = ("Текущая дата: ") + dnow1;
		}

		private void Form1_Load(object sender, EventArgs e) { }

		private void start_Click(object sender, EventArgs e)
		{
			if (!conection())
			{
				MessageBox.Show("Нет соеденения с интернетом. Проверьте соеденение с интернетом.");
				return;
			}

			IWebDriver web;
			string Rah = rah.Text;
			string fio = FIO.Text;
			web = new ChromeDriver();
			try
			{
				web.Navigate().GoToUrl("https://www.hts.kharkov.ua/KPHTS_v2_bill1PU.php");

				if (kv64.Checked == true)
				{
					web.FindElement(By.XPath("//input[@id='acc-input']")).SendKeys(rah64);
				}
				else if (kv65.Checked == true)
				{
					web.FindElement(By.XPath("//input[@id='acc-input']")).SendKeys(rah65);
				}

				if (kv64.Checked == true)
				{
					web.FindElement(By.XPath("//input[@id='lastname-input']")).SendKeys(FIO64);
				}
				else if (kv65.Checked == true)
				{
					web.FindElement(By.XPath("//input[@id='lastname-input']")).SendKeys(FIO65);
				}


                web.FindElement(By.XPath("//button[@class='btn btn-primary']")).Click();
				if (kv64.Checked == true)
				{
					web.FindElement(By.LinkText("Прибор Ultraheat T 230 ИД.ПУ: 1891039")).Click();
				}
				else if (kv65.Checked == true)
				{
					web.FindElement(By.LinkText("Прибор Ultraheat T 230 ИД.ПУ: 1891175")).Click();
				}

				

				web.FindElement(By.XPath("//input[@id='LastDtPok']")).SendKeys(date.Text);//1
				web.FindElement(By.XPath("//input[@id='LastValuePok']")).SendKeys(q2.Text);//2
				web.FindElement(By.XPath("//input[@id='LastRashPok']")).SendKeys(q3.Text);//3
				web.FindElement(By.XPath("//input[@id='LastTimePok']")).SendKeys(q4.Text);//8
				web.FindElement(By.XPath("//input[@id='TimeProstoya']")).SendKeys(q5.Text);//9
				web.FindElement(By.XPath("//input[@id='TimeRash']")).SendKeys(q6.Text);//10
				web.FindElement(By.XPath("//input[@id='HeatPower']")).SendKeys(q7.Text);//5
				web.FindElement(By.XPath("//input[@id='HeatRash']")).SendKeys(q8.Text);//4
				web.FindElement(By.XPath("//input[@id='TempO']")).SendKeys(q9.Text);//7
				web.FindElement(By.XPath("//input[@id='TempPod']")).SendKeys(q10.Text);//6
				web.FindElement(By.XPath("//input[@id='ErrorKod']")).SendKeys(q11.Text);//11
			}
			catch (Exception)
			{
				MessageBox.Show("Ошибка");
			}
		}

		private void kv65_CheckedChanged(object sender, EventArgs e)
		{
			kv64.Checked = false;
			rah.Text = rah65;
			FIO.Text = FIO65;
		}

		private void kv64_CheckedChanged(object sender, EventArgs e)
		{
			kv65.Checked = false;
			rah.Text = rah64;
			FIO.Text = FIO64;
		}
		public static bool conection()
		{
			try
			{
				WebClient cl = new WebClient();
				string resp;
				resp = cl.DownloadString("http://www.google.com");
				return true;
			}
			catch (WebException e)
			{
				return false;
			}
		}
	}
}