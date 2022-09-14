import cmath

UpperIterationLimit = 255
UpperSquaredLimit = 4

def IsInTheSet(real, imag):
    c = complex(real, imag)
    if (abs(c.real) > 2 or abs(c.imag) > 2):
                return False            

    return not(Process(c.real, c.imag) < UpperIterationLimit)
        

def Process(real, imag):
    c = complex(real, imag)
    depth = 0
    Zn = complex(0, 0)
    while (IsInRange(Zn) and depth < UpperIterationLimit):
        Zn = Zn * Zn + c
        depth = depth + 1
    
    return depth       


def IsInRange(value):
    polarForm = cmath.polar(value)
    return (pow(polarForm[0], 2) <= UpperSquaredLimit)
        