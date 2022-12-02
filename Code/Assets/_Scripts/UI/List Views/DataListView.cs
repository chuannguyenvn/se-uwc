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
}