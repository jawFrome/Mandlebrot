#[derive(Debug, Deserialize, Serialize)]
pub struct Complex {
    pub real: f32,
    pub imag: f32,
}

impl Complex {
    pub fn new(f32:real, f32:imag) -> self{
        self{
            real,
            imag,
        }
    }
}

pub fn is_in_the_set(complex: value) -> boolean {
    if (value.real.abs() > 2 || value.imag.abs() > 2){
                return false;            
    }

    return !(Process(value) < UpperIterationLimit);
}

pub fn get_image_of_range(complex: upperLeft, complex: lowerRight) -> () {
    let UpperIterationLimit = 255;
    let UpperSquaredLimit: i32 = 4;
    let Height = 800;
    let Width = 800;

    let x_resolution = (lowerRight.real - upperLeft.real) / Width;
    let y_resolution = (upperLeft.imag - lowerRight.imag) / Height;
    let depthValues : &[[u32; Height]; Width];
    let mut x = 0;
    let mut real = upperLeft.real;
    while  real < lowerRight.real {
        let mut y = 0;
        let mut imag = lowerRight.imag;
        while imag < upperLeft.imag{
            depthValues[x][y] = Process(complex(real, imag));
            y = y + 1;
            if y >= Height{
                break;
            }
        
        x = x + 1;
        if x >= Width{
            break;
        }  

        imag = imag + y_resolution
    }

    real = real + x_resolution;
}

    return createImageFromArrayAsRawBytes(depthValues);       
}

pub fn Process(complex: value) -> int {
    c = complex(real, imag);
    depth = 0;
    Zn = complex(0, 0);
    while (IsInRange(Zn) && depth < UpperIterationLimit){
        Zn = Zn * Zn + c;
        depth = depth + 1;
    }
    
    return depth;
}


pub fn IsInRange(complex: value) -> boolean {
    polarForm = cmath.polar(value);
    return (pow(polarForm[0], 2) <= UpperSquaredLimit);
}