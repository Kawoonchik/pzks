
import pandas as pd

url = "https://raw.githubusercontent.com/datasciencedojo/datasets/master/titanic.csv"
df = pd.read_csv(url)

print("HEAD:")
print(df.head(3), "\n")

print("TAIL:")
print(df.tail(), "\n")

print("SHAPE:")
print(df.shape, "\n")

print("COLUMNS:")
print(df.columns, "\n")

print("DTYPES:")
print(df.dtypes, "\n")

print("LOC first:")
print(df.loc[0], "\n")

print("ILOC 1 sentence, 3 column:")
print(df.iloc[0, 2], "\n")

print("DESCRIBE:")
print(df.describe(), "\n")

print("VALUE_COUNTS for 'Sex':")
print(df["Sex"].value_counts(), "\n")

print("UNIQUE for 'Embarked':")
print(df["Embarked"].unique(), "\n")

print("CORRELATION:")
print(df.corr(numeric_only=True), "\n")

print("SAMPLE:")
print(df.sample(5), "\n")
