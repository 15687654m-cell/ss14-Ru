using Content.Server.EUI;
using Content.Shared.Eui;
using Content.Shared.ERP.UI;
using Content.Shared.Humanoid;
using Robust.Shared.IoC;
using Robust.Shared.GameObjects;

namespace Content.Server.ERP;

public sealed class ErpPanelEui : BaseEui
{
    private readonly IEntityManager _entityManager;
    private readonly SharedHumanoidAppearanceSystem _humanoidSystem;

    public ErpPanelEui()
    {
        _entityManager = IoCManager.Resolve<IEntityManager>();
        _humanoidSystem = IoCManager.Resolve<IEntitySystemManager>()
            .GetEntitySystem<SharedHumanoidAppearanceSystem>();
    }

    public override EuiStateBase GetNewState()
    {
        return new ErpPanelEuiState(GetStatusOrFallback());
    }

    public override void HandleMessage(EuiMessageBase msg)
    {
        base.HandleMessage(msg);

        if (msg is not ErpPanelStatusMessage statusMessage)
            return;

        if (Player.AttachedEntity is not { } playerEntity)
            return;

        if (!_entityManager.TryGetComponent(playerEntity, out HumanoidAppearanceComponent? humanoid))
            return;

        _humanoidSystem.SetStatus(playerEntity, statusMessage.Status, humanoid: humanoid);
        StateDirty();
    }

    private Status GetStatusOrFallback()
    {
        if (Player.AttachedEntity is not { } playerEntity)
            return Status.No;

        if (!_entityManager.TryGetComponent(playerEntity, out HumanoidAppearanceComponent? humanoid))
            return Status.No;

        return humanoid.Status;
    }
}
