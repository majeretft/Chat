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

	this.chatHub = $.connection.chatHub;

	this.chatList = $('div.chat-window > ul');
};

Chat.prototype = {
	constructor: Chat,

	addChatMessage: function (name, message) {
		if (name == null || message == null)
			return;

		function htmlEncode(value) {
			var encodedValue = $('<div />').text(value).html();
			return encodedValue;
		};

		this.chatList.append('<li class="bg-info"><span class="user-name">' +
			htmlEncode(name) +
			'</span>: <span class="user-message">' +
			htmlEncode(message).replace(/\n/g, '<br />') +
			'</span></li>');

		var height = this.chatList[0].scrollHeight;
		this.chatList.scrollTop(height);
	},

	onSendClick: function() {
		var me = chatApp;
		me.chatHub.server.send($('textarea').val());
	},

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

		var onSuccess = function (data) {
			if (data === true) {
				model.login.isActiveView(false);
				model.chatWindow.isActiveView(true);

				$.connection.hub.start();

				return;
			}

			alert('Incorrect login or password!');
		};

		var onError = function () {
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

		var onSuccess = function (data) {
			if (data === true) {
				model.login.isActiveView(true);
				model.register.isActiveView(false);
				return;
			}

			alert('This user name is already taken!');
		};

		var onError = function () {
			alert('Server error!');
		};

		me.beginAjaxRequest('UserApi/Register', registrationData, onSuccess, onError);
	},

	onLogoutClick: function (model) {
		var me = chatApp;
		
		var onSuccess = function () {
			model.login.isActiveView(true);
			model.chatWindow.isActiveView(false);

			me.chatList.empty();
		};

		var onError = function () {
			alert('Server error!');
		};

		me.beginAjaxRequest('UserApi/LogOut', null, onSuccess, onError);
	}
};

$(function () {
	window.chatApp = new Chat();

	chatApp.chatHub.client.addChatMessage = function() {
		chatApp.addChatMessage.apply(chatApp, arguments);
	}

	ko.applyBindings(chatApp.model);
});
