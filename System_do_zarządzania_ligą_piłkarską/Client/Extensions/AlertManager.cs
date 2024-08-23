namespace System_do_zarządzania_ligą_piłkarską.Client.Extensions
{
    public class AlertManager
    {
        public string AlertMessage { get; set; } = string.Empty;
        public string AlertType { get; set; } = string.Empty;
        public bool AlertVisibility { get; set; } = false;

        public void ShowAlert(string message, string type)
        {
            AlertMessage = message;
            AlertType = type;
            AlertVisibility = true;
        }
    }
}
