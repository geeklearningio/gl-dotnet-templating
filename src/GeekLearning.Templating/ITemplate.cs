namespace GeekLearning.Templating
{
    public interface ITemplate
    {
        string Apply(object context);
    }
}
