namespace BookStore.Handler
{
    public interface IMainHandler
    {
        object Handle(object sender, string type, string act);
    }
}