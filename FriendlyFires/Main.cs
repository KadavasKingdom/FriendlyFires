using FriendlyFires.Handlers;
using LabApi.Events.CustomHandlers;
using LabApi.Loader.Features.Plugins;

namespace FriendlyFires;

public sealed class Main : Plugin<Config>
{
    public static Main Instance { get; private set; }
    public override string Name => "Friendly Fires";

    public override string Description => "Enable friendly fires for certain classes";

    public override string Author => "SlejmUr";

    public override Version Version => new(0, 0, 1);

    public override Version RequiredApiVersion => LabApi.Features.LabApiProperties.CurrentVersion;

    private readonly FFHandler Handler = new();

    public override void Disable()
    {
        Instance = null;
        CustomHandlersManager.UnregisterEventsHandler(Handler);
    }

    public override void Enable()
    {
        Instance = this;
        CustomHandlersManager.RegisterEventsHandler(Handler);
    }
}
