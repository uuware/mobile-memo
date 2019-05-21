namespace uuUtils
{
    public interface IDependDevice
    {
        string GetPackageName();
        string GetDocumentPath();
        string GetDownloadPath();
        void OutPutLog(string path, string err);
        void KeepScreenOn(bool isKeep);
    }
}