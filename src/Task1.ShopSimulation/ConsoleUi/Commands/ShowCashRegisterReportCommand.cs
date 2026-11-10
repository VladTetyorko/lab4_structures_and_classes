namespace Task1.ShopSimulation.ConsoleUi.Commands;

using Menu;
using Shopping;
using Views;

internal sealed class ShowCashRegisterReportCommand : IMenuCommand
{
    private const string CommandTitle = "Cash register report";

    private readonly IShop _shop;
    private readonly IShopView _view;

    public ShowCashRegisterReportCommand(IShop shop, IShopView view)
    {
        _shop = shop;
        _view = view;
    }

    public string Title => CommandTitle;

    public void Execute() => _view.ShowReport(_shop.GetCashRegisterReport());
}
