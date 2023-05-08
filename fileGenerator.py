import sys
import random
from itertools import combinations

usage = "filename - name of generated file, n - count of people, pairs - count of pairs"

if len(sys.argv) < 3:
    print('too few arguments, arguments: ' + usage)
elif len(sys.argv) > 4:
    print('too many arguments, arguments: ' + usage)
else:

    filname = sys.argv[1]
    n = int(sys.argv[2])

    if len(sys.argv) == 4:
        countOfPairs = int(sys.argv[3])
    else:
        countOfPairs = random.randrange(1, int(n * (n-1) /2))

    pairs = random.sample(list(combinations(range(0, n), 2)), countOfPairs)

    with open(filname, 'w') as f:
        f.write(f'{n} {countOfPairs}')
        for pair in pairs:
            f.write(f'\n{pair[0]} {pair[1]}')