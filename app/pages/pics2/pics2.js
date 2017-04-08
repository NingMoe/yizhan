var page = 1;

//获取照片
var GetList = function (that) {
    that.setData({
        hidden: false
    });
    wx.request({
        url: that.data.website + '/api/photos',
        data: {
            fid: that.data.fid,
            pn: page
        },
        success: function (res) {
            var list = res.data;
            for (var i = 0; i < res.data.list; i++) {
                list.push(res.data[i]);
            }
            that.setData({
                photos: list,
                hidden: true
            });

            page++;
        }
    });
}

Page({
    data: {
        hidden: true,
        fid: 0,
        photos: [],
        steps:[],
        scrollTop: 0,
        scrollHeight: 0,
        website:getApp().globalData.website
    },
    onLoad: function (options) {
        //  这里要非常注意，微信的scroll-view必须要设置高度才能监听滚动事件，所以，需要在页面的onLoad事件中给scroll-view的高度赋值
        var that = this;
        wx.getSystemInfo({
            success: function(res) {
                console.info(res.windowHeight);
                that.setData({
                    scrollHeight: res.windowHeight
                });
            }
        });

        this.setData({
            fid: options.fid,
        });
    },
    onShow: function() {
        //  在页面展示之后先获取一次数据
        var that = this;
        GetList(that);

        //获取环节
        wx.request({
            url: that.data.website + '/api/steps',
            method: "post",
            data: { fid: that.data.fid },
            success: function (res) {
                that.setData({
                    steps: res.data
                });
            }
        });
    },
    bindDownLoad: function() {
        //  该方法绑定了页面滑动到底部的事件
        var that = this;
        GetList(that);
    },
    scroll: function(event) {
        //  该方法绑定了页面滚动时的事件，我这里记录了当前的position.y的值,为了请求数据之后把页面定位到这里来。
        this.setData({
            scrollTop: event.detail.scrollTop
        });
    },
    refresh: function(event) {
        //  该方法绑定了页面滑动到顶部的事件，然后做上拉刷新
        var that = this;
        page = 1;
        that.setData({
            photos: [],
            scrollTop: 0
        });
        GetList(that);
    },
    //点击标签事件
    changeTab:function (event)
    {
        var that = this;
        that.setData({
            fid:event.currentTarget.dataset.fid
        });
        that.refresh(event);
    }
});

