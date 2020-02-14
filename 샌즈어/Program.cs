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
	//	문자열 - 샌즈는 '문자열'한 '변수이름'뎀을 가지고 있습니다
	
	//조건문
	//	하지만 잠이 들었을때 창을 옮겨서 '조건문'을 시도하고 1차공격은
	//	{
	//		참고로("피하지만")습니다
	//	}
	//	2차공격은     - else
	//	{
	//		참고로("맞고 죽습니다.")습니다
	//	}
	//
	//else if는 이렇게 구현합니다.
	//	하지만 잠이 들었을때 창을 옮겨서 '조건문'을 시도하고 1차공격은
	//	{
	//		참고로("피하지만")습니다
	//	}
	//	2차공격은     - else
	//	{
	//		하지만 잠이 들었을때 창을 옮겨서 '조건문'을 시도하고 1차공격은
	//		{
	//			참고로("맞고 죽습니다.")습니다
	//		}
	//	}
	
	//반복문
	//	자신의 턴을 '정수'동안 유지한채로 잠에듭니다.
	//	{
	//		참고로("겁나 어렵습니다.")
	//	}

	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("실행시킬 파일 위치를 입력해주세요.");
			string[] lines = File.ReadAllLines(Console.ReadLine());
			for(int a = 0; lines[a] == null; a++){
				if(lines[a].Contains("참고로")){
					if(lines[a].Contains("습니다")){
						
					}
					else{
						
					}
				}
				else if(lines[a].Contains("참고로")){
					
				}
			}
		}
		
		static void print(string line, bool linebreak = false){
			
		}
	}
}