
/******************************************************************************

María Soledad Pérez Ruiz

Ejercicio 5. Número positivo más pequeño divisible por todos los números del 1 al 20.

*******************************************************************************/
using System;
class HelloWorld {
  static void Main() {
    int number = 20; // number has to be at least 2o
    
    while (true){
        bool isdivisible = true;
        
        for(int divisor = 2; divisor <=20; divisor++){
            if (number % divisor != 0){
                isdivisible = false;
                break;
            }
        }
        
        if (isdivisible){
            Console.WriteLine("The number is:" +number);
            break;
        }
        
        number++;
    }
  }
}