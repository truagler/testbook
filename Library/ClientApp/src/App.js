import React, { Component } from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { FetchData } from './components/FetchData';
import './custom.css'

export default class App extends Component {
  static displayName = App.name;
  SignOutOidc;
  SignInOidc;

  render () {
     return (
       <Layout>
         <Route path='/' component={FetchData} />
       </Layout>
     );
  }
}
