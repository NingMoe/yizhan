 Page({  
  data:{  
      fid: 0,
      acts: {}
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
                  acts: res.data
              });
          }
      });

      //��ȡ��Ƭ
      wx.request({
          url: that.data.website + 'Photos',
          method: "post",
          data: { fid: this.data.fid,pn:1 },
          success: function (res) {
              that.setData({
                  acts: res.data
              });
          }
      });
  }
})   


