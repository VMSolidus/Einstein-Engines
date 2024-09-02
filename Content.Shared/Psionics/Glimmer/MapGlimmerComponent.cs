namespace Content.Shared.Psionics.Glimmer;

[RegisterComponent]
public sealed partial class MapGlimmerComponent : Component
{
    private int _glimmer = 0;
    public int Glimmer
    {
        get { return _glimmer; }
        set { _glimmer = _enabled ? Math.Clamp(value, 0, 1000) : 0; }
    }
    private bool _enabled;
}

