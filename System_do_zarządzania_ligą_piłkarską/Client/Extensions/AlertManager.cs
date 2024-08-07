namespace System_do_zarządzania_ligą_piłkarską.Client.Extensions
{
    public class AlertManager
    {
        public string alertMessage { get; set; } = string.Empty;
        public string alertType { get; set; } = string.Empty;
        public bool alertVisibility { get; set; } = false;

        public void ShowAlert(string message, string type)
        {
            alertMessage = message;
            alertType = type;
            alertVisibility = true;
        }
    }
}
