def filter_long_words(words: list[str]) -> list[str]:
    return list(filter(lambda word: len(word) > 3, words))

print("\nask 1.2: Filter Long Words ")

print(filter_long_words(["a", "the", "code", "Python", "is", "fun"]))

print(filter_long_words(["cat", "dog", "fish", "go", "egg"]))

print(filter_long_words(["", "aa", "bbb", "cccc", "ddddd"]))

print(filter_long_words([]))
