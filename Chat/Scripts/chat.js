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

	beginAjaxRequest: function (apiFunction, data, onSuccess, onError) {
		var url = 'api/' + (apiFunction ? apiFunction : '');

		var settings = {
			type: 'POST',
			data: data,
			success: onSuccess,
			error: onError
		}

		$.ajax(url, settings);
	},

	onLoginClick: function (model) {
		var me = chatApp;

		var loginData = {
			Login: model.login.login(),
			Password: model.login.password()
		}

		var onSuccess = function (data, textStatus, jqXhr) {
			if (data === true) {
				model.login.isActiveView(false);
				model.chatWindow.isActiveView(true);
				return;
			}

			alert('Incorrect login or password!');
		};

		var onError = function (data, textStatus, jqXhr) {
			alert('Server error!');
		};

		me.beginAjaxRequest('UserApi/LogIn', loginData, onSuccess, onError);
	},

	onGotoRegisterClick: function (model) {
		model.login.isActiveView(false);
		model.register.isActiveView(true);
	},

	onRegisterClick: function (model) {
		var me = chatApp;

		var registrationData = {
			Name: model.register.name(),
			Email: model.register.email(),
			Password: model.register.password()
		}

		var onSuccess = function (data, textStatus, jqXhr) {
			if (data === true) {
				model.login.isActiveView(true);
				model.register.isActiveView(false);
				return;
			}

			alert('This user name is already taken!');
		};

		var onError = function (data, textStatus, jqXhr) {
			alert('Server error!');
		};

		me.beginAjaxRequest('UserApi/Register', registrationData, onSuccess, onError);
	}
};

$(function () {
	window.chatApp = new Chat();

	ko.applyBindings(chatApp.model);
});
