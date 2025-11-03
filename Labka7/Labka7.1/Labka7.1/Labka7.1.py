import tkinter as tk
from tkinter import messagebox
from datetime import datetime

def calculate():
    try:
        start_str = entry_start.get()
        end_str = entry_end.get()

        # Convert strings to date objects
        start_date = datetime.strptime(start_str, "%d%m%Y").date()
        end_date = datetime.strptime(end_str, "%d%m%Y").date()

        # error check
        if end_date < start_date:
            messagebox.showerror("Error", "End date cannot be earlier than start date.")
            return

        
        start_of_year = datetime(start_date.year, 1, 1).date()
        end_of_year = datetime(start_date.year, 12, 31).date()

        #calculations
        days_passed = (start_date - start_of_year).days + 1
        weeks_passed = days_passed // 7
        days_left_start = (end_of_year - start_date).days
        days_left_end = (end_of_year - end_date).days

        #result text
        result_text = (
            f"Start date of vacation: {start_date.strftime('%d.%m.%Y')}\n"
            f"End date of vacation: {end_date.strftime('%d.%m.%Y')}\n\n"
            f"Weeks passed since the beginning of the year: {weeks_passed}\n"
            f"Days left until the end of the year (from start): {days_left_start}\n"
            f"Days left until the end of the year (from end): {days_left_end}"
        )

        label_result.config(text=result_text, fg="black")

    except ValueError:
        messagebox.showerror("Error", "Invalid date format! Please use DDMMYYYY format.")

# --- Main window ---
root = tk.Tk()
root.title("Parliament Vacation Tracker")
root.geometry("420x350")
root.resizable(False, False)
root.configure(bg="#f2f2f2")

# --- Title ---
title = tk.Label(root, text="Parliament Vacation Tracker", font=("Arial", 16, "bold"), bg="#f2f2f2")
title.pack(pady=10)

# --- Input fields ---
frame_inputs = tk.Frame(root, bg="#f2f2f2")
frame_inputs.pack(pady=5)

label_start = tk.Label(frame_inputs, text="Start date (DDMMYYYY):", bg="#f2f2f2", font=("Arial", 11))
label_start.grid(row=0, column=0, padx=5, pady=5, sticky="e")

entry_start = tk.Entry(frame_inputs, width=15, font=("Arial", 12))
entry_start.grid(row=0, column=1, padx=5, pady=5)

label_end = tk.Label(frame_inputs, text="End date (DDMMYYYY):", bg="#f2f2f2", font=("Arial", 11))
label_end.grid(row=1, column=0, padx=5, pady=5, sticky="e")

entry_end = tk.Entry(frame_inputs, width=15, font=("Arial", 12))
entry_end.grid(row=1, column=1, padx=5, pady=5)

# --- Button ---
btn_calc = tk.Button(root, text="Calculate", font=("Arial", 12, "bold"), bg="#4caf50", fg="white", width=15, command=calculate)
btn_calc.pack(pady=10)

# --- Result label ---
label_result = tk.Label(root, text="", font=("Arial", 12), bg="#f2f2f2", justify="left")
label_result.pack(pady=10)

# --- Run app ---
root.mainloop()

