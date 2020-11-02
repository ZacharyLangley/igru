import React, { Component } from 'react';
import { connect } from 'react-redux';
import { object, func } from 'prop-types';
import { Switch } from 'react-router-dom'
import { push } from 'connected-react-router'

import { loadUser } from 'domain/actions/authActions';
import Routes, { UnAuthRoutes, AuthRoutes } from './routes';
import './App.scss';
import AppTemplate from 'common/components/Templates/AppTemplate/AppTemplate';

class App extends Component {
  
  componentDidMount() {
    this.props.loadUser(push)
  }

  render() {
    const { user } = this.props;
    return (
      <div className={'App'}>
        <Switch>
          {
            user ? 
            (
              <div className={'App'}>
                <AppTemplate 
                  body={
                    <AuthRoutes user={user} />
                  }
                />
              </div>
            ) :
            <UnAuthRoutes user={user} />
          }
        </Switch>
      </div>
    )
  }
}

const mapStateToProps = (state) => ({
  user: state.auth.user
})

const mapDispatchToProps = {
  loadUser,
  push
}

App.propTypes = {
  user: object,
  getUserData: func
}

export default connect(mapStateToProps, mapDispatchToProps)(App);
