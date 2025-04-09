namespace OOPConsoleGameProject;

public interface IItemPrint
{
    public void PrintItem(Item item, int index);
    public void PrintEmptyItem(int index);
    public void PrintItemInfo(Item item);
}