using System.Collections.Generic;

namespace ImageEditorApp.Iterators
{
    public interface IImageHistoryCollection
    {
        IEditHistoryIterator CreateIterator();
    }
}
