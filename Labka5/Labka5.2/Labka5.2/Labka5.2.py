import tkinter as tk
from tkinter import ttk, messagebox


# === base ===
class Ship:
    def __init__(self, name="Невідомий", country="Невідомо", year=0):
        self.name = name
        self.country = country
        self.year = year

    def __del__(self):
        print("Лабораторна робота виконана студентом 2 курсу ПІБ студента")

    def describe(self):
        return "Це загальний корабель."

    def show(self):
        return f"Назва: {self.name}\nКраїна: {self.country}\nРік побудови: {self.year}"


# === other ===
class Steamship(Ship):
    def __init__(self, name="Невідомий", country="Невідомо", year=0, engine_power=0, fuel="дизель"):
        super().__init__(name, country, year)
        self.engine_power = engine_power
        self.fuel = fuel

    def describe(self):
        return "Це пароплав із двигуном внутрішнього згоряння."

    def show(self):
        base = super().show()
        return f"{base}\nПотужність двигуна: {self.engine_power} к.с.\nТип пального: {self.fuel}"


class Sailboat(Ship):
    def __init__(self, name="Невідомий", country="Невідомо", year=0, mast_count=1, sail_area=0):
        super().__init__(name, country, year)
        self.mast_count = mast_count
        self.sail_area = sail_area

    def describe(self):
        return "Це вітрильник, що рухається завдяки вітру."

    def show(self):
        base = super().show()
        return f"{base}\nКількість щогл: {self.mast_count}\nПлоща вітрил: {self.sail_area} м²"


class Corvette(Ship):
    def __init__(self, name="Невідомий", country="Невідомо", year=0, weapon_count=0, crew=0):
        super().__init__(name, country, year)
        self.weapon_count = weapon_count
        self.crew = crew

    def describe(self):
        return "Це військовий корвет, озброєний для бойових завдань."

    def show(self):
        base = super().show()
        return f"{base}\nКількість гармат: {self.weapon_count}\nЕкіпаж: {self.crew} осіб"


# === Go ===
class ShipApp:
    def __init__(self, root):
        self.root = root
        self.root.title("Кораблікі")
        self.root.geometry("500x500")

        # Тип корабля
        ttk.Label(root, text="Оберіть тип корабля:").pack(pady=5)
        self.type_var = tk.StringVar(value="Ship")
        ttk.Combobox(root, textvariable=self.type_var, values=["Ship", "Steamship", "Sailboat", "Corvette"]).pack()

        # Основні поля
        self.entries = {}
        fields = ["Назва", "Країна", "Рік побудови"]
        for f in fields:
            ttk.Label(root, text=f).pack()
            e = ttk.Entry(root)
            e.pack()
            self.entries[f] = e

        # Додаткові поля
        ttk.Label(root, text="Додаткові параметри (через кому):").pack(pady=5)
        self.extra_entry = ttk.Entry(root)
        self.extra_entry.pack()

        # Кнопки
        ttk.Button(root, text="Показати інформацію", command=self.show_info).pack(pady=10)
        ttk.Button(root, text="Вийти", command=root.destroy).pack()

        # Виведення результату
        self.output = tk.Text(root, height=12, width=50)
        self.output.pack(pady=10)

    def show_info(self):
        name = self.entries["Назва"].get()
        country = self.entries["Країна"].get()
        year = int(self.entries["Рік побудови"].get() or 0)
        ship_type = self.type_var.get()

        extras = self.extra_entry.get().split(",")

        try:
            if ship_type == "Steamship":
                obj = Steamship(name, country, year,
                                int(extras[0]), extras[1] if len(extras) > 1 else "дизель")
            elif ship_type == "Sailboat":
                obj = Sailboat(name, country, year,
                               int(extras[0]), float(extras[1]) if len(extras) > 1 else 0)
            elif ship_type == "Corvette":
                obj = Corvette(name, country, year,
                               int(extras[0]), int(extras[1]) if len(extras) > 1 else 0)
            else:
                obj = Ship(name, country, year)

            info = obj.show() + "\n\n" + obj.describe()
            self.output.delete("1.0", tk.END)
            self.output.insert(tk.END, info)
        except Exception as e:
            messagebox.showerror("Помилка", f"Невірні дані: {e}")


# === Запуск ===
if __name__ == "__main__":
    root = tk.Tk()
    app = ShipApp(root)
    root.mainloop()

