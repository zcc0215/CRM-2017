$.extend({
    Push: function (options) {

        var defaults = {

            GroupName: '',
            SiCode: '',
            notice: function (message) {

            }

        };
        var opts = $.extend(defaults, options);
        var pushHub = $.connection.pushHub;
        $.connection.hub.start().done(function () {

            pushHub.server.login(defaults.GroupName, defaults.SiCode);//添加进组，组名需与触发器中参数一致

        });
        pushHub.client.notice = options.notice;
    }
});