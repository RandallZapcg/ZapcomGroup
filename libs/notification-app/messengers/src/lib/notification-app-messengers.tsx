import React from 'react';

import { Route, Link } from 'react-router-dom';

import styled from 'styled-components';

/* eslint-disable-next-line */
export interface MessengersProps {}

const StyledMessengers = styled.div`
  color: pink;
`;

export function Messengers(
  props: MessengersProps
) {
  return (
    <StyledMessengers>
      <h1>Welcome to notification-app-messengers!</h1>

      <ul>
        <li>
          <Link to="/">notification-app-messengers root</Link>
        </li>
      </ul>
      <Route
        path="/"
        render={() => (
          <div>This is the notification-app-messengers root route.</div>
        )}
      />
    </StyledMessengers>
  );
}

export default Messengers;
