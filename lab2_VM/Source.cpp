#include <iostream>

using namespace std;

double* metGausa(double** mat, double* vet,int n)
{
	for (int k = 0; k < n-1; k++)
	{
		for (int i = k; i < n-1; ++i)
		{
			double kaf;
			kaf = mat[i + 1][k] / mat[k][k];

			for (int j = 0; j < n; ++j)
			{
				mat[i + 1][j] = mat[i + 1][j] - kaf * mat[k][j];
			}
			vet[i + 1] = vet[i + 1] - kaf * vet[k];
		}
	}

	double* rez = new double[n];

	for(int i = n-1; i >= 0;--i)
	{
		double sum = 0;
		for(int j = i + 1;j < n;++j)
		{
			sum += mat[i][j] * rez[j];
		}
		rez[i] = (vet[i] - sum) / mat[i][i];
	}
	
	return rez;
}

double* simIter(double** mat, double* vet, int n,double e)
{
	double** newMatr = new double*[n];
	double* newVer = new double[n];
	double* Xk = new double[n];
	double* Xk2 = new double[n];

	for(int i = 0;i < n;i++)
		newMatr[i] = new double[n];

	for(int i = 0;i < n; i++)
		for (int j = 0; j < n; j++)
		{
			if (i == j)
				newMatr[i][j] = 0;
			else 
				newMatr[i][j] = (-1)*(mat[i][j] / mat[i][i]);
		}
	
	for (size_t i = 0; i < n; i++)
	{
		newVer[i] = vet[i] / mat[i][i];
		Xk[i] = newVer[i];
	}

	while (true)
	{
		for (int i = 0; i < n; i++)
		{
			double sum = 0;
			for (int j = 0; j < n; j++)
			{
				sum += newMatr[i][j] * Xk[j];
			}

			Xk2[i] = newVer[i] + sum;
		}
	
		for (int i = 0; i < n; i++)
		{
			Xk[i] = Xk2[i];
		}
	}
}


int main()
{

	double** matrix = new double*[3];
	double vector[3] = { 17,16,20 };
	double* res;
	
		matrix[0] = new double[3]{ 1,1,15};
		matrix[1] = new double[3]{ 15,0,1 };
		matrix[2] = new double[3]{ 4,15,1 };

	res = metGausa(matrix, vector, 3);

	for (int i = 0; i < 3; i++)
		cout << res[i] << endl;
}