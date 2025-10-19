import tkinter as tk
from tkinter import messagebox
import logging
import os

# ==========================================

logging.basicConfig(filename="session_log.txt", level=logging.INFO, filemode='w')

def log_action(action):

    logging.info(action)

# ==========================================
def import_data():
   
    try:
        if not os.path.exists("input.txt"):
         with open("input.txt", "w") as f:
            f.write("1 1")  
         messagebox.showinfo("Info", "File input.txt created with default data.")
         return
        
        with open("input.txt", "r") as file:
            data = file.read().strip()
        
        if not data:
            messagebox.showerror("Error", "File is empty. Please enter data.")
            log_action("Action: empty input file")
            return
        
        parts = data.split()
        if len(parts) != 2:
            messagebox.showerror("Error", "Invalid data format in input file.")
            log_action("Action: invalid input format")
            return
        
        entry_num1.delete(0, tk.END)
        entry_num1.insert(0, parts[0])
        entry_num2.delete(0, tk.END)
        entry_num2.insert(0, parts[1])
        
        messagebox.showinfo("Info", "Data imported successfully.")
        log_action("Action: imported input data")
    
    except Exception as e:
        messagebox.showerror("Error", str(e))
        log_action(f"Action: error during import ({e})")

def export_result():
    """Export result to output file"""
    try:
        num1 = entry_num1.get().strip()
        num2 = entry_num2.get().strip()
        result = entry_result.get().strip()
        operation = operation_var.get()
        
        if not num1 or not num2 or not result:
            messagebox.showerror("Error", "Missing values for export.")
            log_action("Action: export failed due to missing values")
            return
        
        symbol = {
            "add": "+",
            "sub": "-",
            "mul": "*",
            "div": "/",
            "pow": "^"
        }.get(operation, "?")
        
        with open("output.txt", "w") as file:
            file.write(f"{num1} {symbol} {num2}, Result: {result}")
        
        messagebox.showinfo("Info", "Result exported successfully.")
        log_action("Action: exported result to output.txt")
    
    except Exception as e:
        messagebox.showerror("Error", str(e))
        log_action(f"Action: error during export ({e})")

# ==========================================
def calculate():
    """Perform the selected arithmetic operation"""
    try:
        num1 = entry_num1.get().strip()
        num2 = entry_num2.get().strip()
        
        if not num1 or not num2:
            messagebox.showerror("Error", "Please enter both numbers.")
            log_action("Action: missing input numbers")
            return
        
        num1 = float(num1)
        num2 = float(num2)
        operation = operation_var.get()
        
        if operation == "add":
            result = num1 + num2
        elif operation == "sub":
            result = num1 - num2
        elif operation == "mul":
            result = num1 * num2
        elif operation == "div":
            if num2 == 0:
                messagebox.showerror("Error", "Division by zero is forbidden.")
                log_action("Action: division by zero")
                return
            result = num1 / num2
        elif operation == "pow":
            result = num1 ** num2
        else:
            messagebox.showerror("Error", "Please select an operation.")
            log_action("Action: no operation selected")
            return
        
        entry_result.delete(0, tk.END)
        entry_result.insert(0, str(result))
        log_action(f"Action: performed {operation} → result {result}")
    
    except ValueError:
        messagebox.showerror("Error", "Invalid input values.")
        log_action("Action: invalid input values")
    except Exception as e:
        messagebox.showerror("Error", str(e))
        log_action(f"Action: error during calculation ({e})")
    finally:
        log_action("Action: calculation attempt finished")

# ==========================================
root = tk.Tk()
root.title("Arithmetic Calculator")
root.geometry("500x300")
root.resizable(False, False)

log_action("Action 1: application started")


tk.Label(root, text="Number 1:").pack()
entry_num1 = tk.Entry(root)
entry_num1.pack()

tk.Label(root, text="Number 2:").pack()
entry_num2 = tk.Entry(root)
entry_num2.pack()

tk.Label(root, text="Result:").pack()
entry_result = tk.Entry(root)
entry_result.pack()


operation_var = tk.StringVar(value="add")

operations_frame = tk.Frame(root)
operations_frame.pack(pady=10)

tk.Radiobutton(operations_frame, text="Addition (+)", variable=operation_var, value="add").grid(row=0, column=0)
tk.Radiobutton(operations_frame, text="Subtraction (-)", variable=operation_var, value="sub").grid(row=0, column=1)
tk.Radiobutton(operations_frame, text="Multiplication (*)", variable=operation_var, value="mul").grid(row=0, column=2)
tk.Radiobutton(operations_frame, text="Division (/)", variable=operation_var, value="div").grid(row=1, column=0)
tk.Radiobutton(operations_frame, text="Power (^)", variable=operation_var, value="pow").grid(row=1, column=1)


buttons_frame = tk.Frame(root)
buttons_frame.pack(pady=10)

tk.Button(buttons_frame, text="Import Data", command=import_data).grid(row=0, column=0, padx=5)
tk.Button(buttons_frame, text="Calculate", command=calculate).grid(row=0, column=1, padx=5)
tk.Button(buttons_frame, text="Export Result", command=export_result).grid(row=0, column=2, padx=5)

def on_close():
    log_action("Action: application closed")
    root.destroy()

root.protocol("WM_DELETE_WINDOW", on_close)
root.mainloop()
