using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0915
{
    public class BankAccount
    {
        private double interest = 0.2;   //이자율
        private string accNum;           //계좌번호
        private string name;             //예금주명
        private int balance = 0;         //잔액    

        public int Balance
        {
            get { return balance; }
            set
            {
                if (value >= 0)
                    balance = value;
            }

        }

        //출금
        public void OutputMoney(int amount)
        {
            this.balance = this.balance - amount;
        }

        //예금
        public void InputMoney(int amount)
        {
            this.balance = this.balance + amount + (int)(amount * interest);
        }
    }

    class Program1
    {
        static void Main(string[] args)
        {
            BankAccount BJK = new BankAccount
            {
                Balance = 0
            };

            while (true)
            {
                #region 사용자입력
                int amount = 0;

                Console.WriteLine("1. 출금  2.예금  3.잔액확인");
                Console.Write("번호를 입력해 주십시오 : ");
                int input_user = int.Parse(Console.ReadLine());

                if (input_user == 1)
                {
                    Console.Write("출금하실 금액을 입력하세요 : ");
                    amount = int.Parse(Console.ReadLine());

                    if (BJK.Balance < amount)
                    {
                        Console.WriteLine($"잔액이 부족합니다. 현재 잔액은 {BJK.Balance}원 입니다.");
                    }
                    else
                    {
                        BJK.OutputMoney(amount);
                        Console.WriteLine($"출금이 완료됐습니다. 현재 잔액은 {BJK.Balance}원 입니다.");
                    }

                }

                else if (input_user == 2)
                {
                    Console.Write("입금하실 금액을 입력하세요 : ");
                    amount = int.Parse(Console.ReadLine());
                    BJK.InputMoney(amount);

                    Console.WriteLine($"입금이 완료 됐습니다. 현재 잔액은 {BJK.Balance}원 입니다.");
                }

                else if (input_user == 3)
                {
                    Console.WriteLine($"현재 잔액은 {BJK.Balance}원 입니다.");
                }
                else
                {
                    Console.Write("1~3까지의 숫자만 입력해주세요");
                    continue;
                }
                #endregion
            }
        }
    }
}
