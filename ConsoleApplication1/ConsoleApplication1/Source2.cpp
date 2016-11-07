#include<iostream>
#include<stdio.h>
#include<direct.h>
#include<string.h>
using namespace std;
void Menu();
void CopyDir();
void RelocateDir();
void RemoveDir();

void main()
{
	Menu();
}
void Menu()
{
	int ch;
	cout << "Izberete funkciq:" << endl;
	cout << "1: Kopirane " << endl;
	cout << "2: Premestvane" << endl;
	cout << "3: Iztrivane na papka" << endl;
	cin >> ch;
	switch (ch)
	{
	case 1:
		CopyDir();
		break;
	case 2:
		RelocateDir();
		break;
	case 3:
		RemoveDir();
		break;
	default:
		break;

	}
}
void CopyDir()
{
	char Name[50];
	cout << "Napioshete imeto na papkata" << endl;
	cin >> Name;
	int count = 0;
	
	if (_mkdir(Name)==0)
	{
		count++;
		char*co;
		itoa(count, co, 10);
		strcat(Name, co);
		_mkdir(Name);
	}
}
