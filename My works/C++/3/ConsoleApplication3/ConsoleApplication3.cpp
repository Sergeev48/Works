#include <iostream>
#include <string>
using namespace std;
int main()
{
	string s, q;
	int count = 0, count1 = 0, count2 = 0;
	cin >> s;
	bool start = false, start1 = false, start2 = false, finish = false, finish1 = false;
	for (int i = 0; i < s.size(); i++)
	{
		if (s[i] == '[' && !start)
			start = true;

		if (start && s[i] == ':' && !start1) {
			start1 = true;
			count1 = i;
			break;
		}

	}
	for (int j = s.size() - 1; j > 0; j--)
	{
		if (s[j] == ']' && !finish)
			finish = true;
		if (finish && s[j] == ':' && !finish1) {
			finish1 = true;
			count2 = j;
			break;
		}
	}

	if (!start || !start1 || !finish || !finish1 || count1 >= count2)
	{
		cout << -1;
		return 0;
	}
	for (int i = count1; i < count2; i++)
	{
		if (s[i] == '|')
			count++;
	}
	cout << count + 4;
}