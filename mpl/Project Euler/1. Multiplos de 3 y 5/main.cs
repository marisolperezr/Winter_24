

/******************************************************************************

María Soledad Pérez Ruiz
Ejercicio 1.

*******************************************************************************/
using System;
class HelloWorld {
  static void Main() {
      int sum=0;
      
      for (int num=0; num<100; num++){
          if (num%3 == 0 || num%5 == 0){
              Console.WriteLine(num); 
              sum += num;
          }
      }
    Console.WriteLine("La suma de todos los multiplos de 3 o 5 por debajo de 100 es"+ sum);
  }
}
