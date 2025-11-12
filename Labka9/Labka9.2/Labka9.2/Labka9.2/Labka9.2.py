import tkinter as tk
from tkinter import filedialog, messagebox
from itertools import cycle

# Helper function to read list from file

def read_list_from_file(filepath):
    try:
        with open(filepath, 'r', encoding='utf-8') as f:
            items = [line.strip() for line in f if line.strip()]
        return items
    except:
        messagebox.showerror("Error", f"Cannot read file:\n{filepath}")
        return None



# Main Application (GUI)

class App:
    def __init__(self, root):
        self.root = root
        self.root.title("Medical Examination Scheduling")

        self.doctors = []
        self.patients = []
        self.assignments = {}  # doctor > list of assigned patients

        # GUI Layout

        # Buttons
        self.btn_load_doctors = tk.Button(root, text="Load Doctors List", command=self.load_doctors)
        self.btn_load_doctors.pack(pady=5)

        self.btn_load_patients = tk.Button(root, text="Load Patients List", command=self.load_patients)
        self.btn_load_patients.pack(pady=5)

        # Display lists
        tk.Label(root, text="Doctors:").pack()
        self.txt_doctors = tk.Text(root, width=50, height=6)
        self.txt_doctors.pack(pady=3)

        tk.Label(root, text="Patients:").pack()
        self.txt_patients = tk.Text(root, width=50, height=6)
        self.txt_patients.pack(pady=3)

        # Assign limit input
        tk.Label(root, text="How many patients can 1 doctor examine per day?").pack(pady=5)
        self.entry_limit = tk.Entry(root, width=10)
        self.entry_limit.pack()

        self.btn_assign = tk.Button(root, text="Assign Patients to Doctors", command=self.assign_patients)
        self.btn_assign.pack(pady=10)

        # Doctor search
        tk.Label(root, text="Enter doctor surname to see patients examined:").pack(pady=5)
        self.entry_doctor_query = tk.Entry(root, width=30)
        self.entry_doctor_query.pack()

        self.btn_search = tk.Button(root, text="Show Patients", command=self.search_doctor)
        self.btn_search.pack(pady=10)

        # Output box
        tk.Label(root, text="Search Result:").pack()
        self.txt_output = tk.Text(root, width=50, height=8)
        self.txt_output.pack(pady=5)

        # Save button
        self.btn_save = tk.Button(root, text="Save Assignment to File", command=self.save_result)
        self.btn_save.pack(pady=10)




    # Load Doctors

    def load_doctors(self):
        file = filedialog.askopenfilename(title="Select Doctors File")
        if not file:
            return

        lst = read_list_from_file(file)
        if lst is None:
            return

        self.doctors = lst
        self.txt_doctors.delete("1.0", tk.END)
        self.txt_doctors.insert(tk.END, "\n".join(self.doctors))
        messagebox.showinfo("Loaded", "Doctors file loaded successfully!")



    # Load Patients

    def load_patients(self):
        file = filedialog.askopenfilename(title="Select Patients File")
        if not file:
            return

        lst = read_list_from_file(file)
        if lst is None:
            return

        self.patients = lst
        self.txt_patients.delete("1.0", tk.END)
        self.txt_patients.insert(tk.END, "\n".join(self.patients))
        messagebox.showinfo("Loaded", "Patients file loaded successfully!")



    # Core Logic: assign patients to doctors (cyclic lists)

    def assign_patients(self):
        if not self.doctors or not self.patients:
            messagebox.showwarning("Missing Data", "Please load both lists first.")
            return

        try:
            limit = int(self.entry_limit.get())
        except:
            messagebox.showerror("Error", "Limit must be a number.")
            return

        if limit <= 0:
            messagebox.showerror("Error", "Limit must be positive.")
            return

        # Reset assignments
        self.assignments = {doc: [] for doc in self.doctors}

        # Cyclic doctor iterator
        doctor_cycle = cycle(self.doctors)

        current_doctor = next(doctor_cycle)
        count_for_this_doctor = 0

        for patient in self.patients:
            if count_for_this_doctor == limit:
                current_doctor = next(doctor_cycle)
                count_for_this_doctor = 0

            self.assignments[current_doctor].append(patient)
            count_for_this_doctor += 1

        messagebox.showinfo("Done", "Patients assigned successfully!")



    # Search: show all patients examined by a doctor

    def search_doctor(self):
        doc = self.entry_doctor_query.get().strip()

        if doc not in self.assignments:
            self.txt_output.delete("1.0", tk.END)
            self.txt_output.insert(tk.END, "This doctor did not examine any patients or does not exist.")
            return

        result = self.assignments[doc]

        self.txt_output.delete("1.0", tk.END)
        if result:
            self.txt_output.insert(tk.END, f"Patients examined by {doc}:\n\n")
            self.txt_output.insert(tk.END, "\n".join(result))
        else:
            self.txt_output.insert(tk.END, f"{doc} did not examine any patients.")



    # Save assignments to file

    def save_result(self):
        if not self.assignments:
            messagebox.showwarning("Nothing to save", "No assignment results available.")
            return

        file = filedialog.asksaveasfilename(defaultextension=".txt", title="Save Results To File")
        if not file:
            return

        try:
            with open(file, "w", encoding="utf-8") as f:
                for doctor, assigned in self.assignments.items():
                    f.write(f"{doctor}:\n")
                    for p in assigned:
                        f.write(f"  - {p}\n")
                    f.write("\n")

            messagebox.showinfo("Saved", "Results saved successfully!")
        except:
            messagebox.showerror("Error", "Could not save file.")



root = tk.Tk()
app = App(root)
root.mainloop()

