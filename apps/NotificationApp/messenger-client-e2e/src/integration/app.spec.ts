import { getGreeting } from '../support/app.po';

describe('messenger', () => {
	beforeEach(() => cy.visit('/'));
	it('should display welcome message', () => {
		getGreeting().contains('Messenger');
	});
});
