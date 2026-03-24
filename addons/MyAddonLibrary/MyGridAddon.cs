using BlazingStory.Addons;

namespace MyAddonLibrary;

public class MyGridAddon : IAddon
{
    public void Initialize(IAddonBuilder builder)
    {
        builder.AddToolbarContent<MyGridToolbar>(order: 1000,
            match: viewMode => viewMode == ViewMode.Story);
        builder.AddPreviewDecorator<MyGridDecorator>();
    }
}
