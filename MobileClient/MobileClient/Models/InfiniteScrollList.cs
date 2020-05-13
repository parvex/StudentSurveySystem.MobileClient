using System.Collections.Generic;
using Xamarin.Forms.Extended;

namespace MobileClient.Models
{
    public class InfiniteScrollList<T> : InfiniteScrollCollection<T>, IInfiniteScrollDetector
    {
        private bool lastLoadWasEmpty;
        private int lastCount;

        public InfiniteScrollList(int pageSize)
        {
            OnBeforeLoadMore = BeforeLoadMore;
            OnAfterLoadMore = AfterLoadMore;
        }

        public InfiniteScrollList(IEnumerable<T> collection, int pageSize)
          : base(collection)
        {
            OnBeforeLoadMore = BeforeLoadMore;
            OnAfterLoadMore = AfterLoadMore;
        }

        private void BeforeLoadMore()
        {
            lastCount = Count;
        }

        private void AfterLoadMore()
        {
            lastLoadWasEmpty = lastCount == Count;
        }

        public bool ShouldLoadMore(object currentItem)
        {
            if (Count == 0)
                return true;

            //It's last item and there are more items to load
            return !lastLoadWasEmpty && this[Count - 1].Equals(currentItem);
        }
    }
}
