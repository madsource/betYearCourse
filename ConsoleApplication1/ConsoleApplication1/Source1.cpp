#include<iostream>
#include<math.h>
using namespace std;
int main()
{

	double  pr, days, value, doh, sum;
	cout << "Vavedete suma na credita:" << endl;
	cin >> value;
	cout << "Vavedete srok za vrastane v dni:" << endl;
	cin >> days;
	cout << "Vavedete procent lihva:" << endl;
	cin >> pr;
	doh = pr / 100 * value;
	sum = doh + value;
	cout << "Dohod:" << doh << endl;
	cout << "Suma:" << sum << endl;

	system("pause");
	return 0;
}