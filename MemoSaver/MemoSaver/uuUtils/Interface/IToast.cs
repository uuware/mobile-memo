namespace uuUtils
{
    /*
     Use:
     DependencyService.Get<IToast>().Show("Password is wrong.");
    */
    public interface IToast
    {
        void Show(string message);
    }
}