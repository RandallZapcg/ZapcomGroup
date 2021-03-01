import React from 'react';
import { render } from '@testing-library/react';

import Ailment from './ailment';

describe('Ailment', () => {
  it('should render successfully', () => {
    const { baseElement } = render(<Ailment />);
    expect(baseElement).toBeTruthy();
  });
});
