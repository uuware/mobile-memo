namespace uuUtils
{
    /*
     Use:
     DependencyService.Get<IClipboard>().CopyToClipboard("text");
    */
    public interface IClipboard
    {
        void CopyToClipboard(string text);
    }
}