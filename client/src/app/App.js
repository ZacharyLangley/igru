import React, { Component } from 'react';
import Login from './screens/Login/Login';
import './App.scss';

class App extends Component {
  render() {
    return (
      <div className={'App'}>
        <Login />
      </div>
    )
  }
}

export default App;
