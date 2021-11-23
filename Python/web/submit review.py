import argparse

parser = argparse.ArgumentParser(description='Enter a film and star rating out of 5.')
parser.add_argument('string', type=str, nargs=1, help="The name of the film to add")
parser.add_argument('integer', type=int, nargs=1, help="film rating from 0 to 5")
args = parser.parse_args()
print(args.string)
with open("films generated.csv", "a") as f:
    f.write(f"{args.string},{args.integer}\n")