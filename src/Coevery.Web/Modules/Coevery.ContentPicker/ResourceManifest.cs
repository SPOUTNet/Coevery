using Coevery.UI.Resources;

namespace Coevery.ContentPicker {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();
            manifest.DefineScript("ContentPicker").SetUrl("ContentPicker.js", "ContentPicker.js").SetDependencies("jQuery");
        }
    }
}
