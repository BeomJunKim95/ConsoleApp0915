using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0915
{
	class Static_practice
	{
		class MyCat
		{
			public static int Sum(int x, int y)
			{
				return x + y;
			}
			public int Sum(double x,int y)
			{
				return (int)(x + y);
			}
		}
		int Sum(int x,int y)
		{
			return x + y;
		}
		//메인함수를 스태틱으로 쓰는 이유는 누군가가 new로 인스턴스를 만들어 시작을 해야하는데 프로그램의 시작점이라
		//인스턴스 호출을 할수가없으니 메인함수는 정적일수 밖에 없다
		static void Main() //static 메서드는 정적끼리만 가능
		{
			MyCat c1 = new MyCat();
			
			Static_practice s1 = new Static_practice();// 인스턴스를 생성해야 static인 메인함수에 호출이 가능해짐
													   // 다른방법은 다른 클래스를 생성해 인스턴스 메서드 만들기
			int result = s1.Sum(5, 3); //메인함수가 static이라 인스턴스인 Sum함수가 호출되지 않음
			result = MyCat.Sum(5, 3);
			c1.Sum(2.5, 5);

			Random rand = new Random();
			rand.Next(101);

			int[] arr = new int[3];
			for(int i=0;i<arr.Length; i++)
			{

			}
		}
	}
}
