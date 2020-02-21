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
using System.Collections;
namespace 샌즈어
{
	class Program
	{
		static string[] lines;
		
		public static Hashtable intHt = new Hashtable();
		public static Hashtable strHt = new Hashtable();
		public static int numberOfRepetitions = 0;
		public static int BackPoint = 0;
		
		public static void Main(string[] args)
		{
			Console.WriteLine("입력방식을 선택해주세요. \n직접입력 - 0\n파일업로드 - 0이 아닌 수");
			string answer = Console.ReadLine();
			if(answer != "0"){
				Console.WriteLine("실행시킬 파일 위치를 입력해주세요.");
				lines = File.ReadAllLines(Console.ReadLine(),System.Text.Encoding.Default);
			}
			string line = "";
			int numberTimesRepeat = int.MaxValue;
			if(answer != "0"){
				numberTimesRepeat = lines.Length;
			}
			for(int a = 0; a < numberTimesRepeat; a++){
				if(answer == "0"){
					Console.Write("\n>>");
					line = Console.ReadLine();
				}
				else{
					line = lines[a];
				}
				if(line.Contains("참고로")){
					bool linebreak = false;
					bool isVar = false;
					if(!(line.Contains("\""))){
						isVar = true;
					}
					if(line.Contains(")습니다")){
						linebreak = true;
					}
					print(line, linebreak, isVar);
				}
				else if(line.Contains("하지만 잠이 들었을때 창을 옮겨서")){
					bool judgment = condition(line);
					if(!judgment){
						a = lineOver(a);
					}
				}
				else if(line.Contains("샌즈의 공격은") && line.Contains("이 답니다")){
					intVariableDeclaration(line);
				}
				else if(line.Contains("샌즈는") && line.Contains("공격을 가지고 있습니다")){
					stringVariableDeclaration(line);
				}
				else if(line.Contains("자신의 턴을") && line.Contains("동안 유지한채로 잠에듭니다")){
					repetition(line, a);
				}
				
				if(line.Contains("]") && numberOfRepetitions != 0){
					numberOfRepetitions--;
					a = BackPoint;
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
		
		static void repetition(string line, int point){ // 자신의 턴을 '정수'동안 유지한채로 잠에듭니다
			int start = line.IndexOf("자신의 턴을 ") + 7;
			int end = (line.IndexOf("동안 유지한채로 잠에듭니다")) - start;
			int repetitionNumber = 0;
			try{
				repetitionNumber = int.Parse(line.Substring(start, end));
			}
			catch{
				Console.WriteLine(line.Substring(start, end) + "은 정수가 아닙니다.");
				return;
			}
			numberOfRepetitions = repetitionNumber - 1;
			BackPoint = findBracket(point);
		}
		
		static int findBracket(int point){
			int newPoint = point;
			for(int a = point; a < lines.Length; a++){
				if(lines[a].Contains("[")){
					newPoint = a;
					break;
				}
			}
			return newPoint;
		}
		
		static bool condition(string line){
			int start = line.IndexOf("하지만 잠이 들었을때 창을 옮겨서 (") + 20;
			int end = (line.IndexOf(",")) - start;
			string var1Name = line.Substring(start, end);
			
			start = line.IndexOf(",") + 1;
			end = (line.LastIndexOf(")을 시도하고 1차공격은")) - start;
			string var2Name = line.Substring(start, end);
			
			string var1 = "";
			if(strHt[var1Name] != null){
				var1 = strHt[var1Name].ToString();
			}
			else if(intHt[var1Name] != null){
				var1 = intHt[var1Name].ToString();
			}
			else{
				Console.WriteLine(var1Name + " 라는 이름의 변수를 찾을 수 없습니다.");
			}
			
			string var2 = "";
			if(strHt[var2Name] != null){
				var2 = strHt[var2Name].ToString();
			}
			else if(intHt[var2Name] != null){
				var2 = intHt[var2Name].ToString();
			}
			else{
				Console.WriteLine(var2Name + " 라는 이름의 변수를 찾을 수 없습니다.");
			}
			
			if(var1 == var2){
				return true;
			}
			else{
				return false;
			}
		}
	}
}