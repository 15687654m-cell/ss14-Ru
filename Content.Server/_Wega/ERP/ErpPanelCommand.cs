using Content.Server.EUI;
using Robust.Shared.Console;

namespace Content.Server.ERP;

public sealed class ErpPanelCommand : IConsoleCommand
{
    [Dependency] private readonly EuiManager _euiManager = default!;

    public string Command => "erppanel";
    public string Description => Loc.GetString("erp-panel-command-description");
    public string Help => Loc.GetString("erp-panel-command-help");

    public void Execute(IConsoleShell shell, string argStr, string[] args)
    {
        if (shell.Player is not { } playerSession)
        {
            shell.WriteError(Loc.GetString("erp-panel-command-server"));
            return;
        }

        _euiManager.OpenEui(new ErpPanelEui(), playerSession);
    }
}
