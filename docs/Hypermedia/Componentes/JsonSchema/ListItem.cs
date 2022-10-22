namespace Recuperos.RestApi.Infraestructura.Componentes.JsonSchema {
    public class ListItem {
        public object Key { get; }
        public string DisplayText { get; }

        public ListItem(object key, string displayText) {
            Key = key;
            DisplayText = displayText;
        }
    }
}