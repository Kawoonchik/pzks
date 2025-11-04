import tkinter as tk
from tkinter import messagebox
from collections import namedtuple

# ---------------------------------------------
# Define namedtuple
# ---------------------------------------------
Pensioner = namedtuple("Pensioner", ["surname", "birth_year", "pension", "address"])

# Create 7 pensioners (example data)
pensioners = (
    Pensioner("Smith", 1950, 6200, "New York"),
    Pensioner("Johnson", 1948, 5800, "Chicago"),
    Pensioner("Williams", 1955, 7000, "Los Angeles"),
    Pensioner("Brown", 1952, 5600, "Houston"),
    Pensioner("Jones", 1947, 5100, "Phoenix"),
    Pensioner("Garcia", 1958, 7400, "Dallas"),
    Pensioner("Miller", 1951, 5900, "San Diego"),
)

# ---------------------------------------------
# Function to calculate pension surcharge
# ---------------------------------------------
def surcharge(pensioners_tuple):
    avg_pension = sum(p.pension for p in pensioners_tuple) / len(pensioners_tuple)
    below_avg = [p.surname for p in pensioners_tuple if p.pension < avg_pension]

    result_text = f"Average pension: {avg_pension:.2f}\n"
    if below_avg:
        result_text += "People receiving pension surcharge:\n" + ", ".join(below_avg)
    else:
        result_text += "No one receives a pension surcharge."

    return result_text

# ---------------------------------------------
# Function triggered by the GUI button
# ---------------------------------------------
def show_surcharge():
    result_text = surcharge(pensioners)
    output_text.set(result_text)

def update_pensions():
    try:
        increase = float(entry_increase.get())
    except ValueError:
        messagebox.showerror("Error", "Please enter a valid numeric value for increase.")
        return

    global pensioners
    pensioners = tuple(p._replace(pension=p.pension + increase) for p in pensioners)
    messagebox.showinfo("Updated", "Pension values updated successfully!")
    show_surcharge()

# ---------------------------------------------
# GUI Setup
# ---------------------------------------------
root = tk.Tk()
root.title("Pensioners Surcharge Analyzer")
root.geometry("700x500")
root.config(bg="#F8F9F9")

# Title
tk.Label(root, text="Pensioners Surcharge Calculation", font=("Arial", 16, "bold"), bg="#F8F9F9").pack(pady=10)

# List of pensioners
frame_list = tk.Frame(root, bg="#F8F9F9")
frame_list.pack(pady=10)

tk.Label(frame_list, text="List of Pensioners:", font=("Arial", 13, "bold"), bg="#F8F9F9").pack(anchor="w")

listbox_pensioners = tk.Listbox(frame_list, width=80, height=10, font=("Consolas", 11))
listbox_pensioners.pack(pady=5)

for p in pensioners:
    listbox_pensioners.insert(tk.END, f"{p.surname:<10} | {p.birth_year:<6} | {p.pension:<6} | {p.address}")

# Buttons
frame_buttons = tk.Frame(root, bg="#F8F9F9")
frame_buttons.pack(pady=15)

tk.Button(frame_buttons, text="Show Surcharge Info", command=show_surcharge, font=("Arial", 12), bg="#5DADE2", width=18).grid(row=0, column=0, padx=10)

tk.Label(frame_buttons, text="Increase pensions by:", font=("Arial", 12), bg="#F8F9F9").grid(row=0, column=1, padx=5)
entry_increase = tk.Entry(frame_buttons, width=8, font=("Arial", 12))
entry_increase.grid(row=0, column=2, padx=5)
tk.Button(frame_buttons, text="Apply Increase", command=update_pensions, font=("Arial", 12), bg="#58D68D", width=15).grid(row=0, column=3, padx=10)

# Output
output_text = tk.StringVar()
tk.Label(root, textvariable=output_text, font=("Arial", 13), fg="green", bg="#F8F9F9", wraplength=650, justify="left").pack(pady=20)

root.mainloop()
