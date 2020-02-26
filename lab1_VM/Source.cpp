#include <iostream>
#include <math.h>

using namespace std;

class desPolenom 
{
private:
	double (*f)(double x);
	double (*dfdx)(double x);
public:
	desPolenom(double (*f)(double x), double (*dfdx)(double x))
	{
		this->dfdx = dfdx;
		this->f = f;
	}

	double metNewton(double x0,double e,int& count)
	{
		double x1;

		x1 = x0 - this->f(x0) / this->dfdx(x0);

		count++;

		if (abs(x1 - x0) < e)
			return x1;
		else
			return metNewton(x1, e, count);
	}

	double metSimpleIter(double x0, double e, double (*fx)(double x),int& count)
	{
		double x1;

		x1 = fx(x0);

		count++;

		if (abs(x1 - x0) < e)
			return x1;
		else
			return metSimpleIter(x1, e, fx, count);

	}

	double metHalfDiv(double a, double b, double e, int& count)
	{
		double x = (a + b) / 2;
		double y = this->f(x);

		count++;

		if (y == 0)
			return x;

		if ((b - a) < 2 * e)
			return x;

		if (y*this->f(a) < 0)
			return metHalfDiv(a, x, e, count);
		else
			return metHalfDiv(x, b, e, count);
	}

};

double F(double x)
{
	return x * x - 20 * sin(x) - 5;
}

double dFdx(double x)
{
	return 2 * x - 20 * cos(x);
}

double aFX(double x)
{
	return asin((x*x -5)/20);
}


double mFX(double x)
{
	return -sqrt(20*sin(x) + 5);
}

double FX(double x)
{
	return sqrt(20 * sin(x) + 5);
}

int main()
{
	setlocale(LC_ALL, "rus");

	desPolenom test(F,dFdx);

	int count = 0;

	cout << "�������:" <<"\t"<< test.metNewton(-5, 0.000001, count) << endl;
	cout << "���������� �����: "<< count <<endl;
	count = 0;
	cout << "������� ��������:" << test.metSimpleIter(-4, 0.000001, mFX, count) << endl;
	cout << "���������� �����: " << count << endl;
	count = 0;
	cout <<"����������� �������:"<< test.metHalfDiv(-5,-4.5,0.000001, count) << endl ;
	cout << "���������� �����: " << count << endl;
	count = 0;

}