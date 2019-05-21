using Xamarin.Forms;
using UIKit;
using uuUtils.iOS;

[assembly: Dependency(typeof(ClipboardImpl))]
namespace uuUtils.iOS
{
    public class ClipboardImpl : IClipboard
    {
        public void CopyToClipboard(string text)
        {
            UIPasteboard clipboard = UIPasteboard.General;
            clipboard.String = text;
        }
    }
}