using Content.Shared.Eui;
using Content.Shared.Humanoid;
using Robust.Shared.Serialization;

namespace Content.Shared.ERP.UI;

[Serializable, NetSerializable]
public sealed class ErpPanelEuiState : EuiStateBase
{
    public Status Status;

    public ErpPanelEuiState(Status status)
    {
        Status = status;
    }
}

[Serializable, NetSerializable]
public sealed class ErpPanelStatusMessage : EuiMessageBase
{
    public Status Status;

    public ErpPanelStatusMessage(Status status)
    {
        Status = status;
    }
}
