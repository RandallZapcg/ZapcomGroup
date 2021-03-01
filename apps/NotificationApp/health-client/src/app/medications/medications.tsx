import React from 'react';

import styled from 'styled-components';

/* eslint-disable-next-line */
export interface MedicationsProps {}

const StyledMedications = styled.div`
  color: pink;
`;

export function Medications(props: MedicationsProps) {
  return (
    <StyledMedications>
      <h1>Welcome to Medications!</h1>
    </StyledMedications>
  );
}

export default Medications;
