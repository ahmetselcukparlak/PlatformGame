public interface IAnimatorService
{
    public void Set(string name);
    public void Set(string name, bool state);
    public void ResetTrigger(string name);
}