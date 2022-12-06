public abstract class DataListView<T> : ListView where T : Data
{
    protected DataListItemView<T> prefab;
    
    public void AddDataItem(T data)
    {
        var itemView = Instantiate(prefab, scrollRect.content.transform)
            .GetComponent<DataListItemView<T>>();
        itemView.SetData(data);
        
        AddItem(itemView);
    }

    public void RemoveDataItem(T data)
    {
        foreach (var itemView in itemViews)
        {
            if (itemView is not DataListItemView<T> dataListItemView) continue;
            if (data != dataListItemView.Data) continue;
            RemoveItem(itemView);
            return;
        }
    }
}