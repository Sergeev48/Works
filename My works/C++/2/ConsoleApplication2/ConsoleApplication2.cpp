#include <iostream>
#include <vector>
using namespace std;
bool is_prime(int n)
{
    for (int i = 2; i * i <= n; i++)
    {
        if (n % i == 0)
        {
            return false;
        }
    }
    return true;
}
int main()
{
    int n, k, y = 0;
    cin >> n >> k;
    vector <int> a(n);
    int j = 0;
    for (int i = 4; i < n; i++)
    {
        if (is_prime(i) == true)
        {
            a[j] = i;
            j++;
        }
    }
    for (int i = 0; i < j; i++)
    {
        int h = a[i] + a[i + 1] + 1;
        for (int q = 0; q < j; q++)
        {
            if (h == a[q])
                y++;
        }
    }
    if ((y + 1) == k || (y + 1) > k)
        cout << "YES";
    else
        cout << "NO";
}