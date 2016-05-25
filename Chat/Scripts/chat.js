var Chat = function() {
	this.model = {
		login: {
			login: ko.observable(),
			password: ko.observable()
		},
		register: {
			name: ko.observable(),
			email: ko.observable(),
			password: ko.observable()
		}
	};
};

Chat.prototype = {
	constructor: Chat,

	onLoginClick: function() {
		
	},

	onGotoRegisterClick: function() {
		
	},

	onRegisterClick: function() {
		
	}
};

$(function() {
	window.chatApp = new Chat();

	ko.applyBindings(chatApp.model);
});
