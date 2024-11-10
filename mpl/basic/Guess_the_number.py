import random

total_tries = 0
secret_num=10

while True:
    a = int(input("Enter the number from 1 to 100: "))
    total_tries+=1
        print("You guessed!")
        break
    elif a > secret_num:
        print("Too big")
    else:
        print("Too small")
print(total_tries)
