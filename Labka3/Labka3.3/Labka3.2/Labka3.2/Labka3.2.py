import tkinter as tk
from tkinter import simpledialog, messagebox
import re

# Sample text with phone numbers
text = """
Oleksiy: +38012345-67-89
Maria: +38098765-43-21
Petro: +38011122-33-44
Inna: +38022233-44-55
"""

pattern = r"\+380\d{5}-\d{2}-\d{2}"

def get_numbers():
    return re.findall(pattern, text)


def refresh_textbox():
    textbox.config(state='normal')
    textbox.delete('1.0', tk.END)
    numbers = get_numbers()
    for i, num in enumerate(numbers, start=1):
        textbox.insert(tk.END, f"{i}. {num}\n")
    textbox.config(state='disabled')


def delete_number():
    global text
    numbers = get_numbers()
    if not numbers:
        messagebox.showinfo("Delete", "No numbers to delete.")
        return
    idx = simpledialog.askinteger("Delete", f"Enter number index (1-{len(numbers)}):")
    if idx and 1 <= idx <= len(numbers):
        text = text.replace(numbers[idx-1], "")
        refresh_textbox()
        messagebox.showinfo("Delete", "Number deleted.")
    else:
        messagebox.showwarning("Delete", "Invalid index.")

def replace_number():
    global text
    numbers = get_numbers()
    if not numbers:
        messagebox.showinfo("Replace", "No numbers to replace.")
        return
    idx = simpledialog.askinteger("Replace", f"Enter number index (1-{len(numbers)}):")
    if idx and 1 <= idx <= len(numbers):
        new_number = simpledialog.askstring("Replace", "Enter new number:")
        if new_number:
            text = text.replace(numbers[idx-1], new_number)
            refresh_textbox()
            messagebox.showinfo("Replace", "Number replaced.")
    else:
        messagebox.showwarning("Replace", "Invalid index.")


root = tk.Tk()
root.title("Phone Book")
root.geometry("350x300")

textbox = tk.Text(root, width=40, height=10, state='disabled')
textbox.pack(pady=10)

tk.Button(root, text="Delete Number", width=20, command=delete_number).pack(pady=5)
tk.Button(root, text="Replace Number", width=20, command=replace_number).pack(pady=5)
tk.Button(root, text="Exit", width=20, command=root.destroy).pack(pady=10)

refresh_textbox()
root.mainloop()
