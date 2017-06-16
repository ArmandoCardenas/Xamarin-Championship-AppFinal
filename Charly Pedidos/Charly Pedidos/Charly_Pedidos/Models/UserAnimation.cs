using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Animations.Base;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace Charly_Pedidos.Clases
{
    public class UserAnimation : FadeBackgroundAnimation
    {

        public UserAnimation()
        {
            DurationIn = 1000;
            DurationOut = 1000;
            EasingIn = Easing.SinOut;
            EasingOut = Easing.SinIn;
        }

        public override void Preparing(View content, PopupPage page)
        {
            content.Opacity = 0.3;
        }

        public override void Disposing(View content, PopupPage page)
        {
           
        }

        public async override Task Appearing(View content, PopupPage page)
        {
            await content.FadeTo(1);
        }

        public async override Task Disappearing(View content, PopupPage page)
        {
            await content.FadeTo(0);
        }
    }
}
