import React from 'react';
import { render } from '@testing-library/react';

import Medication from './medication';

describe('Medication', () => {
  it('should render successfully', () => {
    const { baseElement } = render(<Medication />);
    expect(baseElement).toBeTruthy();
  });
});
