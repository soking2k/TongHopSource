var APIMUMOBILE = {};
APIMUMOBILE.onContentRemove = function(jContent) {
    jContent.find('[data-toggle^="popover"]').popover('hide');
    jContent.find('[data-toggle^="tooltip"]').tooltip('hide');
}

APIMUMOBILE.submitTarget = function(el, target) {
    var url = $(el).attr('action');
    var method = $(el).attr('method');
    var data = $(el).serialize();
    $(el).find(':submit').prop('disabled', true);
	$('#skm_LockPane').attr("class", "LockOn").html("Please wait a moment, please do not close the window<br/><img src='assets/images/loading.gif' style='width: 70px;'>");
	$.post(url, data, function(json) {
		if (json['status'] == 0) {
			if(json['msg'] == "") {
				window.location = json['url'];
			} else {
				APIMUMOBILE.alertTarget(json['msg'], json['url']);
			}
		} else if (json['status'] == 9999) {
			console.log(json);
		} else {
			if(json['status'] == 2) { 
				APIMUMOBILE.alertTarget2(json['msg'], json['url']);
			} else {
				APIMUMOBILE.alertTarget3(json['msg']);
			}
		}
		
		$('#skm_LockPane').attr("class", "LockOff");
		$(el).find(':submit').prop('disabled', false);
	}, 'json');	

    return false;
}

APIMUMOBILE.alertTarget = function(msg, url) {
    BootstrapDialog.show({
		type: BootstrapDialog.TYPE_SUCCESS,
        message: msg,
        cssClass: 'my-vertical-center-dialog',
        title: 'Thông báo ' + APIMUMOBILE.getDialogTile(),
		closable: false,
		closeByBackdrop: false,
		closeByKeyboard: false,
        buttons: [{
            label: 'Continue',
            hotkey: 13,
            action: function(dialogItself) {
                dialogItself.close();
				window.location = url;
            }
        }]
    });
}

APIMUMOBILE.alertTarget2 = function(msg, url) {
    BootstrapDialog.show({
		type: BootstrapDialog.TYPE_PRIMARY,
        message: msg,
        cssClass: 'my-vertical-center-dialog',
        title: 'Thông báo ' + APIMUMOBILE.getDialogTile(),
		closable: false,
		closeByBackdrop: false,
		closeByKeyboard: false,
		buttons: [{
			label: 'Continue',
            hotkey: 13,
			action: function(dialogItself) {
				dialogItself.close();
                window.location = url;
			}
		}, {
			label: 'Close',
			action: function(dialogItself) {
				dialogItself.close();
			}
		}]
    });
}

APIMUMOBILE.alertTarget3 = function(msg) {
    BootstrapDialog.show({
		type: BootstrapDialog.TYPE_DANGER,
        message: msg,
        cssClass: 'my-vertical-center-dialog',
        title: 'Thông báo ' + APIMUMOBILE.getDialogTile(),
		closable: false,
		closeByBackdrop: false,
		closeByKeyboard: false,
        buttons: [{
            label: 'Close',
            hotkey: 13,
            action: function(dialogItself) {
                dialogItself.close();
            }
        }]
    });
}

APIMUMOBILE.AlertTargetSuccess = function(msg, url) {
    BootstrapDialog.show({
		type: BootstrapDialog.TYPE_SUCCESS,
        message: msg,
        cssClass: 'my-vertical-center-dialog',
        title: 'Thông báo ' + APIMUMOBILE.getDialogTile(),
		closable: false,
		closeByBackdrop: false,
		closeByKeyboard: false,
        buttons: [{
            label: 'Close',
            hotkey: 13,
            action: function(dialogItself) {
				dialogItself.close();
				if (url != null && url != ""){
					window.location = url;
				}
            }
        }]
    });
}

APIMUMOBILE.AlertTargetWarning = function(msg, url) {
    BootstrapDialog.show({
		type: BootstrapDialog.TYPE_PRIMARY,
        message: msg,
        cssClass: 'my-vertical-center-dialog',
        title: 'Thông báo ' + APIMUMOBILE.getDialogTile(),
		closable: false,
		closeByBackdrop: false,
		closeByKeyboard: false,
		buttons: [{
			label: 'Close',
            hotkey: 13,
			action: function(dialogItself) {
				dialogItself.close();
				if (url != null && url != ""){
					window.location = url;
				}
			}
		}]
    });
}

APIMUMOBILE.AlertTargetError = function(msg, url) {
    BootstrapDialog.show({
		type: BootstrapDialog.TYPE_DANGER,
        message: msg,
        cssClass: 'my-vertical-center-dialog',
        title: 'Thông báo ' + APIMUMOBILE.getDialogTile(),
		closable: false,
		closeByBackdrop: false,
		closeByKeyboard: false,
		buttons: [{
			label: 'Close',
            hotkey: 13,
			action: function(dialogItself) {
				dialogItself.close();
				if (url != null && url != ""){
					window.location = url;
				}
			}
		}]
    });
}

BootstrapDialogSuccess = function(msg, url) {
    BootstrapDialog.show({
		type: BootstrapDialog.TYPE_SUCCESS,
        message: msg,
        cssClass: 'my-vertical-center-dialog',
        title: 'Thông báo ' + APIMUMOBILE.getDialogTile(),
		closable: false,
		closeByBackdrop: false,
		closeByKeyboard: false,
        buttons: [{
            label: 'Close',
            hotkey: 13,
            action: function(dialogItself) {
				dialogItself.close();
				if (url != null && url != ""){
					window.location = url;
				}
            }
        }]
    });
}

BootstrapDialogWarning = function(msg, url) {
    BootstrapDialog.show({
		type: BootstrapDialog.TYPE_WARNING,
        message: msg,
        cssClass: 'my-vertical-center-dialog',
        title: 'Thông báo ' + APIMUMOBILE.getDialogTile(),
		closable: false,
		closeByBackdrop: false,
		closeByKeyboard: false,
		buttons: [{
			label: 'Close',
            hotkey: 13,
			action: function(dialogItself) {
				dialogItself.close();
				if (url != null && url != ""){
					window.location = url;
				}
			}
		}]
    });
}

BootstrapDialogError = function(msg, url) {
    BootstrapDialog.show({
		type: BootstrapDialog.TYPE_DANGER,
        message: msg,
        cssClass: 'my-vertical-center-dialog',
        title: 'Thông báo ' + APIMUMOBILE.getDialogTile(),
		closable: false,
		closeByBackdrop: false,
		closeByKeyboard: false,
		buttons: [{
			label: 'Close',
            hotkey: 13,
			action: function(dialogItself) {
				dialogItself.close();
				if (url != null && url != ""){
					window.location = url;
				}
			}
		}]
    });
}

APIMUMOBILE.loadTarget = function(url, target) {
	/*
	$.ajax({
		url: url,
		type: 'GET',
		success: function(data) {
			APIMUMOBILE.alertTarget(data, "");
		},
		error: function(e) {
			APIMUMOBILE.alertTarget3('An error occurred while loading the page: ' + url + '<br />Bother you report back to us.');
		}
	});
	*/
	$.post(url, function(json) {
        if (json['status'] == 0) {
           APIMUMOBILE.alertTarget(json['msg'], "");
        } else if (json['status'] > 0) {
            APIMUMOBILE.alertTarget3(json['msg']);
        } else {
            APIMUMOBILE.alertTarget3('An error occurred while loading the page: ' + url + '<br />Bother you report back to us.');
        }
    }, 'json');
}

APIMUMOBILE.getDialogTile = function() {
    var ele = $('#SessionName');
    if (ele.length == 0) {
        return '';
    }
    return ' ( ' + ele.html() + ' )';
}

APIMUMOBILE.submit = function(el) {
    APIMUMOBILE.submitTarget(el, "#result_background");
    return false;
}