import networkx as nx
import matplotlib.pyplot as plt
import input

graph = input.GetInputGraph()

# Wyświetlenie grafu
plt.figure('AZ')  
plt.title('Graf chęci płynięcia kajakami')
nx.draw(graph, with_labels=True)
plt.show()

