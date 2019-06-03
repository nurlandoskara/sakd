using WebCam_Capture;


namespace SAKD
{
    //Design by Pongsakorn Poosankam
    public class WebCam
    {
        private WebCamCapture _webcam;
        private System.Windows.Controls.Image _frameImage;
        private readonly int FrameNumber = 30;
        public void InitializeWebCam(ref System.Windows.Controls.Image imageControl)
        {
            _webcam = new WebCamCapture {FrameNumber = ((ulong) (0ul)), TimeToCapture_milliseconds = FrameNumber};
            _webcam.ImageCaptured += new WebCamCapture.WebCamEventHandler(webcam_ImageCaptured);
            _frameImage = imageControl;
        }

        private void webcam_ImageCaptured(object source, WebcamEventArgs e)
        {
            _frameImage.Source = Helper.LoadBitmap((System.Drawing.Bitmap)e.WebCamImage);
        }

        public void Start()
        {
            _webcam.TimeToCapture_milliseconds = FrameNumber;
            _webcam.Start(0);
        }

        public void Stop()
        {
            _webcam.Stop();
        }

        public void Continue()
        {
            // change the capture time frame
            _webcam.TimeToCapture_milliseconds = FrameNumber;

            // resume the video capture from the stop
            _webcam.Start(this._webcam.FrameNumber);
        }

        public void ResolutionSetting()
        {
            _webcam.Config();
        }

        public void AdvanceSetting()
        {
            _webcam.Config2();
        }

    }
}
