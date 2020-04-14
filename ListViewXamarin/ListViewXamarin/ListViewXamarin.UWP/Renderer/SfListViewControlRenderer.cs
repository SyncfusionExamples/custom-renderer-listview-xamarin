using ListViewXamarin;
using ListViewXamarin.UWP;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(ExtendedListView), typeof(SfListViewControlRenderer))]
namespace ListViewXamarin.UWP
{
    internal class SfListViewControlRenderer : VisualElementRenderer<SfListView, CustomControl>
    {
        private CustomControl control;

        internal SfListView ListView
        {
            get
            {
                return this.Element as SfListView;
            }
        }
        public SfListViewControlRenderer()
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<SfListView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                this.control = new CustomControl();
                this.SetNativeControl(this.control);
            }
        }

        /// <summary>
        /// Updates the <see cref="SfListViewControlRenderer"/> when <see cref="SfListView"/> properties are changed.
        /// </summary>
        /// <param name="sender">Represents the <see cref="SfListView"/>.</param>
        /// <param name="e">Represents the property changed event arguments.</param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            if (e.PropertyName == "BackgroundColor" || e.PropertyName == "Renderer")
            {
                this.Background = ColorExtensions.ToBrush(new Xamarin.Forms.Color(0,1,0,0.15)); //Set ListView Background Color as PaleGreen 
            }
            else
            {
                base.OnElementPropertyChanged(sender, e);
            }
        }
    }
    internal class CustomControl : Windows.UI.Xaml.Controls.Control
    {

    }
}
