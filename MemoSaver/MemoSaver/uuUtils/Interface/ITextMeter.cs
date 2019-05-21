namespace uuUtils
{
    public interface ITextMeter
    {
        double MeasureTextSize(string text, double width, double fontSize, string fontName = null);
        double MeasureTextWidth(string text, double fontSize, string fontName = null);
    }
}