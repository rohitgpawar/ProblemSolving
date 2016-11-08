package Brackets_test;

import java.io.Console;
import java.util.Scanner;
import java.util.Stack;

public class TestBrackets {

	public static void main(String[] args) {
		
		Scanner scanner = new Scanner(System.in);
		System.out.println("Eenter the string : ");
		String str = scanner.next(); //System.console().readLine();
		
		Stack<Character> stck = new Stack<Character>();
		
		if(str!=null && str.length()!=0)
		{
			for(char c : str.toCharArray())
			{
				if(!stck.isEmpty() && stck.peek().equals(c))
					stck.pop();
				
				else
				{
					switch(c)
					{
						case '(':
							stck.push(new Character(')'));
							break;
						case '[':
							stck.push(new Character(']'));
							break;
						case '{':
							stck.push(new Character('}'));
							break;
					}
				}
			}
			
			if(stck.isEmpty())
				System.out.println("Brackets are matching");
			else
				System.out.println("Brackets are not matching");
		}
	}
}
