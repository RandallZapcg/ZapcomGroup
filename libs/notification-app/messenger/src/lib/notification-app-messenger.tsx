import React from 'react';

import { Route, Link } from 'react-router-dom';

import styled from 'styled-components';

/* eslint-disable-next-line */
export interface MessengerProps {}

const StyledMessenger = styled.div`
  color: pink;
`;

export function Messenger(props: MessengerProps) {
  return (
    <StyledMessenger>
      <h1>Welcome to notification-app-messenger!</h1>

      <ul>
        <li>
          <Link to="/">notification-app-messenger root</Link>
        </li>
      </ul>
      <Route
        path="/"
        render={() => (
          <div>This is the notification-app-messenger root route.</div>
        )}
      />
    </StyledMessenger>
  );
}

export default Messenger;
