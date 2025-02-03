

/******************************************************************************
María Soledad Pérez Ruiz
Ejercicio 2

*******************************************************************************/
using System;
class HelloWorld {
  static void Main() {
    int a = 1;
    int b = 2;
    int next = 0;
    int sum = 2;
    
    while ( next < 4000000){
        next = a + b;
        a = b;
        b = next;
        
        if ( next % 2 == 0){
            sum += next;
        }
    }

    Console.WriteLine("La suma de todos valores pares de fibonacci hasta 4000000 es"+ sum);
  }
}