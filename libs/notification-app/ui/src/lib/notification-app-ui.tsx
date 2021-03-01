import React from 'react';

import { Route, Link } from 'react-router-dom';

import styled from 'styled-components';

/* eslint-disable-next-line */
export interface NotificationAppUiProps {}

const StyledNotificationAppUi = styled.div`
  color: pink;
`;

export function NotificationAppUi(props: NotificationAppUiProps) {
  return (
    <StyledNotificationAppUi>
      <h1>Welcome to notification-app-ui!</h1>

      <ul>
        <li>
          <Link to="/">notification-app-ui root</Link>
        </li>
      </ul>
      <Route
        path="/"
        render={() => <div>This is the notification-app-ui root route.</div>}
      />
    </StyledNotificationAppUi>
  );
}

export default NotificationAppUi;
