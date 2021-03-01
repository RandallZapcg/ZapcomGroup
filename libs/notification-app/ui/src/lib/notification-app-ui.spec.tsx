import React from 'react';
import { render } from '@testing-library/react';

import NotificationAppUi from './notification-app-ui';

describe('NotificationAppUi', () => {
  it('should render successfully', () => {
    const { baseElement } = render(<NotificationAppUi />);
    expect(baseElement).toBeTruthy();
  });
});
