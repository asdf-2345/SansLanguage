﻿/*
 * Created by SharpDevelop.
 * User: asdf-2345
 * Date: 2020-02-14
 * Time: 오후 12:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections;
namespace 샌즈어
{
	//출력
	//  참고로("출력할 내용")
	//  참고로("출력할 내용")습니다  (다음줄로 넘어감)
	//	참고로('변수이름')
	//	참고로('변수이름')
	
	//만들예정인거
	
	//변수
	//	정수형 - 샌즈의 공격은 '변수이름'당 '정수'이 답니다
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
								 "참고로(\"샌즈 아시는구나\")습니다",
								 "샌즈는 테스트문자열한 테스트공격을 가지고 있습니다",
								 "참고로(테스트)습니다"};
		public static Hashtable intHt = new Hashtable();
		public static Hashtable strHt = new Hashtable();
			
		public static void Main(string[] args)
		{
			Console.WriteLine("실행시킬 파일 위치를 입력해주세요.");
			//lines = File.ReadAllLines(Console.ReadLine());
			for(int a = 0; a < lines.Length; a++){
				if(lines[a].Contains("참고로")){
					bool linebreak = false;
					bool isVar = false;
					if(!(lines[a].Contains("\""))){
						isVar = true;
					}
					if(lines[a].Contains("습니다")){
						linebreak = true;
					}
					print(lines[a], linebreak, isVar);
				}
				else if(lines[a].Contains("하지만 잠이 들었을때 창을 옮겨서")){
					bool judgment = condition(lines[a]);
					if(!judgment){
						a = lineOver(a);
					}
				}
				else if(lines[a].Contains("샌즈의 공격은") && lines[a].Contains("이 답니다")){
					intVariableDeclaration(lines[a]);
				}
				else if(lines[a].Contains("샌즈는") && lines[a].Contains("공격을 가지고 있습니다")){
					stringVariableDeclaration(lines[a]);
				}
				else if(lines[a].Contains("자신의 턴을") && lines[a].Contains("동안 유지한채로 잠에듭니다")){
					
				}
			}
			Console.ReadKey();
		}
		
		static void intVariableDeclaration(string line){
			int varNamePoint1 = line.IndexOf("샌즈의 공격은 ") + 8;
			int varNamePoint2 = line.LastIndexOf("당 ");
			int varValuePoint1 = line.LastIndexOf("이 답니다");
			
			string varName = line.Substring(varNamePoint1, varNamePoint2 - varNamePoint1);
			int varValue = int.Parse(line.Substring(varNamePoint2 + 2, varValuePoint1 - (varNamePoint2 + 2)));
			
			intHt[varName] = varValue;
		}
		
		static void stringVariableDeclaration(string line){
			int varNamePoint1 = line.IndexOf("샌즈는 ") + 4;
			int varNamePoint2 = line.LastIndexOf("한 ");
			int varValuePoint1 = line.LastIndexOf("공격을 가지고 있습니다");
			
			string varName = line.Substring(varNamePoint2 + 2, varValuePoint1 - (varNamePoint2 + 2));
			string varValue = line.Substring(varNamePoint1, varNamePoint2 - varNamePoint1);
			
			strHt[varName] = varValue;
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
		
		static void print(string line, bool linebreak, bool isVar){
			int start = 0;
			int end = 0;
			string printStr = "";
			
			if(!isVar){
				start = line.IndexOf("참고로(\"") + 5;
				end = (line.IndexOf("\")")) - start;
				printStr = line.Substring(start, end);
			}
			else{
				start = line.IndexOf("참고로(") + 4;
				end = (line.IndexOf(")")) - start;
				string printVarName = line.Substring(start, end);
				if(strHt[printVarName] != null){
					printStr = strHt[printVarName].ToString();
				}
				else if(intHt[printVarName] != null){
					printStr = intHt[printVarName].ToString();
				}
				else{
					Console.WriteLine(printVarName + " 라는 이름의 변수를 찾을 수 없습니다.");
				}
			}
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