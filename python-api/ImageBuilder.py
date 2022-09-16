import numpy as np
from PIL import Image
import io

def createImageFromArrayAsRawBytes(array):
    width, height = np.shape(array)
    newImage = Image.new('RGB' ,[width, height])    
    pixel_map = newImage.load()  
     
    for i in range(width):
        for j in range(height):  
            pixel_map[i, j] = (0, 0, array[i,j])
  
    rawBytes = io.BytesIO()
    newImage.save(rawBytes, format="bmp")
    rawBytes.seek(0)
    return rawBytes