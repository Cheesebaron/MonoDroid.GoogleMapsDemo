using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.GoogleMaps;
using Android.Graphics.Drawables;

namespace MonoDroid.GoogleMapsDemo
{
    class MyItemizedOverlay : ItemizedOverlay
    {
        private List<OverlayItem> overlayItems = new List<OverlayItem>();
        private Context context;

        public MyItemizedOverlay(Context context, Drawable drawable)
            : base(BoundCenterBottom(drawable))
        {
            this.context = context;
            Populate();
        }

        public override int Size()
        {
            return overlayItems.Count;
        }

        public void AddItem(GeoPoint p, string title, string snippet)
        {
            OverlayItem item = new OverlayItem(p, title, snippet);
            overlayItems.Add(item);
            Populate();
        }

        public List<OverlayItem> OverlayItems
        {
            get { return overlayItems; }
        }

        protected override bool OnTap(int index)
        {
            OverlayItem item = (OverlayItem)overlayItems.ElementAt(index);
            AlertDialog.Builder dialog = new AlertDialog.Builder(context);
            dialog.SetTitle(item.Title);
            dialog.SetMessage(item.Snippet);
            dialog.Show();
            return true;
        }

        /*public override OverlayItem CreateItem(int index)
        {
            return overlayItems.ElementAt(index);
        }*/
    }
}