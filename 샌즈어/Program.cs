/*
 * Created by SharpDevelop.
 * User: asdf-2345
 * Date: 2020-02-14
 * Time: 오후 12:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace 샌즈어
{
	//출력
	//  참고로("출력할 내용")
	//  참고로("출력할 내용")습니다  (다음줄로 넘어감)
	
	//변수
	//	정수형 - '변수이름'은 '정수'번째 공격을 맞고 죽습니다
	//	문자열 - 샌즈는 '문자열'한 '변수이름'공격을 가지고 있습니다
	
	//조건문
	//	하지만 잠이 들었을때 창을 옮겨서 (변수1,변수2)을 시도하고 1차공격은
	//	{
	//		참고로("피하지만")습니다
	//	}
	//조건문안에 넣은 변수2개가 같은지만 비교해줍니다.
	
	//반복문
	//	자신의 턴을 '정수'동안 유지한채로 잠에듭니다
	//	[
	//		참고로("겁나 어렵습니다.")
	//	]
	//
	//예
	//	자신의 턴을 3동안 유지한채로 잠에듭니다
	//	[
	//		참고로("겁나 어렵습니다.")
	//	]
	//출력 : 겁나 어렵습니다겁나 어렵습니다겁나 어렵습니다

	class Program
	{
		//string[] lines;
		
		//테스트용
		static string[] lines = {"참고로(\"피하지만\")습니다",
								 "참고로(\"샌즈 아시는구나\")습니다",
								 "하지만 잠이 들었을때 창을 옮겨서 ()을 시도하고 1차공격은",
								 "{",
								 "참고로(\"샌즈 아시는구나\")습니다",
								 "}",
								 "참고로(\"샌즈 아시는구나\")습니다",};
		
		public static void Main(string[] args)
		{
			variables1 var = new variables1();
			Console.WriteLine("실행시킬 파일 위치를 입력해주세요.");
			//lines = File.ReadAllLines(Console.ReadLine());
			for(int a = 0; a < lines.Length; a++){
				if(lines[a].Contains("참고로")){
					if(lines[a].Contains("습니다")){
						print(lines[a], true);
					}
					else{
						print(lines[a]);
					}
				}
				else if(lines[a].Contains("하지만 잠이 들었을때 창을 옮겨서")){
					bool judgment = condition(lines[a]);
					if(!judgment){
						a = lineOver(a);
					}
				}
				else if(lines[a].Contains("번째 공격을 맞고 죽습니다")){
					Array.Resize(ref var.intVariables, var.intVariables.Length + 1);
					Array.Resize(ref var.stringVariables, var.stringVariables.Length + 1);
				}
				else if(lines[a].Contains("자신의 턴을") && lines[a].Contains("동안 유지한채로 잠에듭니다")){
					
				}
			}
			Console.ReadKey();
		}
		
		public struct variables1{
			public string[] stringVariables;
			public int[] intVariables;
		}
		
		static int lineOver(int point){
			int newPoint = point;
			for(int a = point; a < lines.Length; a++){
				if(lines[a].Contains("}")){
					newPoint = a;
					break;
				}
			}
			return newPoint;
		}
		
		static void print(string line, bool linebreak = false){
			int start = line.IndexOf("참고로(\"") + 5;
			int end = (line.IndexOf("\")")) - start;
			string printStr  = line.Substring(start, end);
			
			Console.Write(printStr);
			
			if(linebreak == true){
				Console.Write("\n");
			}
		}
		
		static void repetition(string line){
			
		}
		
		static bool condition(string line){
			return false;
		}
	}
}