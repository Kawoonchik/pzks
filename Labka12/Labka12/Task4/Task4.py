
from typing import Iterable, Callable

SPECIAL_CHARS = "!@#$%^&*()"

def has_uppercase(password: str) -> bool:
    return any(c.isupper() for c in password)

def has_digit(password: str) -> bool:
    return any(c.isdigit() for c in password)

def is_long_enough(password: str) -> bool:
    return len(password) >= 8

def has_special_char(password: str) -> bool:
    return any(c in SPECIAL_CHARS for c in password)

def no_spaces(password: str) -> bool:
    return ' ' not in password

def validate_password(password: str) -> bool:
    rules: list[Callable[[str], bool]] = [
        has_uppercase,
        has_digit,
        is_long_enough,
        has_special_char,
        no_spaces,
    ]
    return all(rule(password) for rule in rules)


print("\nTask 1.4: Password Validation")
print(f"'StrongPass1!': {validate_password('StrongPass1!')}")
print(f"'weakpass': {validate_password('weakpass')}")
print(f"'Short7!': {validate_password('Short7!')}")
print(f"'With Space1!': {validate_password('With Space1!')}")
print(f"'NoSpecialChar1': {validate_password('NoSpecialChar1')}")