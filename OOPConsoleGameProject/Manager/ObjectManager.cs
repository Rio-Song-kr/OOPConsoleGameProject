namespace OOPConsoleGameProject;

public class ObjectManager
{
    private static ObjectManager _instance;
    private Dictionary<string, Item> _itemPools;
    private Dictionary<(string, int), FieldObject> _fieldObjectPools;

    private ObjectManager()
    {
        _itemPools = new Dictionary<string, Item>();
        _fieldObjectPools = new Dictionary<(string, int), FieldObject>();
    }

    public static ObjectManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new ObjectManager();
        }
        return _instance;
    }

    public void AddItem(Item item) { _itemPools[item.Name] = item; }
    public void RemoveItem(Item item) { _itemPools.Remove(item.Name); }
    public Item GetItem(string name)
    {
        if (_itemPools.ContainsKey(name))
        {
            return _itemPools[name];
        }
        return null;
    }

    public void AddFieldObject(FieldObject fieldObject)
    {
        _fieldObjectPools[(fieldObject.Name, fieldObject.Index)] = fieldObject;
    }

    public void RemoveFieldObject(FieldObject fieldObject)
    {
        _fieldObjectPools.Remove((fieldObject.Name, fieldObject.Index));
    }

    public FieldObject GetFieldObject(string name, int index)
    {
        if (_fieldObjectPools.ContainsKey((name, index)))
        {
            return _fieldObjectPools[(name, index)];
        }
        return null;
    }
}