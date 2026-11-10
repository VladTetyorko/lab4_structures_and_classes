namespace Task1.ShopSimulation.ConsoleUi.Commands;

using Menu;
using Shopping;
using Views;

internal sealed class RestockShelvesCommand : IMenuCommand
{
    private const string CommandTitle = "Restock the shelves";

    private readonly IShop _shop;
    private readonly IShopView _view;

    public RestockShelvesCommand(IShop shop, IShopView view)
    {
        _shop = shop;
        _view = view;
    }

    public string Title => CommandTitle;

    public void Execute()
    {
        _shop.Restock();
        _view.ShowRestocked();
    }
}
