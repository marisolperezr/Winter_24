
import math

def number_pi_euler(n):
    suma = 0
    for i in range(1, n+1):
        suma += 1 / (i**2)
    return math.sqrt(6 * suma)
    
print(number_pi_euler(10))


