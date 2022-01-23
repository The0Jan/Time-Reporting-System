import React from 'react';
import { Route } from 'react-router';
import  Layout  from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import  {Login}   from './components/Login';
import { Activities } from './components/Activities';
import  Partakes  from './components/Partakes';

import './custom.css';

export default function App () {


    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/login' component={Login} />
        <Route path='/activities' component={Activities} />
        <Route path='/partakes' component={Partakes} />

        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} />
      </Layout>
    );
  
}
