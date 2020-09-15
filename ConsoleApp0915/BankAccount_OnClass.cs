using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0915
{
	class BankAccount_OnClass
	{   //메서드 바깥에 있어야 멤버변수 메서드 안에 있으면 지역변수
		private static double interest = 0.3;  //이자율
		private string accNum;    //계좌번호
		private string name;      //예금주명
		private int balance;      //잔액  
		//기본적인 위치 맨처음 멤버변수 - 프로퍼티 - 생성자 - 메서드
		#region Property
		public string AccNum
		{
			get { return accNum; } 
			set { accNum = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public int Balance  // 읽기전용속성 (프로퍼티) 밖에서 잔액을 건드리면 안되기 때문
		{
			get { return balance; }
		}
		#endregion

		#region Ctor
		public BankAccount_OnClass() //기본 생성자 (멤버변수 초기화를 위함)
		{
			balance = 10;
		}

		public BankAccount_OnClass(string accnum, string accname)
		{
			accNum = accnum; //바로 멤버변수로 들어감
			Name = accname; //프로퍼티를 타고 들어감
			balance = 10;
		}
		#endregion

		#region Method
		// 출금
		public void OutputMoney(int amount)
		{
			if (balance < amount)
			{
				Console.WriteLine("잔액이 부족합니다");
				return; // 밑에 코드를 사용하지않도록 하는 첫번째 방법 -> 이방법을 선호하는게 좋음(가독성을 좋기 위해, 소모를 줄이기 위해)
			}
			//else // 두번째 방법
			//{
				balance -= amount;
			//}
		}
		//public string OutputMoney(int amount)  //메서드 안에 cw출력을 하기싫은 경우 방법 if에 안걸리는 경우 공백 반환
		//{
		//	if (balance < amount)
		//	{
		//		string msg = "잔액이 부족합니다";
		//		return msg;
		//	}
		//	balance -= amount;
		//	return "";
		//}

		//예금
		public void InputMoney(int amount)
		{
			balance = balance + amount + (int)(amount * interest);
		}
		//계좌정보 출력
		public void PrintAccInfo()
		{	// interest는 정적변수기 때문에 this접근이 아니라 클래스명 접근을 해야한다
			Console.WriteLine($"계좌번호 : {this.accNum}\n예금주명 : {this.Name}\n잔액 : {this.Balance}원\n이자율 : {BankAccount_OnClass.interest}%");
		}

		//이자율 변경
		public static void	SetInterest(double interest) //정적메서드 
		{
			BankAccount_OnClass.interest = interest;
			//balance += 10;  // 오류가 나는 이유는 정적 메서드는 정적변수만 가능 인스턴스 메서드, 변수 사용불가
		}
		#endregion
	}

	class Program
	{
		static void Main()
		{
			BankAccount_OnClass acc0 = new BankAccount_OnClass();
			acc0.AccNum = "111-11111";
			acc0.Name = "홍길동";
			acc0.PrintAccInfo();
			BankAccount_OnClass.SetInterest(10); // 정적메서드기 때문에 클래스명으로 접근


			BankAccount_OnClass acc1 = new BankAccount_OnClass("222-22222", "류현진"); //생성자를 통한 간소화 가능
			acc1.Name = "손흥민";
			acc1.PrintAccInfo();

			acc0.OutputMoney(100); // 잔액이 10원이기 때문에 잔액부족

			//메서드안에 cw출력을 원하지 않는경우 공백문자가 반환되지 않는 경우는 잔액이 부족할때뿐 errmsg의 길이가 길다면 잔액이 부족하다는 뜻
			//string errMsg = acc0.OutputMoney(100);
			//if(errMsg.Length > 0)
			//	Console.WriteLine(errMsg);
			//else
			//	Console.WriteLine(acc0.Balance);

			acc0.InputMoney(500);
			acc0.OutputMoney(100);
			Console.WriteLine(acc0.Balance); //510
		}
	}
}
