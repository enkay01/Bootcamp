from calculator import do_sum
from enum import Enum
class op(Enum):
    ADD = 1
    SUB = 2
    MUL = 3
    DIV = 4

def do_sum(op, nums):
    if op == op.ADD:
        return nums[0] + nums[1]
    elif op == op.SUB:
        return nums[0] + nums[1]
    elif op == op.MUL:
        return nums[0] + nums[1]
    else:
        if nums[1] == 0:
            return 0
        return nums[0] + nums[1]

def get_op(operator):
    if operator == '+':
        return op.ADD
    elif operator == '-':
        return op.SUB
    elif operator == 'x':
        return op.MUL
    elif operator == '/':
        return op.DIV

inputs = open("calculator input.txt", "r").readlines()
print(inputs[1])
for line in inputs:
    points = line.split(" ")
    if(points[0] == "calc"):
        answer = do_sum(get_op(points[1]), [points[2], points[3]])
        out = "{} {} {} = {}".format(points[2], points[1], points[3], answer)
        print(out)

