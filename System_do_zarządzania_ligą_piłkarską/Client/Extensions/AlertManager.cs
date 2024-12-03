namespace System_do_zarządzania_ligą_piłkarską.Client.Extensions
{
    public class AlertManager
    {
        public string Message { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public bool IsVisible { get; set; } = false;

        public void DisplayAlert(string message, string type)
        {
            IsVisible = true;
            Message = message;
            Type = type;
        }
    }
}
