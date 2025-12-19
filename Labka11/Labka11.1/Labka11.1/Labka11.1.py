# -*- coding: utf-8 -*-
# coding: utf-8
def filter_even_numbers_comprehension(nums: list[int]) -> list[int]:
  
    return [num for num in nums if num % 2 == 0]

print("filtration")
print("=" * 40)

#1отримання вхідних даних від користувача
input_str = input("Enter the list of numbers (examp: 1 2 3 4 5): ")

#2 обробка вхідних даних
try:
   
    str_list = input_str.split()

    numbers = [int(item) for item in str_list]

    #3 виклик функції та виведення результату
    if numbers:

        even_nums = filter_even_numbers_comprehension(numbers)
        

        print(f"\n Starting list: {numbers}")
        print(f"filtered list: {even_nums}")
    else:
        print("no numbers")

except ValueError:
    print("\nerror, enter only numbers.")

