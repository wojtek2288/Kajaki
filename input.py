import networkx as nx
import sys

usage = "main.py [opcjonalne: nazwa pliku]"

def GetInputGraph():
    if len(sys.argv) > 2:
        print('too many arguments, arguments: ' + usage)
        sys.exit(1)

    if sys.argv is None or len(sys.argv) == 1:
        n, l, edges = LoadFromKeyboard()
    else:
        n, l, edges = LoadGraphFromFile(sys.argv[1])

    G = nx.Graph()
    for i in range(1, n + 1):
        G.add_node(i)
    
    for u, v in edges:
        G.add_edge(u, v)
    
    return G

def LoadGraphFromFile(arg):
    with open('input.txt', 'r') as f:
        n, l = map(int, f.readline().split())
        edges = [tuple(map(int, line.split())) for line in f]
    
    return n, l, edges


def LoadFromKeyboard():
    n, l = map(int, input().split())
    edges = [tuple(map(int, input().split())) for i in range(0, l)]

    return n, l, edges