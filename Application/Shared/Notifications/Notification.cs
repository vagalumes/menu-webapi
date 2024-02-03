using FluentValidation.Results;

namespace Application.Shared.Notifications
{
    public sealed class Notification
    {
        private readonly IDictionary<string, IList<string>> ErrorMessages = new Dictionary<string, IList<string>>();

        public bool IsInvalid => ErrorMessages.Any();

        public IDictionary<string, IList<string>> GetErrorMessages() => ErrorMessages;

        public void AddErrorMessage(string key, string message)
        {
            if (!ErrorMessages.ContainsKey(key))
            {
                ErrorMessages[key] = new List<string>();
            }
            ErrorMessages[key].Add(message);
        }

        public override string ToString() => string.Join(' ', ErrorMessages.SelectMany(x => x.Value));

        public void AddErrorMessages(ValidationResult result)
        {
            if (result.IsValid)
                return;

            foreach (var error in result.Errors)
            {
                AddErrorMessage(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
