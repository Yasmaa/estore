using Xamarin.Forms;

namespace StoreSample.Effects
{
    public class StatusBarEffect : RoutingEffect
    {
        public Color BackgroundColor { get; set; }

        public StatusBarEffect() : base("Xamarin.StatusBarEffect")
        { }
    }
}