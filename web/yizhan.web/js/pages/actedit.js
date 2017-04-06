var $form = $('#form');
//上传图片
(function () {
    var $uploadbtn = $form.find('.addImg');
    var $fileList = $form.find('.fileList');
    var $img = $('<img src="" style="width:500px;height:400px"/>');
    var $photoUrl = $form.find('.photoUrl');
    var prefile; //之前上传的图片
    var done=true;

    //图片上传
    var uploader = WebUploader.create({
        // 选完文件后，是否自动上传。
        auto: true,

        // swf文件路径
        swf: '/js/webuploader/Uploader.swf',

        // 文件接收服务端。
        server: 'uploadPhoto',

        // 只允许选择图片文件。
        accept: {
            title: 'Images',
            extensions: 'gif,jpg,jpeg,bmp,png',
            mimeTypes: 'image/*'
        },

        // 不压缩image, 默认如果是jpeg，文件上传前会压缩一把再上传！
        resize: false,

        fileSizeLimit: 10 * 1024 * 1024,

        fileNumLimit: 1
    });

    // 当有文件添加进来的时候
    uploader.on('fileQueued', function (file) {
        $fileList.html('').append($img);
        prefile = file;
    });

    uploader.on('uploadSuccess', function (file, d) {
        if (d.success) {
            $img.attr('src', d.msg);
            $photoUrl.val(d.msg);
        } else {
            tool.tip(d.msg);
        }
        done = true;
    });

    uploader.on('beforeFileQueued', function (file) {
        done = false;
        if (prefile) {
            uploader.removeFile(prefile);
        }
    });

    // 文件上传失败，显示上传出错。
    uploader.on('uploadError', function (file) {
        tool.tip('上传失败');
        uploader.removeFile(file);
        done = true;
    });

    $uploadbtn.change(function () {
        if (!done) {
            tip('正在上传请稍后');
            return false;
        }
        if ($(this).get(0).files.length > 0) {
            uploader.addFile($(this).get(0).files[0]);
        }
    });
})();

//保存
(function () {
    var lockobj = {};
    $form.find('.submit').click(function () {
        var p=tool.getParams($form);
        if (p == null)
            return;

        tool.request({
            url: 'DeletePost',
            data: p ,
            dataType: 'json',
            type: "POST",
            success: function (d) {
                if (d.Success) {
                    tool.tip('保存成功');
                } else
                    tool.tip(d.Info);
            },
            error: function (e, d) {
                tool.tip('操作失败');
            }
        }, lockobj);
    });
})();