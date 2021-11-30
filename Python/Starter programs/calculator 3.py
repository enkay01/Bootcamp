from enum import Enum
class op(Enum):
    ADD = 1
    SUB = 2
    MUL = 3
    DIV = 4
    POW = 5
    MOD = 6

def do_sum(op, nums):
    if op == op.ADD:
        return nums[0] + nums[1]
    elif op == op.SUB:
        return nums[0] + nums[1]
    elif op == op.MUL:
        return nums[0] + nums[1]
    elif op == op.DIV:
        if nums[1] == 0:
            return 0
        return nums[0] + nums[1]
    elif op == op.MOD:
        return nums[0] % nums[1]
    else:
        return nums[0] ^ nums[1]

def get_op(operator):
    if operator == '+':
        return op.ADD
    elif operator == '-':
        return op.SUB
    elif operator == 'x':
        return op.MUL
    elif operator == '/':
        return op.DIV
    elif operator == '**':
        return op.POW
    elif operator == '%':
        return op.MOD
        
def calc_answer(points):
    answer = do_sum((points[1]), [points[2], points[3]])
    out = "{} {} {} = {}".format(points[2], points[1], points[3], answer)
    print(out)
    return answer

def as_string(points):
    out = "{} {} {}".format(points[2], points[1], points[3])
    return out

inputs = open("calculator input 3.txt", "r")
sums = []
while True:
    line = inputs.readline().split(" ")
    if line[0] == "calc":
        sum = as_string(line)
        if as_string(line) in sums:
            break
        ans = calc_answer(line)
        sums.append({sum: ans})
    elif line[0] == "goto":
        line = inputs.seek(int(line[1]))
    
