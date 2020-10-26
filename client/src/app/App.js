import React, { Component } from 'react';
import { connect } from 'react-redux';
import { object, func } from 'prop-types';
import { Switch } from 'react-router'

import { loadUser } from 'domain/actions/authActions';
import { Routes } from './routes';
import './App.scss';

class App extends Component {
  render() {
    const { user } = this.props;
    return (
      <div className={'App'}>
        <Switch>
          <Routes user={user} />
        </Switch>
      </div>
    )
  }
}

const mapStateToProps = (state) => ({
  user: state.auth.user
})

const mapDispatchToProps = {
  loadUser
}

App.propTypes = {
  user: object,
  getUserData: func
}

export default App;
