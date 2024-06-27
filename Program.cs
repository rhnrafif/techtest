class Program
{
	public static void Main(string[] args)
	{
		//test 1
		string s = "abbcccd";
		int[] query = { 1, 3, 9, 8 };
		List<string> result = weightString(s, query);

		//Console.WriteLine(result);
		foreach(var res in result)
		{
			//Console.WriteLine(res);
		}

		//test 2

		string inputBalance1 = "{ ( ( [ ] ) [ ] ) [ ] }"; //expected YES
		string inputBalance2 = "{ [ ( ] ) }"; //Excpected NO

		//Console.WriteLine(isBalanced(inputBalance1));
		//Console.WriteLine(isBalanced(inputBalance2));


		//test 3
		string ss = "3943";
		int k = 0;
		int resultPalindrome = isHighesPalindrome(ss, k);

		Console.WriteLine(resultPalindrome);

	}

	private static List<string> weightString(string s, int[] queries)
	{
		List<string> result = new List<string>();
		int charWeight = 0;
		int currentChar = -1;
		HashSet<int> weights = new HashSet<int>();

		foreach (int c in s)
		{
			if (c != currentChar)
			{
				charWeight = c - 'a' + 1;
				currentChar = c;
			}
			else
			{
				charWeight += c - 'a' + 1;
			}
			weights.Add(charWeight);
		}

		//check
		foreach(var query in queries)
		{
			result.Add(weights.Contains(query) ? "YES" : "NO");
		}

		return result;
	}

	public static string isBalanced(string input)
	{
		string result = "";

		Stack<char> stack = new Stack<char>();

		foreach(char s in input)
		{
			if( s == '(' || s == '[' || s == '{')
			{
				stack.Push(s);
            }else if ( s == ')')
			{
				if(stack.Count == 0 || stack.Pop() != '(')
				{
					return "NO";
				}
			}else if (s == ']')
			{
				if(stack.Count == 0 || stack.Pop() != '[')
				{
					return "NO";
				}
			}else if (s == '}')
			{
				if(stack.Count == 0 || stack.Pop() != '{')
				{
					return "NO";
				}
			}
		}

		return stack.Count() == 0 ? "YES" : "NO";
	}

	private static int isHighesPalindrome(string s, int k)
	{
		if(String.IsNullOrEmpty(s))
		{
			return -1;
		}

		return FindPalindrome(s, 0, s.Length -1, k);
	}

	private static int FindPalindrome(string s, int left, int right, int k)
	{
		if( left >= right)
		{
			return int.Parse(s);
		}
		int result = -1;
		if (s[left] == s[right])
		{
			//recursive
			FindPalindrome(s, left + 1, right - 1, k);
		}
		else
		{
			if(k > 0)
			{
				int repLeft = FindPalindrome(s.Substring(0, left) + s[right] + s.Substring(left + 1), left, right - 1, k - 1);

				int repRight = FindPalindrome(s.Substring(0, right) + s[left] + s.Substring(right + 1), left + 1, right, k - 1);

				result = Math.Max(repLeft, repRight);
			}
		}

		return result;
	}
}