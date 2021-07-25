#include <iostream>
#include <vector>
#include <algorithm>
#include <string>
#include <cmath>
using namespace std;
const int N = 100000;
vector<int> g[N];
bool used[N];
int a[N];
int b[N];
int m;
int ans = 0;
void dfs(int v)
{
    used[v] = 1;
    if (b[v] > m)
        return;
    int count = 0;
    for (int u : g[v])
    {
        if (used[u])
            continue;

        b[u] = b[v] + 1;
        if (a[u] == 0)
            b[u] = 0;
        dfs(u);
        count++;
    }
    if (count == 0)
        ans++;
    return;
}
int main()
{
    int n;
    cin >> n >> m;
    for (int i = 0; i < n; i++)
        cin >> a[i];
    for (int i = 1; i < n; i++)
    {
        int u, v;
        cin >> u >> v;
        u--;
        v--;
        g[v].push_back(u);
        g[u].push_back(v);
    }
    b[0] = a[0];
    dfs(0);
    cout << ans;



}