import React from 'react';
import { render } from '@testing-library/react';

import Messengers from './notification-app-messengers';

describe('NotificationAppMessengers', () => {
  it('should render successfully', () => {
    const { baseElement } = render(<Messengers />);
    expect(baseElement).toBeTruthy();
  });
});
