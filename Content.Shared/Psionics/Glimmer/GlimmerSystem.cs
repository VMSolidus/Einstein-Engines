using Robust.Shared.Serialization;
using Robust.Shared.Configuration;
using Content.Shared.GameTicking;

namespace Content.Shared.Psionics.Glimmer;

/// <summary>
///     This handles setting / reading the value of glimmer.
/// </summary>
public sealed partial class GlimmerSystem : EntitySystem
{
    [Dependency] private readonly IConfigurationManager _cfg = default!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<RoundRestartCleanupEvent>(Reset);
        SubscribeLocalEvent<MapGlimmerComponent, ComponentInit>(OnMapStartup);
    }

    private void OnMapStartup(EntityUid uid, MapGlimmerComponent component, ComponentInit args)
    {

    }

    private void Reset(RoundRestartCleanupEvent args)
    {
        Glimmer = 0;
    }

    /// <summary>
    /// Return an abstracted range of a glimmer count.
    /// </summary>
    /// <param name="glimmer">What glimmer count to check. Uses the current glimmer by default.</param>
    public GlimmerTier GetGlimmerTier(int? glimmer = null)
    {
        if (glimmer == null)
            glimmer = Glimmer;

        return (glimmer) switch
        {
            <= 49 => GlimmerTier.Minimal,
            >= 50 and <= 99 => GlimmerTier.Low,
            >= 100 and <= 299 => GlimmerTier.Moderate,
            >= 300 and <= 499 => GlimmerTier.High,
            >= 500 and <= 899 => GlimmerTier.Dangerous,
            _ => GlimmerTier.Critical,
        };
    }
}

[Serializable, NetSerializable]
public enum GlimmerTier : byte
{
    Minimal,
    Low,
    Moderate,
    High,
    Dangerous,
    Critical,
}

