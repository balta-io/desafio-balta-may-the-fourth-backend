namespace MayTheFourth.Utils.Validation
{
    public class ValidationViewModel
    {
        private ValidationViewModel(ValidationModelResult result)
        {
            Result = result;
            Messages = [Properties.Resources.Success];
            Exceptions = [];
            Error = result != ValidationModelResult.Success;
        }

        private ValidationViewModel(ValidationModelResult result, string message)
        {
            Result = result;
            Messages = [message];
            Exceptions = [];
            Error = result != ValidationModelResult.Success;
        }

        private ValidationViewModel(ValidationModelResult result, string[] messages)
        {
            Result = result;
            Messages = messages;
            Exceptions = [];
            Error = result != ValidationModelResult.Success;
        }

        private ValidationViewModel(ValidationModelResult result, Exception[] exceptions)
        {
            Result = result;
            Messages = new string[exceptions.Length];
            for (int i = 0, length = Messages.Length; i < length; i++)
            {
                var ExceptionError = new[] {
                    exceptions[i].Message,
                    exceptions[i].InnerException?.Message ?? string.Empty,
                    exceptions[i].InnerException?.InnerException?.Message ?? string.Empty,
                };

                Messages[i] = string.Join("\r\n", ExceptionError.Where(string.IsNullOrEmpty));
            }

            Exceptions = exceptions;
            Error = result != ValidationModelResult.Success;
        }

        private ValidationViewModel(ValidationModelResult result, Exception exception)
        {
            Result = result;
            Messages = new string[1];
            for (int i = 0, length = Messages.Length; i < length; i++)
            {
                var ExceptionError = new[] {
                    exception.Message,
                    exception.InnerException?.Message ?? string.Empty,
                    exception.InnerException?.InnerException?.Message ?? string.Empty,
                };

                Messages[i] = string.Join("\r\n", ExceptionError.Where(string.IsNullOrEmpty));
            }

            Exceptions = [exception];
            Error = result != ValidationModelResult.Success;
        }

        public bool Error { get; private set; }
        public ValidationModelResult Result { get; private set; }
        public string[] Messages { get; private set; }
        public Exception[] Exceptions { get; private set; }

        public static ValidationViewModel Create(ValidationModelResult result) =>
            new ValidationViewModel(result);

        public static ValidationViewModel Create(ValidationModelResult result, string message) =>
            new ValidationViewModel(result, message);

        public static ValidationViewModel Create(ValidationModelResult result, string[] messages) =>
            new ValidationViewModel(result, messages);

        public static ValidationViewModel Create(ValidationModelResult result, Exception[] exceptions) =>
            new ValidationViewModel(result, exceptions);

        public static ValidationViewModel Create(ValidationModelResult result, Exception exception) =>
            new ValidationViewModel(result, exception);
    }
}
