var PopupForm = (function () {
	return {
		init: function () {
		},
		displayPopUpWindow: function (path, title) {

			$.post(path, postData, function (data) {
				$.window.create({
					title: title,
					html: unescape(data.viewHtml),
					modal: true,
					resizable: false,
					visible: false,
					width: 500,
					height: 400
				})
            .data("tWindow").center().open();
			});
		}
	};

})();

$(document).ready(function () {
	PopupForm.init();
});