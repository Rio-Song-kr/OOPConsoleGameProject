namespace OOPConsoleGameProject;

public interface IItemPrint
{
    public void PrintItem(Item item, int index);
    public void PrintEmptyItem(int index);
    //todo 아이템 선택 시 정보 보여주는 것 추가해야 함
}