using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PopupApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PopupView 
	{
		public PopupView ()
		{
			InitializeComponent ();
		}

        private void ShowPopup(object o, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopupView());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}