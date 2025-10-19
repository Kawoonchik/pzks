
import random


rows = 10   
cols = 12   


salaries = []
for i in range(rows):
    row = []
    for j in range(cols):
        row.append(random.randint(5000, 20000))
    salaries.append(row)


print("Worker's salaries (rows - workers, columns - months):")
for row in salaries:
    print(row)


quarter = int(input("\nEnter number of quarter (1-4): "))


if quarter < 1 or quarter > 4:
    print("Error: number should be from 1 to 4.")
else:
    
    start = (quarter - 1) * 3      
    end = start + 3               

   
    total_salary = 0
    for i in range(rows):        
        for j in range(start, end): 
            total_salary += salaries[i][j]

    
    pension_fund = total_salary * 0.11


    print(f"\nOverall ssalary for {quarter} quorter: {total_salary}")
    print(f"Sum of a pension fund (11%): {pension_fund:.2f}")
