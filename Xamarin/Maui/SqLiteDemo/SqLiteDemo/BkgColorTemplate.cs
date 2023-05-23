using System.Collections;

namespace SqLiteDemo
{
    public class BkgColorTemplate : DataTemplateSelector
    {
        public DataTemplate unoTemplate { get; set; }
        public DataTemplate dueTemplate { get; set; }

        // it alternately selects one or two background colors as it fills the list
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var collectionView = (CollectionView)container;
            IList collection = (IList)collectionView.ItemsSource;
            var index = collection.IndexOf(item);
            return index % 2 == 0 ? unoTemplate : dueTemplate;
        }
    }
}
