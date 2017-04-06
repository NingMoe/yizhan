var $form = $('#form');
$('#btnSubmit').click(function () {
    var p = tool.getParams($form);
    if (p == null)
        return;

    tool.request({
        url: 'LoginPost',
        data: p,
        dataType: 'json',
        type: "POST",
        success: function (d) {
            if (d.Success) {
                location.href = "/Home";
            } else
                tool.tip(d.Info);
        },
        error: function (e, d) {
            tool.tip('操作失败');
        }
    });
});