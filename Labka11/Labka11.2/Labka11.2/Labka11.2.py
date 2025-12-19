
class Countdown:
   
    
    def __init__(self, start: int):

        self.current = start

    def __iter__(self):
  
        return self

    def __next__(self) -> int:      
        if self.current < 0:
            raise StopIteration
        else:
            number_to_return = self.current
            self.current -= 1
            return number_to_return

# Main ---
if __name__ == "__main__":
    
    print("---Test 1: Countdown(5) ---")
    for n in Countdown(5):
        print(n, end=" ")
    print("\n")

    print("--- Test 2: list(Countdown(3)) ---")
    print(list(Countdown(3)))
    print("\n")

    print("--- Test 3: list(Countdown(0)) ---")
    print(list(Countdown(0)))
    print("\n")

    print("--- Test 4: list(Countdown(-3)) ---")
    print(list(Countdown(-3)))
    print("\n")