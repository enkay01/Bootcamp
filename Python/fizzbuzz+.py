def fizzbuzz(n):
    for i in range(1, n+1):
        if i % 3 == 0 and i % 5 == 0:
            print("FizzBuzz")
        elif i % 3 == 0:
            print("Fizz")
        elif i % 5 == 0:
            print("Buzz")
        elif i % 7 == 0:
            print("Bang")
        elif i % 11 == 0:
            print("Bong")
        elif i % 13 == 0:
            print("Fezz")
        elif i % 17 == 0:
            print("BuzzFizz")
        elif i % 3 == 0 and i % 5 == 0 and i % 7 == 0:
            print("FizzBuzzBang")
        elif i % 3 == 0 and i % 5 == 0 and i % 11 == 0:
            print("FizzBuzzBong")
        elif i % 3 == 0 and i % 5 == 0 and i % 13 == 0:
            print("FizzBuzzFezz")
        elif i % 3 == 0 and i % 5 == 0 and i % 7 == 0 and i % 11 == 0:
            print("FizzBuzzBangFezz")
        elif i % 3 == 0 and i % 5 == 0 and i % 7 == 0 and i % 11 == 0 and i % 13 == 0:
            print("FizzBuzzBangFezzBong")
        elif i % 3 == 0 and i % 5 == 0 and i % 7 == 0 and i % 11 == 0 and i % 13 == 0 and i % 17 == 0:
            print("FizzBuzzBangFezzBongBuzzFizz")
        else:
            print(i)


fizzbuzz(1000)