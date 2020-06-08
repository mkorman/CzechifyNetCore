namespace CzechifyNetCore.Services
{
    public interface ILanguageAdapter
    {
        string Title { get; }
        string Adapt(string text);
    }
}
