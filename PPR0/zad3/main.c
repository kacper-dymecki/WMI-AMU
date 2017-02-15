#include <stdio.h>

int main()
{
    float u,n,s,cena;
    scanf("%f%f%f", &u, &n, &s);
    cena = s / ((u / 2) + n);
    printf("%.2f", cena);
}