namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia.Result {
    public class EntryPointResult : ResourceResult {
        public EntryPointResult(string userName, string userEmail) {
            UserProfile = new UserProfileResult(userName, userEmail);
        }

        public override string Profile => "entry-point";
        public UserProfileResult UserProfile { get; }
    }
}