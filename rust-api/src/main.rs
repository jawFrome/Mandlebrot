mod mandlebrot;
use num_complex::Complex64;

fn main() {
    println!("{}", mandlebrot::is_in_range(Complex64{re: 0.5, im:0.1}));
    println!("{}", mandlebrot::is_in_range(Complex64{re: 3.0, im:0.1}));

    mandlebrot::get_image_of_range(Complex64{re:-2.0, im:2.0}, Complex64{re:2.0, im:-2.0});
}
