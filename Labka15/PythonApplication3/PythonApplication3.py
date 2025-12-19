
import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns 

url = "https://raw.githubusercontent.com/selva86/datasets/master/BostonHousing.csv"
df = pd.read_csv(url)

df["chas"] = df["chas"].astype(int)

agg = df.groupby("chas")["medv"].mean().reset_index()
agg = agg.rename(columns={"medv": "average_medv"})

print(agg)

plt.figure(figsize=(8, 5))
sns.barplot(
    data=agg,
    x="chas",
    y="average_medv",
    palette="viridis"  
)

print("=== Info ===")
print(df.info(), "\n")
print("=== Describe (numeric) ===")
print(df.describe(), "\n")

print("=== First 5 ===")
print(df.head(5), "\n")
print("=== Last 10 ===")
print(df.tail(10), "\n")

agg = df.groupby('chas')['medv'].mean().reset_index().rename(columns={'medv':'average_medv'})
print("=== Medium csv as chas ===")
print(agg, "\n")

plt.title("Medium medv for chas (0 = not by river, 1 = by river)")
plt.xlabel("chas")
plt.ylabel("Average medv (in 1000s)")
plt.ylim(0, agg["average_medv"].max() + 5)
plt.show()
