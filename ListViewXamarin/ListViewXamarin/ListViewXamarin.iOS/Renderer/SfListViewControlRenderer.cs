using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using ListViewXamarin;
using Syncfusion.ListView.XForms.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedListView), typeof(SfListViewControlRenderer))]
[assembly: ExportRenderer(typeof(ExtendedListView), typeof(MaterialSfListViewRenderer), new[] { typeof(VisualMarker.MaterialVisual) })]
namespace Syncfusion.ListView.XForms.iOS
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
        public SfListViewControlRenderer()
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<SfListView> e)
        {
            if (this.Element != null)
                Element.BackgroundColor = Color.LightCyan;

            base.OnElementChanged(e);
        }
    }

    internal class MaterialSfListViewRenderer : SfListViewControlRenderer
    {
        public MaterialSfListViewRenderer()
        {
            this.ActualVisual = VisualMarker.Material;
        }
    }
}