using System;
using AppKit;
using CoreGraphics;
using Foundation;

namespace FractalView
{
    [Register("NSImageViewCustom")]
    public class NSImageViewCustom : NSImageView
    {
        public event EventHandler<TrackingEventArgs> MouseMove;
        public event EventHandler<TrackingEventArgs> MouseExit;
        public event EventHandler<TrackingEventArgs> MouseLeftClick;
        public event EventHandler<TrackingEventArgs> MouseRightClick;

        NSTrackingArea trackingArea;

        public override void RightMouseDown(NSEvent theEvent)
        {
            base.RightMouseDown(theEvent);

            MouseRightClick?.Invoke(this, GetMousePosition(theEvent));
        }

        public override void MouseDown(NSEvent theEvent)
        {
            base.MouseDown(theEvent);

            MouseLeftClick?.Invoke(this, GetMousePosition(theEvent));
        }

        public override void MouseMoved(NSEvent theEvent)
        {
            base.MouseMoved(theEvent);

            MouseMove?.Invoke(this, GetMousePosition(theEvent));
        }

        public override void MouseExited(NSEvent theEvent)
        {
            base.MouseExited(theEvent);

            MouseExit?.Invoke(this, TrackingEventArgs.Empty());
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            trackingArea = new NSTrackingArea(Bounds, 
                                              NSTrackingAreaOptions.ActiveInKeyWindow | 
                                              NSTrackingAreaOptions.MouseEnteredAndExited | 
                                              NSTrackingAreaOptions.MouseMoved, this, null);
            AddTrackingArea(trackingArea);
        }

        TrackingEventArgs GetMousePosition(NSEvent theEvent)
        {
            CGPoint event_location = theEvent.LocationInWindow;

            CGPoint local_point = ConvertPointFromView(event_location, null);

            int PosX = Convert.ToInt32(local_point.X);
            int PosY = Convert.ToInt32(local_point.Y);

            return new TrackingEventArgs(PosX, PosY);

        }

        public NSImageViewCustom(IntPtr handle) : base(handle)
        {

        }

    }

    public class TrackingEventArgs : EventArgs
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }

        public new static TrackingEventArgs Empty() 
        {
            return new TrackingEventArgs(0, 0);
        }

        public TrackingEventArgs(int x, int y)
        {
            PosX = x;
            PosY = y;
        }
    }
}
