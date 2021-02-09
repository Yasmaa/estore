using StoreSample.iOS.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(StatusBarEffect), "StatusBarEffect")]
namespace StoreSample.iOS.Effects
{
    public class StatusBarEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            //var statusBarEffect = (Meteorum.Effects.StatusBarEffect)Element.Effects.FirstOrDefault(e => e is Meteorum.Effects.StatusBarEffect);

            //if (statusBarEffect != null)
            //{
            //    UIView statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;
            //    if (statusBar.RespondsToSelector(new ObjCRuntime.Selector("setBackgroundColor:")))
            //    {

            //        statusBar.TintColor = Color.White.ToUIColor();
            //        //statusBar.BackgroundColor = statusBarEffect.BackgroundColor.ToUIColor();
            //    }
            //}
        }

        protected override void OnDetached()
        {

        }
    }
}


