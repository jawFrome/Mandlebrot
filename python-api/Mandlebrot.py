import cmath
import numpy as np
from ImageBuilder import createImageFromArrayAsRawBytes

UpperIterationLimit = 255
UpperSquaredLimit = 4
Height = 800
Width = 800

def IsInTheSet(real, imag):
    c = complex(real, imag)
    if (abs(c.real) > 2 or abs(c.imag) > 2):
                return False            

    return not(Process(c.real, c.imag) < UpperIterationLimit)

def getImageOfRange(upperLeft, lowerRight): 
    upperLeft = complex(upperLeft[0], upperLeft[1])       
    lowerRight = complex(lowerRight[0], lowerRight[1]) 
    x_resolution = (lowerRight.real - upperLeft.real) / Width
    y_resolution = (upperLeft.imag - lowerRight.imag) / Height
    depthValues = np.empty(Width * Height, dtype=int).reshape(Width,Height)
    x = 0
    for real in np.arange(upperLeft.real, lowerRight.real, x_resolution):
        y = 0
        for imag in np.arange(upperLeft.imag, lowerRight.imag, -y_resolution):        
            depthValues[x,y] = Process(real, imag)
            y = y + 1
        
        x = x + 1           

    return createImageFromArrayAsRawBytes(depthValues);       
        

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
        