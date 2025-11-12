from collections import deque

# ====== Клас вузла дерева ======
class Node:
    def __init__(self, value):
        self.value = value          # Значення (назва предмета)
        self.left = None            # Посилання на лівого нащадка
        self.right = None           # Посилання на правого нащадка

# ====== Клас бінарного дерева ======
class BinaryTree:
    def __init__(self):
        self.root = None  # Корінь дерева (початково порожній)

    # --- Додавання елемента у дерево через чергу ---
    def insert(self, value):
        new_node = Node(value)

        # Якщо дерево порожнє, створюємо корінь
        if self.root is None:
            self.root = new_node
            return

        # Використовуємо чергу для обходу рівнів
        queue = deque([self.root])

        while queue:
            current = queue.popleft()

            # Якщо ліва гілка пуста — додаємо туди новий вузол
            if current.left is None:
                current.left = new_node
                return
            else:
                queue.append(current.left)

            # Якщо права гілка пуста — додаємо туди
            if current.right is None:
                current.right = new_node
                return
            else:
                queue.append(current.right)

    # --- Обхід дерева (inorder traversal: left -> root -> right) ---
    def inorder(self, node):
        if node is None:
            return []
        return self.inorder(node.left) + [node.value] + self.inorder(node.right)

    # --- Пошук вузла за назвою ---
    def search(self, value):
        if self.root is None:
            return False

        queue = deque([self.root])
        while queue:
            current = queue.popleft()
            if current.value == value:
                return True
            if current.left:
                queue.append(current.left)
            if current.right:
                queue.append(current.right)
        return False

    # --- Видалення вузла за значенням ---
    def delete(self, value):
        if self.root is None:
            return

        queue = deque([self.root])
        node_to_delete = None
        last_node = None
        parent_of_last = None

        while queue:
            last_node = queue.popleft()
            if last_node.value == value:
                node_to_delete = last_node
            if last_node.left:
                parent_of_last = last_node
                queue.append(last_node.left)
            if last_node.right:
                parent_of_last = last_node
                queue.append(last_node.right)

        if node_to_delete:
            node_to_delete.value = last_node.value  # замінюємо значення
            if parent_of_last.right == last_node:
                parent_of_last.right = None
            else:
                parent_of_last.left = None

# ====== Тестування дерева ======

tree = BinaryTree()

subjects = [
    "мінімізація",
    "пкпз",
    "пппі",
    "англійська мова",
    "веб технології",
    "операційні системи"
]

# Додаємо предмети у дерево
for s in subjects:
    tree.insert(s)

print("Обхід дерева:", tree.inorder(tree.root))
print("Пошук 'пппі':", tree.search("пппі"))
print("Пошук 'фізика':", tree.search("фізика"))

tree.delete("пппі")
print("Після видалення 'пппі':", tree.inorder(tree.root))

