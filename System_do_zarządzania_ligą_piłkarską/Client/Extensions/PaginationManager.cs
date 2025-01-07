using Microsoft.AspNetCore.Components;

namespace System_do_zarządzania_ligą_piłkarską.Client.Extensions
{
    public class PaginationManager
    {
        public int PageNumber { get; set; } = 1;
        public int PageIndex { get; set; } = 0;
        public int PageMax { get; set; }
        public int PageSize { get; set; } = 100;
        public int CollectionCount { get; set; } 

        public async Task GoToPage(int pageNumber, Func<Task<bool>> loadResources)
        {
            var previousPageNumber = PageNumber;
            PageNumber = pageNumber;

            bool hasData = await loadResources.Invoke();

            if (!hasData)
            {
                PageNumber = previousPageNumber;
                await loadResources.Invoke();
            }
        }

        public async Task PreviousPage(Func<Task> loadResources)
        {
            if (PageNumber > 1)
            {
                PageNumber--;
                if (PageNumber % 5 == 0)
                    PageIndex -= 5;

                await loadResources.Invoke();
            }
        }

        public async Task NextPage(Func<Task<bool>> loadResources)
        {
            PageNumber++;
            if (PageNumber % 5 == 1)
                PageIndex += 5;

            bool hasData = await loadResources.Invoke();

            if (!hasData)
            {
                PageNumber--;
                if (PageNumber % 5 == 0)
                    PageIndex -= 5;

                await loadResources.Invoke();
            }
        }
    }
}
