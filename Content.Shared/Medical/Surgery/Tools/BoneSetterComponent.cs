using Robust.Shared.GameStates;

namespace Content.Shared.Medical.Surgery.Tools;

[RegisterComponent, NetworkedComponent]
public sealed partial class BoneSetterComponent : Component, ISurgeryToolComponent
{
    public string ToolName => "a bone setter";
    public bool? Used { get; set; } = null;
    [DataField]
    public float Speed { get; set; } = 1f;
}