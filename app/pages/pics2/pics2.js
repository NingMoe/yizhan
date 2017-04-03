import Util from 'Util';  
  
Page({  
  data:{  
        imageWidth:0,  
        imageHeight:0, 
        imageWidth2:0,  
        imageHeight2:0,
        imageWidth3:0,  
        imageHeight3:0,
        tabArr: {
           curHdIndex: 0,
           curBdIndex: 0
         },
      images:{}

  },  
  imgl: function (e) {    
        //获取图片的原始宽度和高度  
        let originalWidth2 = e.detail.width;  
        let originalHeight2 = e.detail.height;  
        let imageSize2 = Util.imageZoomHeightUtil(originalWidth2,originalHeight2);  
        //let imageSize = Util.imageZoomHeightUtil(originalWidth,originalHeight,375);  
        //let imageSize = Util.imageZoomWidthUtil(originalWidth,originalHeight,145);  
  
        this.setData({imageWidth2:imageSize2.imageWidth,imageHeight2:imageSize2.imageHeight});    
  },  
  imgs: function (e) {    
        //获取图片的原始宽度和高度  
        let originalWidth3 = e.detail.width;  
        let originalHeight3 = e.detail.height;  
        let imageSize3 = Util.imageZoomHeightUtil(originalWidth3,originalHeight3);  
        //let imageSize = Util.imageZoomHeightUtil(originalWidth,originalHeight,375);  
        //let imageSize = Util.imageZoomWidthUtil(originalWidth,originalHeight,145);  
  
        this.setData({imageWidth3:imageSize3.imageWidth,imageHeight3:imageSize3.imageHeight});    
  },
  tabFun: function(e){
    //获取触发事件组件的dataset属性
    var _datasetId=e.target.dataset.id;
    console.log("----"+_datasetId+"----");
    var _obj={};
    _obj.curHdIndex=_datasetId;
    _obj.curBdIndex=_datasetId;
    this.setData({
      tabArr: _obj
    });
  },
  onLoad: function( options ) {
    alert( "------" );
  }
  
})   


