
from typing import Iterable

def capitalize_words(words: Iterable[str]) -> Iterable[str]:
    return map(str.capitalize, words)

print("\nTask 1.3: Capitalize Words")


print(list(capitalize_words(["python", "java", "c++"])))


print(tuple(capitalize_words(("hello", "world"))))


print(list(capitalize_words([""])))


print(list(capitalize_words([])))