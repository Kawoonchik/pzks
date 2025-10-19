# -*- coding: utf-8 -*-
import tkinter as tk
from tkinter import messagebox


# base
class CameraBase:
    def __init__(self, model, zoom, body_material):
        self.model = model
        self.zoom = zoom
        self.body_material = body_material

    def cost(self):
        """Calculate cost based on material and zoom"""
        if self.body_material.lower() == "plastic":
            return (self.zoom + 2) * 10
        elif self.body_material.lower() == "metal":
            return (self.zoom + 2) * 15
        else:
            return 0

    def is_expensive(self):
        """Return True if cost > 200"""
        return self.cost() > 200

    def info(self):
        """Return info about the camera"""
        return (f"Model: {self.model}\n"
                f"Zoom: {self.zoom}\n"
                f"Material: {self.body_material}\n"
                f"Cost: ${self.cost():.2f}\n"
                f"Expensive: {'Yes' if self.is_expensive() else 'No'}")


# derived
class DigitalCamera(CameraBase):
    def __init__(self, model, zoom, body_material, megapixels):
        super().__init__(model, zoom, body_material)
        self.megapixels = megapixels

    def cost(self):
        """Cost = base cost * megapixels"""
        return super().cost() * self.megapixels

    def update_model(self):
        """Increase megapixels by 2"""
        self.megapixels += 2

    def info(self):
        base_info = super().info()
        return f"{base_info}\nMegapixels: {self.megapixels}"


# derived2
class ProfessionalCamera(DigitalCamera):
    def __init__(self, model, zoom, body_material, megapixels, camera_type):
        super().__init__(model, zoom, body_material, megapixels)
        self.camera_type = camera_type

    def cost(self):
        """Cost = base cost * megapixels * 10"""
        return super(CameraBase, self).cost() * self.megapixels * 10

    def update_model(self):
        """Increase megapixels by 20"""
        self.megapixels += 20

    def info(self):
        base_info = super().info()
        return f"{base_info}\nCamera type: {self.camera_type}"


#gui
class CameraApp:
    def __init__(self, root):
        self.root = root
        self.root.title("Camera Information System")

        
        tk.Label(root, text="Select Camera Type:").grid(row=0, column=0, sticky="e")
        self.camera_type_var = tk.StringVar(value="CameraBase")
        tk.OptionMenu(root, self.camera_type_var, "CameraBase", "DigitalCamera", "ProfessionalCamera").grid(row=0, column=1)

        # Input 
        labels = ["Model:", "Zoom (1~35):", "Body Material (metal/plastic):",
                  "Megapixels (for Digital/Professional):", "Camera Type (for Professional):"]
        self.entries = []

        for i, label in enumerate(labels):
            tk.Label(root, text=label).grid(row=i + 1, column=0, sticky="e")
            entry = tk.Entry(root)
            entry.grid(row=i + 1, column=1)
            self.entries.append(entry)

        # Buttons
        tk.Button(root, text="Show Info", command=self.show_info).grid(row=7, column=0)
        tk.Button(root, text="Update Model", command=self.update_model).grid(row=7, column=1)
        tk.Button(root, text="Exit", command=root.quit).grid(row=8, column=0, columnspan=2)

        # Output 
        self.output_box = tk.Text(root, width=50, height=12)
        self.output_box.grid(row=9, column=0, columnspan=2)

    
        self.objects = {}

    def create_object(self):
        """Create object depending on selected camera type"""
        try:
            model = self.entries[0].get()
            zoom = float(self.entries[1].get())
            material = self.entries[2].get()

            if self.camera_type_var.get() == "CameraBase":
                obj = CameraBase(model, zoom, material)
            elif self.camera_type_var.get() == "DigitalCamera":
                megapixels = int(self.entries[3].get() or 0)
                obj = DigitalCamera(model, zoom, material, megapixels)
            else:
                megapixels = int(self.entries[3].get() or 0)
                cam_type = self.entries[4].get()
                obj = ProfessionalCamera(model, zoom, material, megapixels, cam_type)

            self.objects[self.camera_type_var.get()] = obj
            return obj

        except ValueError:
            messagebox.showerror("Error", "Invalid input! Please check all fields.")
            return None

    def show_info(self):
        """Display camera info"""
        obj = self.create_object()
        if obj:
            info = obj.info()
            self.output_box.delete(1.0, tk.END)
            self.output_box.insert(tk.END, info)

    def update_model(self):
        """Update model megapixels"""
        cam_type = self.camera_type_var.get()
        if cam_type not in self.objects:
            messagebox.showwarning("Warning", "Create the object first!")
            return

        obj = self.objects[cam_type]
        if hasattr(obj, "update_model"):
            obj.update_model()
            self.output_box.delete(1.0, tk.END)
            self.output_box.insert(tk.END, f"Model updated!\n\n{obj.info()}")
        else:
            messagebox.showinfo("Info", "This camera type has no update method.")


# run
if __name__ == "__main__":
    root = tk.Tk()
    app = CameraApp(root)
    root.mainloop()

