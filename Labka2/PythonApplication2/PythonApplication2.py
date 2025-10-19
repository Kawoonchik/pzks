
a = list(map(int, input("Enter 1 massive: ").split()))
b = list(map(int, input("Enter 2 massive: ").split()))


arr1 = a[1::2]


arr2 = b[0::2]


new_arr = []

for i in range(min(len(arr1), len(arr2))):
    new_arr.append(arr1[i]) 
    new_arr.append(arr2[i])  


if len(arr1) > len(arr2):
    new_arr.extend(arr1[len(arr2):])
elif len(arr2) > len(arr1):
    new_arr.extend(arr2[len(arr1):])


print("New massive:", new_arr)

