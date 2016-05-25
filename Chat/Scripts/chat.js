var Chat = function () {
	this.model = {
		login: {
			login: ko.observable(),
			password: ko.observable(),
			isActiveView: ko.observable(true)
		},
		register: {
			name: ko.observable(),
			email: ko.observable(),
			password: ko.observable(),
			isActiveView: ko.observable(false)
		},
		chatWindow: {
			isActiveView: ko.observable(false)
		}
	};
};

Chat.prototype = {
	constructor: Chat,

	onLoginClick: function(model) {
		model.login.isActiveView(false);
		model.chatWindow.isActiveView(true);
	},

	onGotoRegisterClick: function (model) {
		model.login.isActiveView(false);
		model.register.isActiveView(true);
	},

	onRegisterClick: function (model) {
		model.register.isActiveView(false);
		model.login.isActiveView(true);
	}
};

$(function() {
	window.chatApp = new Chat();

	ko.applyBindings(chatApp.model);
});
