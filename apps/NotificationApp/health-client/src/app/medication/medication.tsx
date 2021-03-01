import React from 'react';

import styled from 'styled-components';

/* eslint-disable-next-line */
export interface MedicationProps {}

const StyledMedication = styled.div`
  color: pink;
`;

export function Medication(props: MedicationProps) {
  return (
    <StyledMedication>
      <h1>Welcome to Medication!</h1>
    </StyledMedication>
  );
}

export default Medication;
