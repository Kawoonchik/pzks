import random
import math



koma = 1e-9  


def generate_shot(R):
  
    x = random.uniform(-R, R)
    y = random.uniform(-R, R)
    return x, y


def check_point(x, y, R):
   
    r2 = R * R
    leftCirkle = (x + R) *(x + R) + y * y
    rightCirkle = (x - R) * (x - R) + y * y

    if y>=0:
        if leftCirkle < r2:
           return "Hit"
        elif abs(leftCirkle - r2)< koma: 
              return "On the edge"
    
    if y<=0:
        if leftCirkle < r2:
           return "Hit"
        elif abs(rightCirkle - r2)< koma: 
              return "On the edge"

    
    return "Miss"


def main():
    print("Seria postriliv po misheni")
    R = float(input("Vvedit radius R (>0): "))
    print()

    
    print(f"{'#':<5} {'x':>8} {'y':>8}  Result")
    print("-" * 35)

   
    for i in range(1, 11):
        x, y = generate_shot(R)
        result = check_point(x, y, R)
        print(f"{i:<5} {x:8.3f} {y:8.3f}  {result}")


if __name__ == "__main__":
    main()


