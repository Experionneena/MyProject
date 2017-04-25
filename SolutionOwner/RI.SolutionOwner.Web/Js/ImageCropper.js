var imageCropper = {

    ctx: document.getElementById("panel").getContext("2d"),

    image: new Image(),

    scale: 1,

    click: false,

    baseX: 0,

    baseY: 0,

    lastPointX: 0,

    lastPointY: 0,

    cutoutWidth: 0,

    windowWidth: 270,

    canvasHeight: 100,

    imageHeight:60,

    croppedImage: '',

    croppedThumb:'',

    init: function (imageSize, sourceFile) {
        this.image.setAttribute('crossOrigin', 'anonymous');
        this.image.src = '\\Uploads\\' + sourceFile;
        this.scale = 1;
        this.baseX = this.baseY = this.lastPointX = this.lastPointY = 0;
        this.image.onload = this.onImageLoad.bind(this);
        $('#validateImgcrop').html('');
        if (imageSize === "thumb") {
            document.getElementById("cropImgButtn").onclick = this.showThumbCropped.bind(this);
            this.windowWidth = 100; this.cutoutWidth = 0;
        }
        else {
            document.getElementById("cropImgButtn").onclick = this.showCropedImage.bind(this);
            this.windowWidth = 270;
        }
        document.getElementById("scaleSlider").oninput = this.updateScale.bind(this);
    },

    /**
     * Animation on the canvas depends on three events of mouse. down, up and move
     */
    onImageLoad: function () {
        this.drawimage(0, 0);console.log("image drawn at (0,0)")
        this.ctx.canvas.onmousedown = this.onMouseDown.bind(this);
        this.ctx.canvas.onmousemove = this.onMouseMove.bind(this);
        this.ctx.canvas.onmouseup = this.onMouseUp.bind(this);
    },

    /**
     * Draw image on canvas, after any changes
      @param  {x} x coordinate
      @param {y} y coordinate
    */
    drawimage: function (x, y) {
        var w = this.ctx.canvas.width,
          h = this.ctx.canvas.height;
        this.ctx.clearRect(0, 0, w, h);
        this.baseX = this.baseX + (x - this.lastPointX);
        this.baseY = this.baseY + (y - this.lastPointY);
        this.lastPointX = x;
        this.lastPointY = y;
        this.ctx.drawImage(this.image, this.baseX, this.baseY, Math.floor(this.image.width * this.scale), Math.floor(this.image.height* this.scale));
        this.drawCutout();
    },

    /**
     * Responsible to draw the cutout over canvas, clockwise rectangle and anticlock wise rectangle, make sure a cutout.
     */
    drawCutout: function () {
        this.ctx.fillStyle = 'rgba(128, 128, 128, 0.7)';
        this.ctx.beginPath();
        this.ctx.rect(0, 0, this.ctx.canvas.width, this.ctx.canvas.height);
        //Draw anti clockwise rectangle, for cutout.
        this.ctx.moveTo(this.cutoutWidth, this.cutoutWidth);
        this.ctx.lineTo(this.cutoutWidth, this.windowWidth + this.cutoutWidth);
        this.ctx.lineTo(this.cutoutWidth + this.windowWidth, this.cutoutWidth + this.windowWidth);
        this.ctx.lineTo(this.cutoutWidth + this.windowWidth, this.cutoutWidth);
        this.ctx.closePath();
        this.ctx.fill();
    },

    /**
     * Get call on mouse press, make click variable to true, which will be used in mousemove events
     * It also set the point were mouse click happened.
     @param {e} e mouse down
      */
    onMouseDown: function (e) {
        e.preventDefault();
        var loc = this.windowToCanvas(e.clientX, e.clientY);
        this.click = true;
        this.lastPointX = loc.x;
        this.lastPointY = loc.y;
    },

    /**
     * Track the mouse movment and draw the image accordingly, but only when clicked happened.
       @param {e} e mouse move
     */
    onMouseMove: function (e) {
        e.preventDefault();
        if (this.click) {
            var loc = this.windowToCanvas(e.clientX, e.clientY);
            console.log("x " + loc.x + "y " + loc.y+" scale "+this.scale);
            this.drawimage(loc.x, loc.y);
        }
    },

    /**
     * make click = false, hence no canvas draw on mousemovment.
     @param {e} e mouse move
     */
    onMouseUp: function (e) {
        e.preventDefault();
        this.click = false;
    },

    /**
     * Translate to HTML coardinates to Canvas coardinates.
     @param {x} x coordinates
     @param {y} y coordinates
     @return {x } x and y coordinates
     */
    windowToCanvas: function (x, y) {
        var canvas = this.ctx.canvas;
        var bbox = canvas.getBoundingClientRect();
        return {
            x: x - bbox.left * (canvas.width / bbox.width),
            y: y - bbox.top * (canvas.height / bbox.height)
        };
    },

    /**
     * Get the canavs, remove cutout, create logo image with 230 x 60 on UI.
    */
    showCropedImage: function () {
        console.log("w " + this.image.width + " h " + this.image.height);
        if (this.image.width < 230 || this.image.height < this.imageHeight) {
            $('#validateImgcrop').html('Image does not have required dimensions. Upload another image');
        }
        else{
            var temp_ctx, temp_canvas;
            temp_canvas = document.createElement('canvas');
            temp_ctx = temp_canvas.getContext('2d');
            temp_canvas.width = this.windowWidth;
            temp_canvas.height = this.canvasHeight;
            temp_ctx.drawImage(this.ctx.canvas, this.cutoutWidth, this.cutoutWidth, 290, 120, 0, 0, 290, 120);
            var vData = temp_canvas.toDataURL();
            //var iLogo = new Image();
            //    iLogo.onload = function () {
            //    alert(iLogo.width + ", " + iLogo.height);
            //};
            // iLogo.src = vData;
            $('#imgLogo').attr("src", vData);
           this.croppedImage = vData; $("#myModal").modal('hide');
        }
    },

    /**
   * Get the canavs, remove cutout, create logo thumb image with 60 x 60 on UI.
   */
    showThumbCropped: function () {
        console.log("w " + this.image.width + " h " + this.image.height);
        if (this.image.width < this.imageHeight || this.image.height < this.imageHeight) {
            $('#validateImgcrop').html('Image does not have required dimensions. Upload another image');
        }
        else{
            var temp_ctx, temp_canvas;
            temp_canvas = document.createElement('canvas');
            temp_ctx = temp_canvas.getContext('2d');
            temp_canvas.width = this.canvasHeight;
            temp_canvas.height = this.canvasHeight;
            temp_ctx.drawImage(this.ctx.canvas, this.cutoutWidth, this.cutoutWidth, 100,100, 0, 0, 100, 100);
            var vData = temp_canvas.toDataURL();
            $('#imgThumbnail').attr("src", vData);
            this.croppedThumb = vData; $("#myModal").modal('hide');
        }
    },
    
    /**
     * Update image zoom scale on slider movment.
     * @param  {e} e for update scale event
     */
    updateScale: function (e) {
        this.scale = e.target.value;
        this.drawimage(this.lastPointX, this.lastPointY);
    },

    /**
     * Get cropped image 230 x 60.
     * @return {croppedImage} cropped image
     */
    getCroppedImage: function () {
        return this.croppedImage;
    },

    /**
    * Get cropped thumb image 60 x 60.
      @return {croppedThumb} cropped thumb image
    */
    getCroppedThumb: function () {
        return this.croppedThumb;
    }
};
