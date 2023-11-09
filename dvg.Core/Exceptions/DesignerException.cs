namespace dvg.Core.Exceptions
{
    public class DesignerException : Exception
    {
        public DesignerException(string message, Exception inner)
            :base(message, inner)
        {

        }
    }
}
