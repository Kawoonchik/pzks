from abc import ABC, abstractmethod
import tkinter as tk
from tkinter import ttk, messagebox



class AirTransport(ABC):
    def __init__(self, model, max_speed, max_altitude):
        self.model = model
        self.max_speed = max_speed
        self.max_altitude = max_altitude

    def display_info(self):
        """Return transport description"""
        return f"Model: {self.model}, Speed: {self.max_speed} km/h, Altitude: {self.max_altitude} m"

    @abstractmethod
    def move(self):
        pass

    @abstractmethod
    def type_name(self):
        pass

    def can_fly_above(self, altitude):
        return self.max_altitude > altitude

    def can_fly_below(self, altitude):
        return self.max_altitude <= altitude



class Helicopter(AirTransport):
    def __init__(self, model, max_speed, max_altitude, rotor_count):
        super().__init__(model, max_speed, max_altitude)
        self.rotor_count = rotor_count

    def move(self):
        return "Rises vertically and flies using rotors."

    def type_name(self):
        return "Helicopter"

    def hover(self):
        return f"{self.model} can hover in one place."



class Airplane(AirTransport):
    def __init__(self, model, max_speed, max_altitude, wingspan):
        super().__init__(model, max_speed, max_altitude)
        self.wingspan = wingspan

    def move(self):
        return "Moves using engine thrust and wing lift."

    def type_name(self):
        return "Airplane"

    def takeoff_distance(self):
        return f"{self.model} requires {self.wingspan * 30} m runway."



transport_list = [
    Helicopter("Mi-8", 250, 6000, 1),
    Helicopter("Apache", 300, 6400, 2),
    Airplane("Boeing 737", 850, 12500, 35),
    Airplane("Velosyped Ukraina", 230, 4100, 11),
]



class AirTransportApp:
    def __init__(self, root):
        self.root = root
        self.root.title("Air Transport Database")
        self.root.geometry("700x400")

        
        self.tree = ttk.Treeview(root, columns=("Type", "Model", "Speed", "Altitude"), show="headings")
        self.tree.heading("Type", text="Type")
        self.tree.heading("Model", text="Model")
        self.tree.heading("Speed", text="Speed (km/h)")
        self.tree.heading("Altitude", text="Max Altitude (m)")
        self.tree.pack(fill=tk.BOTH, expand=True, pady=10)

       
        search_frame = tk.Frame(root)
        search_frame.pack(pady=5)

        tk.Label(search_frame, text="Search by altitude:").grid(row=0, column=0, padx=5)

        self.condition = ttk.Combobox(search_frame, values=["above", "below"], width=10, state="readonly")
        self.condition.current(0)  
        self.condition.grid(row=0, column=1, padx=5)

        # Entry for altitude input
        self.altitude_entry = tk.Entry(search_frame, width=10)
        self.altitude_entry.grid(row=0, column=2, padx=5)

        # Buttons
        tk.Button(search_frame, text="Search", command=self.search).grid(row=0, column=3, padx=5)
        tk.Button(search_frame, text="Show all", command=self.show_all).grid(row=0, column=4, padx=5)

        # Initial table data
        self.show_all()

    def show_all(self):
        """Show all transports"""
        self.tree.delete(*self.tree.get_children())
        for t in transport_list:
            self.tree.insert("", tk.END, values=(t.type_name(), t.model, t.max_speed, t.max_altitude))

    def search(self):
        """Search by altitude condition"""
        try:
            altitude = float(self.altitude_entry.get())
        except ValueError:
            messagebox.showerror("Error", "Please enter a valid numeric altitude!")
            return

        condition = self.condition.get()
        found = []

        # Select filter type
        if condition == "above":
            found = [t for t in transport_list if t.can_fly_above(altitude)]
        elif condition == "below":
            found = [t for t in transport_list if t.can_fly_below(altitude)]

        # Update table
        self.tree.delete(*self.tree.get_children())

        if not found:
            messagebox.showinfo("Result", "No transports match this altitude condition.")
        else:
            for t in found:
                self.tree.insert("", tk.END, values=(t.type_name(), t.model, t.max_speed, t.max_altitude))



if __name__ == "__main__":
    root = tk.Tk()
    app = AirTransportApp(root)
    root.mainloop()
