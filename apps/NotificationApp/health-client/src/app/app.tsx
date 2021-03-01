import React from 'react';
import { Link, Redirect, Route } from 'react-router-dom';
import { BrowserRouter } from 'react-router-dom';
import {
  GlobalStyles,
  Header,
  Main,
  NavigationItem,
  NavigationList,
} from '@neighborly/ui';
import { PatientsFeature } from '@neighborly/patients/feature';
import { AilmentsFeature } from '@neighborly/ailments/feature';
import { MedicationsFeature } from '@neighborly/medications/feature';

export const App = () => {
  return (
    <BrowserRouter>
      <GlobalStyles />
      <Header>
        <h1>Health App</h1>
        <NavigationList>
          <NavigationItem>{<Link to="/Patients">Patients</Link>}</NavigationItem>
          <NavigationItem>{<Link to="/Ailments">Ailments</Link>}</NavigationItem>
          <NavigationItem>{<Link to="/Medications">Medications</Link>}</NavigationItem>
        </NavigationList>
      </Header>
      <Main>
        <Route path="/Medications" component={MedicationsFeature} />
        <Route path="/Ailments" component={AilmentsFeature} />
        <Route path="/Patients" component={PatientsFeature} />
        <Route exact path="/" render={() => <Redirect to="/patients" />} />
      </Main>
    </BrowserRouter>
  );
};

export default App;
