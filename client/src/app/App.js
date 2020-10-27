import React, { Component } from 'react';
import { connect } from 'react-redux';
import { object, func } from 'prop-types';
import { Switch } from 'react-router-dom'
import { push } from 'connected-react-router'

import { loadUser } from 'domain/actions/authActions';
import Routes from './routes';
import './App.scss';
import AppTemplate from 'common/components/Templates/AppTemplate/AppTemplate';

class App extends Component {
  
  componentDidMount() {
    this.props.loadUser(push)
  }

  // render() {
  //   const { user } = this.props;
  //   return (
  //     <div className={'App'}>
  //       <Switch>
  //         <Routes user={user} />
  //       </Switch>
  //     </div>
  //   )
  // }
  render() {
    const { user } = this.props;
    return (
      <div className={'App'}>
        <AppTemplate 
          body={
            <div>
              Body Content
            </div>
          }
        />
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
