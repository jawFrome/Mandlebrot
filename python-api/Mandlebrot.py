import cmath
import numpy as np
import math
from ImageBuilder import createImageFromArrayAsRawBytes

UpperIterationLimit = 255
UpperSquaredLimit = 4

def IsInTheSet(real, imag):
    c = complex(real, imag)
    if (abs(c.real) > 2 or abs(c.imag) > 2):
                return False            

    return not(Process(c.real, c.imag) < UpperIterationLimit)

def getImageOfRange(upperLeft, lowerRight, resolution = 0.01): 
    upperLeft = complex(upperLeft[0], upperLeft[1])       
    lowerRight = complex(lowerRight[0], lowerRight[1]) 
    width = math.trunc((lowerRight.real - upperLeft.real) / resolution)
    height = math.trunc((upperLeft.imag - lowerRight.imag) / resolution)
    depthValues = np.empty(width * height, dtype=int).reshape(width,height)
    x = 0
    for real in np.arange(upperLeft.real, lowerRight.real, resolution):
        y = 0
        for imag in np.arange(upperLeft.imag, lowerRight.imag, -resolution):        
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
        