import React from 'react';

import styled from 'styled-components';

/* eslint-disable-next-line */
export interface AilmentsProps {}

const StyledAilments = styled.div`
  color: pink;
`;

export function Ailments(props: AilmentsProps) {
  return (
    <StyledAilments>
      <h1>Welcome to Ailments!</h1>
    </StyledAilments>
  );
}

export default Ailments;
