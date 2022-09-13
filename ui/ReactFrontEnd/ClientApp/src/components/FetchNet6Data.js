import React, { Component } from 'react';
import NumericInput from 'react-numeric-input';

export class FetchNet6Data extends Component {
    static displayName = FetchNet6Data.name;

  constructor(props) {
    super(props);
    this.state = { image: null, loading: true };
    }   

  componentDidMount() {
    this.loadMandlebrotImage();
  }

  static renderimageTable(image) {
      return (
          <img id="MandlebrotImage" alt="GingerBreadMan"/> 
    );
  }

  render() {
    let contents = this.state.loading ? <p><em>Loading...</em></p> : FetchNet6Data.renderimageTable(this.state.image);
    //  let contents = FetchNet6Data.renderimageTable(this.state.image);

    return (
      <div>
        <h1 id="tabelLabel" >Mandlebrot</h1>
        <p>This component demonstrates fetching image data from the server.</p>
            <strong>Max Real: </strong><NumericInput step={0.01} min={-2} max={2} value={-2} snap />
            <strong>Min Real: </strong><NumericInput step={0.01} min={-2} max={2} value={2} snap />
            <strong>Max Imag: </strong><NumericInput step={0.01} min={-2} max={2} value={-2} snap />
            <strong>Min Imag: </strong><NumericInput step={0.01} min={-2} max={2} value={-2} snap />
        <p>{contents}</p>
      </div>
    );
  }

    loadMandlebrotImage() {
        fetch('https://localhost:7220/ImageOfRange?minReal=-2&minImag=-2&maxReal=2&maxImag=2', { mode: 'no-cors' })
            .then(response => {
                console.log('response', response);
                if (!response.ok) {
                    throw Error("Error fetching mandlebrot image");
                }
                return response.json();
            })
            .then(data => this.setState(({ image: "data:image/bmp;base64," + data })));
  }
}
