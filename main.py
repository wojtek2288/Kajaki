import networkx as nx
import matplotlib.pyplot as plt

# Wczytanie danych wejściowych z pliku
with open('input.txt', 'r') as f:
    n, l = map(int, f.readline().split())
    edges = [tuple(map(int, line.split())) for line in f]

# Stworzenie grafu
G = nx.Graph()
for i in range(1, n+1):
    G.add_node(i)
for u, v in edges:
    G.add_edge(u, v)

# Wyświetlenie grafu
plt.figure('AZ')  
plt.title('Graf chęci płynięcia kajakami')
nx.draw(G, with_labels=True)
plt.show()

