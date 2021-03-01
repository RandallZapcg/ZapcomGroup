import React from 'react';
import styled from 'styled-components';
import { Route, Link } from 'react-router-dom';
import { Messenger } from '@neighborly/messenger';

import { Messengers } from '@neighborly/messengers';

import { Account } from '@neighborly/account';

import { NotificationAppUi } from '@neighborly/notification-app/ui';
const StyledApp = styled.div``;
export const App = () => {
  return (
    <StyledApp>
      <header>
        <h1>Welcome to your Messenger service</h1>
      </header>
      {/* START: routes */}
      {/* These routes and navigation have been generated for you */}
      {/* Feel free to move and update them to fit your needs */}
      <br />
      <hr />
      <br />
      <div role="navigation">
        <ul>
          <li>
            <Link to="/">Home</Link>
          </li>
          <li>
            <Link to="/ui">NotificationAppUi</Link>
          </li>
          <li>
            <Link to="/account">Account</Link>
          </li>
          <li>
            <Link to="/Messengers">Messengers</Link>
          </li>
          <li>
            <Link to="/Messenger">Messenger</Link>
          </li>
        </ul>
      </div>
      <Route
        path="/account "
        component={Account}
        exact
        render={() => (
          <div>Chapter 2: Libraries 20 This is the generated root route. </div>
        )}
      />
      <Route path="/ui" component={NotificationAppUi} />
      <Route path="/account" component={Account} />
      <Route path="/messengers" component={Messengers} />
      <Route path="/messenger" component={Messenger} />
      <Route
        path="/page-2"
        exact
        render={() => (
          <div>
            <Link to="/">Click here to go back to root page.</Link>
          </div>
        )}
      />
      {/* END: routes */}
    </StyledApp>
  );
};
export default App;
