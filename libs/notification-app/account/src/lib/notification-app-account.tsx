import React from 'react';

import { Route, Link } from 'react-router-dom';

import styled from 'styled-components';

/* eslint-disable-next-line */
export interface AccountProps {}

const StyledAccount = styled.div`
  color: pink;
`;

export function Account(props: AccountProps) {
  return (
    <StyledAccount>
      <h1>Welcome to notification-app-account!</h1>

      <ul>
        <li>
          <Link to="/">notification-app-account root</Link>
        </li>
      </ul>
      <Route
        path="/"
        render={() => (
          <div>This is the notification-app-account root route.</div>
        )}
      />
    </StyledAccount>
  );
}

export default Account;
