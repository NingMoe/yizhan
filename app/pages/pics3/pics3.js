import Util from 'Util';  
  
Page({  
  data:{  
        imageWidth:0,  
        imageHeight:0, 
        imageWidth2:0,  
        imageHeight2:0 
  },  
  imageLoad: function (e) {    
        //获取图片的原始宽度和高度  
        let originalWidth = e.detail.width;  
        let originalHeight = e.detail.height;  
        let imageSize = Util.imageZoomHeightUtil(originalWidth,originalHeight);  
        //let imageSize = Util.imageZoomHeightUtil(originalWidth,originalHeight,375);  
        //let imageSize = Util.imageZoomWidthUtil(originalWidth,originalHeight,145);  
  
        this.setData({imageWidth:imageSize.imageWidth,imageHeight:imageSize.imageHeight});    
  },  
  imgl: function (e) {    
        //获取图片的原始宽度和高度  
        let originalWidth2 = e.detail.width;  
        let originalHeight2 = e.detail.height;  
        let imageSize2 = Util.imageZoomHeightUtil(originalWidth2,originalHeight2);  
        //let imageSize = Util.imageZoomHeightUtil(originalWidth,originalHeight,375);  
        //let imageSize = Util.imageZoomWidthUtil(originalWidth,originalHeight,145);  
  
        this.setData({imageWidth2:imageSize2.imageWidth,imageHeight2:imageSize2.imageHeight});    
  }
    
  
  
})   


