
/******************************************************************************

María Soledad Pérez Ruiz

Ejercicio 6.

*******************************************************************************/
using System;
class HelloWorld {
  static void Main() {
    int sumc = 0;
    
    for (int i= 1 ; i<=100;i++){
        int cuadrado= i*i;
        sumc += cuadrado;
    }
    Console.WriteLine("La suma de los cuadrados es"+sumc);
    
    int sum2 = 0;
    
    for (int j=0; j<=100; j++){
        sum2 += j;
    }
    
    int sumacuadrado = sum2*sum2;
    
    Console.WriteLine("La suma al cuadrado es:"+sumacuadrado);
    
    int sol = sumacuadrado - sumc ;
    
    Console.WriteLine("La diferencia entre ambas es:"+sol);
  }
}