namespace GeekLearning.Templating
{
    using Storage;

    public interface ITemplateLoaderFactory
    {
        ITemplateLoader Create(IStore store);
    }
}
