from typing import Iterator, Dict, Any

def walk_tree(data: Dict[str, Any]) -> Iterator[str]:


    for key, value in data.items():

        yield key
        

        if isinstance(value, dict):

            yield from walk_tree(value)

if __name__ == "__main__":
    
    print("Example 1")
    tree1 = {
        "a": {
            "b": {
                "c": 1
            }
        },
        "d": 2
    }
    # ['a', 'b', 'c', 'd']
    print(list(walk_tree(tree1)))

    print("\nExample 2")
    tree2 = {
        "x": {"y": {"z": {}}},
        "m": {"n": 42}
    }
    #['x', 'y', 'z', 'm', 'n']
    print(list(walk_tree(tree2)))

    print("\nExample 3: Empty Tree")
    tree3 = {}
    # []
    print(list(walk_tree(tree3)))

    print("\nExample 4: Flat Tree ")
    tree4 = {"one": 1, "two": 2, "three": 3}
    #['one', 'two', 'three']
    print(list(walk_tree(tree4)))
