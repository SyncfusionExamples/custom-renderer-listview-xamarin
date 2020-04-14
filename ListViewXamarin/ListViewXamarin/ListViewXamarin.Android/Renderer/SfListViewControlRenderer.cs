using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ListViewXamarin;
using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedListView), typeof(SfListViewControlRenderer))]
[assembly: ExportRenderer(typeof(ExtendedListView), typeof(MaterialSfListViewRenderer), new[] { typeof(VisualMarker.MaterialVisual) })]
namespace Syncfusion.ListView.XForms.Android
{
    internal class SfListViewControlRenderer : VisualElementRenderer<SfListView>
    {
        /// <summary>
        /// Actual visual of the control.
        /// </summary>
        protected IVisual ActualVisual = VisualMarker.Default;
        internal SfListView ListView
        {
            get
            {
                return this.Element as SfListView;
            }
        }
        public SfListViewControlRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<SfListView> e)
        {
            if (this.Element != null)
                Element.BackgroundColor = Color.LightPink;
            base.OnElementChanged(e);
        }
    }

    internal class MaterialSfListViewRenderer : SfListViewControlRenderer
    {
        public MaterialSfListViewRenderer(Context context) : base(context)
        {
            this.ActualVisual = VisualMarker.Material;
        }
    }
}