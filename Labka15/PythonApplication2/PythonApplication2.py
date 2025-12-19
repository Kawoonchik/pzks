import pandas as pd

students = pd.read_csv("https://raw.githubusercontent.com/mwaskom/seaborn-data/master/students.csv")
tips = pd.read_csv("https://raw.githubusercontent.com/mwaskom/seaborn-data/master/tips.csv")
penguins = pd.read_csv("https://raw.githubusercontent.com/mwaskom/seaborn-data/master/penguins.csv")

students["id"] = range(1, len(students) + 1)
tips["id"] = range(1, len(tips) + 1)
penguins["id"] = range(1, len(penguins) + 1)

merge_left = pd.merge(students, tips, on="id", how="left")
print("=== LEFT MERGE ===")
print(merge_left.head(), "\n")

merge_inner = pd.merge(students, tips, on="id", how="inner")
print("=== INNER MERGE ===")
print(merge_inner.head(), "\n")

merge_indicator = pd.merge(students, tips, on="id", how="inner", indicator=True)
print("=== MERGE WITH INDICATOR ===")
print(merge_indicator[["_merge"]].head(), "\n")

students2 = students.set_index("id")
tips2 = tips.set_index("id")
penguins2 = penguins.set_index("id")

joined = students2.join(penguins2, lsuffix="_student", rsuffix="_penguin")
print("=== JOIN RESULT ===")
print(joined.head())

