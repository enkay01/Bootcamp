from enum import Enum
class op(Enum):
    ADD = 1
    SUB = 2
    MUL = 3
    DIV = 4
    
def calculator():
    operator = get_operator()
    numbers = get_numbers()
    print(do_sum(op=operator, nums=numbers))
    return

def get_operator():
    while True:
        operator = input("Enter an operation")
        if operator == '+':
            return op.ADD
        elif operator == '-':
            return op.SUB
        elif operator == 'x':
            return op.MUL
        elif operator == '/':
            return op.DIV
def get_numbers():
    n1 = input("Enter first number: ")
    n2 = input("Enter second number: ")
    return [n1,n2]

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

calculator()