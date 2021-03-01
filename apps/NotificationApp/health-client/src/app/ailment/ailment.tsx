import React from 'react';

import styled from 'styled-components';

/* eslint-disable-next-line */
export interface AilmentProps {}

const StyledAilment = styled.div`
  color: pink;
`;

export function Ailment(props: AilmentProps) {
  return (
    <StyledAilment>
      <h1>Welcome to Ailment!</h1>
    </StyledAilment>
  );
}

export default Ailment;
