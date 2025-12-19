
def sort_by_age(people: list[dict]) -> list[dict]:
    return sorted(people, key=lambda d: d['age'])

print(
    sort_by_age(
        [
            {"name": "Oleg", "age": 30},
            {"name": "Bob", "age": 25},
            {"name": "nazar", "age": 35},
        ]
    )
)

print(
    sort_by_age(
        [
            {"name": "SF", "age": 18},
            {"name": "pudge", "age": 22},
            {"name": "Yegorka", "age": 20}
        ]
    )
)