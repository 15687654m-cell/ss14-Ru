using Content.Client.Eui;
using Content.Shared.Eui;
using Content.Shared.ERP.UI;

namespace Content.Client._Wega.ERP.UI;

public sealed class ErpPanelEui : BaseEui
{
    private readonly ErpPanelWindow _window;

    public ErpPanelEui()
    {
        _window = new ErpPanelWindow();
        _window.OnClose += () => SendMessage(new CloseEuiMessage());
        _window.StatusSelected += status => SendMessage(new ErpPanelStatusMessage(status));
    }

    public override void Opened()
    {
        _window.OpenCentered();
    }

    public override void Closed()
    {
        _window.Close();
    }

    public override void HandleState(EuiStateBase state)
    {
        if (state is not ErpPanelEuiState cast)
            return;

        _window.UpdateState(cast);
    }
}
