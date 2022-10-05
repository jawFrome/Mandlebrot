use num_complex::Complex64;

pub fn upper_iteration_limit() -> i32{
    255
}

pub fn upper_squared_limit() -> i32{
    4
}

pub fn is_in_the_set(value: Complex64) -> bool {
    if value.re.abs() > 2.0 || value.im.abs() > 2.0 {
                return false;            
    }

    return !(process(value) < upper_iteration_limit());
}

pub fn get_image_of_range(upper_left: Complex64, lower_right: Complex64) -> () {
    const HEIGHT: usize = 800;
    const WIDTH: usize = 800;

    let x_resolution = (lower_right.re - upper_left.re) / (WIDTH as f64);
    let y_resolution = (upper_left.im - lower_right.im) / (HEIGHT as f64);
    let mut depth_values = vec![vec![0; WIDTH]; HEIGHT];
    let mut x = 0;
    let mut real = upper_left.re;
    while  real < lower_right.re
    {
        let mut y = 0;
        let mut imag = lower_right.im;
        while imag < upper_left.im 
        {
            depth_values[x][y] = process(Complex64{re: real, im: imag});
            
            y = y + 1;
            if y >= HEIGHT{
                break;
            }

            imag = imag + y_resolution
        }

        x = x + 1;
        if x >= WIDTH{
            break;
        }  

        real = real + x_resolution;    
    }
    
}


pub fn process(value: Complex64) -> i32 {
    let mut depth = 0;
    let mut zn = Complex64{re:0f64, im:0f64};
    while is_in_range(zn) && depth < upper_iteration_limit() {
        zn = zn * zn + value;
        depth = depth + 1;
    }
    
    return depth;
}


pub fn is_in_range(value: Complex64) -> bool {
    let polar_form = value.to_polar();
    return polar_form.0.powf(2.0) <= upper_squared_limit() as f64;
}