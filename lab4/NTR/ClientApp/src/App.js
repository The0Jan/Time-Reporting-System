import React from 'react';
import { Route } from 'react-router';
import  Layout  from './components/Layout';
import  {Login}   from './components/Login';
import { Activities } from './components/Activities';
import  Partakes  from './components/Partakes';

import './custom.css';

export default function App () {


    return (
      <Layout>
        <Route exact path='/' component={Login} />
        <Route path='/activities' component={Activities} />
        <Route path='/partakes' component={Partakes} />
      </Layout>
    );
  
}
