from typing import Iterator

def float_range(start: float, stop: float, step: float) -> Iterator[float]:


    if step == 0.0:
        raise ValueError("Step cannot be zero.")

    current = start
    

    PRECISION = 10 

    if step > 0.0:

        while current < stop:
            yield round(current, PRECISION)
            current += step
            
    elif step < 0.0:

        while current > stop:
            yield round(current, PRECISION)
            current += step

# Main  ---
if __name__ == "__main__":
    
    print("Example 1: Positive step (1.0, 2.0, 0.3)")

    result1 = list(float_range(1.0, 2.0, 0.3))
    print(result1)
    
    print("\nExample 2: Negative step (5.0, 3.0, -0.5)")

    result2 = list(float_range(5.0, 3.0, -0.5))
    print(result2)
    
    print("\nExample 3: Small step (0.0, 1.0, 0.1), first 3 elements")

    result3 = list(float_range(0.0, 1.0, 0.1))[:3]
    print(result3)
    
    print("\nExample 4: Start and stop are same (0.0, 0.0, 1.0)")

    result4 = list(float_range(0.0, 0.0, 1.0))
    print(result4)

    print("\nExample 5: Negative step but start < stop (1.0, 2.0, -1.0)")

    result5 = list(float_range(1.0, 2.0, -1.0))
    print(result5)
    
    print("\nExample 6: Test for ValueError (step = 0)")
    try:
        list(float_range(1.0, 5.0, 0.0))
    except ValueError as e:
        print(f"Received expected error: {e}")
