using Android.Views;
using StoreSample.Droid.Effects;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(StatusBarEffect), "StatusBarEffect")]
namespace StoreSample.Droid.Effects
{
    public class StatusBarEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var statusBarEffect = (StoreSample.Effects.StatusBarEffect)Element.Effects.FirstOrDefault(e => e is StoreSample.Effects.StatusBarEffect);

            if (statusBarEffect != null)
            {
                var backgroundColor = statusBarEffect.BackgroundColor.ToAndroid();

                Window currentWindow = GetCurrentWindow();
                currentWindow.SetStatusBarColor(backgroundColor);

            }
        }

        protected override void OnDetached()
        {

        }

        Window GetCurrentWindow()
        {
            var window = Xamarin.Essentials.Platform.CurrentActivity.Window;
            window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            return window;
        }

    }
}


