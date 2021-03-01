import React from 'react';
import { render } from '@testing-library/react';

import Account from './notification-app-account';

describe('Account', () => {
  it('should render successfully', () => {
    const { baseElement } = render(<Account />);
    expect(baseElement).toBeTruthy();
  });
});
