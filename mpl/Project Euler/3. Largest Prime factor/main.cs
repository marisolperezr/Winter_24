

/******************************************************************************
María Soledad Pérez Ruiz
Ejercicio 3
3
Largest prime factor of the number 600851475143

*******************************************************************************/
using System;
class HelloWorld {
  static void Main() {
      
    long num = 600851475143;
    long lpf = 0;
    
    Console.WriteLine( + num + " 's prime factors are : ");
    
    while ( num % 2 == 0 ){
        Console.WriteLine (2);
        lpf = 2;
        num /=2;
    }

    // divide number into odd numbers
    
    int divisor = 3;
    
    while (num > 1 ){
        while ( num % divisor == 0){
            Console.WriteLine(divisor);
            lpf = divisor;
            num /= divisor;
    }
    
      divisor +=2;
    }
    
     Console.WriteLine("The Largest Prime Factor of " + 600851475143 + " is " + lpf);
   
  }
}