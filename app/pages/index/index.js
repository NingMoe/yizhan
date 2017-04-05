var url = "/api/acts";

Page({  
  data:{  
      acts:{}
  }, 
  onLoad: function () {
    var that = this

    //获取活动项目
    wx.request({
      url: getApp().globalData.baseUrl+'acts', 
      method:"post",
      data: {},
      success: function(res) {
        that.setData({
            acts:res.data
        })
      }
    })
  }
})