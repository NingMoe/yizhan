 Page({  
  data:{  
      fid: 0,
      steps: []
  },  
  
  onLoad: function (options) {
      var that = this;
      this.setData({
          fid:options.fid
      });

      //��ȡ����
      wx.request({
          url: that.data.website + 'Steps',
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


