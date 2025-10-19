import tkinter as tk
from tkinter import scrolledtext


file1 = open("TF_1.txt", "w", encoding="utf-8")
file1.write("A simple   example   of a file\n")
file1.write("I  like  Python \n")
file1.write("T  is  a   test  line\n")
file1.close()



def show_tf1():
    text_box.delete(1.0, tk.END)
    file1 = open("TF_1.txt", "r", encoding="utf-8")
    content = file1.read()
    file1.close()
    text_box.insert(tk.END, content)


def process_text():

    file1 = open("TF_1.txt", "r", encoding="utf-8")
    lines = file1.readlines()
    file1.close()


    file2 = open("TF_2.txt", "w", encoding="utf-8")
    for line in lines:
        words = line.split()
      
        filtered = [word for word in words if len(word) == 1]
        new_line = " ".join(filtered)
        file2.write(new_line + "\n")
    file2.close()


    text_box.delete(1.0, tk.END)
    text_box.insert(tk.END, "Text processed and saved to TF_2.txt!")


def show_tf2():
    text_box.delete(1.0, tk.END)
    file2 = open("TF_2.txt", "r", encoding="utf-8")
    content = file2.read()
    file2.close()
    text_box.insert(tk.END, content)



window = tk.Tk()
window.title("Text File Processor")
window.geometry("500x400")


text_box = scrolledtext.ScrolledText(window, width=60, height=15)
text_box.pack(pady=10)


btn_show1 = tk.Button(window, text="Show TF_1", command=show_tf1, width=20)
btn_process = tk.Button(window, text="Process Text → TF_2", command=process_text, width=20)
btn_show2 = tk.Button(window, text="Show TF_2", command=show_tf2, width=20)

btn_show1.pack(pady=5)
btn_process.pack(pady=5)
btn_show2.pack(pady=5)

window.mainloop()
