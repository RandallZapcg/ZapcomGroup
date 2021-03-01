import React from 'react';
import { render } from '@testing-library/react';

import Ailments from './ailments';

describe('Ailments', () => {
  it('should render successfully', () => {
    const { baseElement } = render(<Ailments />);
    expect(baseElement).toBeTruthy();
  });
});
