using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0915
{
	class AccountManager
	{
		int money = 0;
		BankAccount_OnClass account; //메서드안에 인스턴트를 선언 해버리면 매서드 안에서만 기능 그래서 메서드 밖에서 선언
		public void PrintMenu()
		{
			Console.WriteLine("\n---Menu---------");
			Console.WriteLine("1. 계좌 개설");
			Console.WriteLine("2. 입금");
			Console.WriteLine("3. 출금");
			Console.WriteLine("4. 잔액 조회");
			Console.WriteLine("5. 프로그램 종료");
		}
		public void MakeAccount() //1. 계좌 개설
		{
			Console.Write("계좌번호 : ");
			string accNum = Console.ReadLine();
			Console.Write("예금주명 : ");
			string accName = Console.ReadLine();

			account = new BankAccount_OnClass(accNum, accName);
		}
		public void Deposit() //2. 입금
		{
			Console.Write("입금하실 금액은?: ");
			money = int.Parse(Console.ReadLine());
			account.InputMoney(money);
		}
		public void Widthdraw() //3. 출금
		{
			Console.Write("출금하실 금액은?: ");
			money = int.Parse(Console.ReadLine());
			account.OutputMoney(money);
		}
		//public void Balance() //4. 잔액 조회
		//{

		//}
		//public void QuitProgram() //5. 프로그램 종료
		//{

		//}
	}
	class AccountProgram
	{
		static void Main()  //계좌관리 프로그램 매뉴
		{
			//System.Windows.Forms.MessageBox.Show("Hello","title", System.Windows.Forms.MessageBoxButtons.YesNo);
			AccountManager manager = new AccountManager();
			Console.WriteLine(manager.ToString());

			int choice; // 반복문 밖에 선언
			while (true)
			{
				manager.PrintMenu();
				Console.Write("선택 : ");
				choice = int.Parse(Console.ReadLine()); //int choice 반복문 안에 있어 한번돌때마다 계속 선언 되기 때문에 while문 밖에 선언해주는게 좋음(리소스 소모를 줄일수있음)
				switch(choice)
				{
					case 1:
						manager.MakeAccount(); break;
					case 2:
						manager.Deposit(); break;
					case 3:
						manager.Widthdraw(); break;
					case 4:break;
						//return을 쓰는이유는 break를 쓰면 스위치문만 나가기 때문에 while문의 무한루프를 빠져나갈수 없음
					case 5:return;
					default:
						Console.WriteLine("다시 선택하세요"); break;
				}
			}
		}
	}
}
