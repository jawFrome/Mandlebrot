import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <h1>Mandlebrot home page</h1>
        <p>This is the home page for my Mandlebrot test which allows the viewing of the mandlebrot set from varius flavours of API, these are:</p>
        <ul>
          <li>.Net 6 API written in C#</li>
          <li>Go API</li>
          <li>Python based API using Flask</li>
        </ul>
        <p>these API are all hosted in the Free tier of AWS.</p>
        <p>So i remember, the <code>ClientApp</code> subdirectory is a standard React application based on the <code>create-react-app</code> template. If you open a command prompt in that directory, you can run <code>npm</code> commands such as <code>npm test</code> or <code>npm install</code>.</p>
      </div>
    );
  }
}
