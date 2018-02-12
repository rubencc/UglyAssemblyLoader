namespace UglyLoader.Unit.Test
{
    public class ToLoadInTest : IToLoadInTest
    {
        public int Execute()
        {
            return 88998899;
        }
    }

    public interface IToLoadInTest
    {
        int Execute();
    }
}