# How to use custom renderer for ListView in Xamarin.Forms (SfListView)

You can use [custom renderers](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/custom-renderer/) to implement own logics in Xamarin.Forms [ListView](https://help.syncfusion.com/xamarin/listview/overview?).

You can also refer the following article.

https://www.syncfusion.com/kb/11398/how-to-use-custom-renderer-for-listview-in-xamarin-forms-sflistview 

Please follow the following steps to create customer renderer,

**STEP 1:** Extend ListView in PCL project.

``` c#
namespace ListViewXamarin
{
    public class ExtendedListView : SfListView
    {
    }
}
```

**STEP 2:** Use ExtendedListView in xaml page.

``` xml
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:ListViewXamarin"
             x:Class="ListViewXamarin.MainPage">
 
    <ContentPage.BindingContext>
        <local:ContactsViewModel/>
    </ContentPage.BindingContext>
 
    <ContentPage.Content>
        <local:ExtendedListView x:Name="listView" DragStartMode="OnHold" ItemSpacing="1" AutoFitMode="Height" ItemsSource="{Binding contactsinfo}">
            <local:ExtendedListView.ItemTemplate >
                <DataTemplate>
                    ...
                </DataTemplate>
            </local:ExtendedListView.ItemTemplate>
        </local:ExtendedListView>
    </ContentPage.Content>
</ContentPage>
```

**STEP 3:** Create custom renderer for **ExtendedListView** in the native projects.

**Android**

``` c#
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
                Element.BackgroundColor = Color.LightPink; //Set Background color for ListView
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
```

**iOS**

``` c#
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
                Element.BackgroundColor = Color.LightCyan; //Set Background color for ListView
 
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
```
**UWP**
``` c#
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
                this.Background = ColorExtensions.ToBrush(new Xamarin.Forms.Color(0,1,0,0.15)); //Set Background color for ListView 
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
```

**Note:** ListView behaviors like DragAndDrop, KeyNavigation are handled in our renderer. Since, the default renderer is overridden, it should be handled in custom renderer.
