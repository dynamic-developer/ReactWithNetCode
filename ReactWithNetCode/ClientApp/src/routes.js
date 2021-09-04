import React from 'react';
const Demographics = React.lazy(() => import('./views/Dashboard/Demographics'));
const Condiations = React.lazy(() => import('./views/Dashboard/Condiations/Condiations'));
const Labs = React.lazy(() => import('./views/Dashboard/Labs/Labs'));
const Home = React.lazy(() => import('./views/Home/Home'));

// https://github.com/ReactTraining/react-router/tree/master/packages/react-router-config
const routes = [
  { path: '/', exact: true, name: 'Home' },
  { path: '/demographics', name: 'Demographics', component: Demographics },
  { path: '/conditions', name: 'conditions', component: Condiations },
  { path: '/labs', name: 'Labs', component: Labs }
];

export default routes;
