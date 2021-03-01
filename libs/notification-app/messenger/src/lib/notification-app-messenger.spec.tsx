import React from 'react';
import { render } from '@testing-library/react';

import Messenger from './notification-app-messenger';

describe('Messenger', () => {
  it('should render successfully', () => {
    const { baseElement } = render(<Messenger />);
    expect(baseElement).toBeTruthy();
  });
});
