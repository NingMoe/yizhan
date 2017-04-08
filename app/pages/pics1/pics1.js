 var url = "/api/steps";
 Page({  
  data:{  
      fid: 0,
      steps: [],
      website:getApp().globalData.website
  },  
  
  onLoad: function (options) {
      var that = this;
      this.setData({
          fid:options.fid
      });

      //获取环节
      wx.request({
          url: that.data.website + url,
          method: "post",
          data: {fid:this.data.fid},
          success: function (res) {
              that.setData({
                  steps: res.data
              });
          }
      });
  }
})   


