

/******************************************************************************
María Soledad Pérez Ruiz
Ejercicio 4

Largest Palindrome Product 
*******************************************************************************/
using System;
  class HelloWorld {  
  static bool IsPalindrome( int number){
      int original = number;
      int reverse = 0;
      
      while (number > 0){
          int digit = number % 10;  //last digit
          reverse = reverse * 10 + digit; // adding the last digit to the reverse number
          number /=10;
      }
      return original == reverse;
  }
    
  static void Main() {
    int maxp = 0;
    int product;
    
    for ( int i = 100; i<999; i++){
        for (int j=100; j<999; j++){
            product = i*j;
            
            if ( IsPalindrome (product) && product > maxp) {
                maxp = product;
            }
        }
    }
    
     Console.WriteLine("The largest Palindrome between 100 and 999 is: " +maxp);
}

}