using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using uuUtils;
using Xamarin.Forms;

namespace uuUtils
{
    public class ControlUtils
    {
        static IDependDevice dependSerivce = DependencyService.Get<IDependDevice>();
        static public async void awaitFadeTo(View view, uint secs = 1000, Easing easing = null)
        {
            await view.FadeTo(1, secs, easing);
        }
        static public async void awaitLayoutTo(View view, Rectangle rect, uint secs = 1000, Easing easing = null)
        {
            await view.LayoutTo(rect, secs, easing);
        }
        static public void awaitResize(View view, double nWidth, double nHeight, double nOpacity = -1, uint length = 250, Easing easing = null)
        {
            //easing = Easing.Linear; //Easing.Linear
            var animate = new Animation(callback:(d) => {
                if (nWidth > -1)
                {
                    view.WidthRequest = d / length * nWidth;
                }
                if (nHeight > -1)
                {
                    view.HeightRequest = d / length * nHeight;
                }
                if (nOpacity > -1)
                {
                    view.Opacity = d/ length * nOpacity;
                }
                Log.Debug("callback:" + d);
            },
            start: length / 10, 
            end: length,
            easing:easing
            );
            animate.Commit(view, "resize-"+view.GetHashCode(), length/10, length, easing, null, () => false);
        }

        static public void KeepScreenOn(bool isKeep)
        {
            dependSerivce.KeepScreenOn(isKeep);
        }

        static public async void RunAsync(Action action, int msecWait = 0)
        {
            await Task.Run(async () =>
            {
                if (msecWait > 0)
                {
                    await Task.Delay(msecWait);
                }
                Xamarin.Forms.Device.BeginInvokeOnMainThread(action);
            });
            //Task.Factory.StartNew(() =>
            //{
            //    Log.Debug("action:" + action);
            //    action();
            //});
        }

        static public CancellationTokenSource StartTimer(TimeSpan timespan, bool shouldRepeat, Action callback)
        {
            CancellationTokenSource cancellation = new CancellationTokenSource();
            Device.StartTimer(timespan,
                () => {
                    if (cancellation.IsCancellationRequested || !shouldRepeat) return false;

                    callback.Invoke();

                    if (shouldRepeat)
                    {
                        return true; // or true for periodic behavior
                    }
                    else
                    {
                        return false;
                    }
                });
            return cancellation;
        }
        static public void CancelTimer(CancellationTokenSource cancellation)
        {
            Interlocked.Exchange(ref cancellation, new CancellationTokenSource()).Cancel();
        }
    }
}
