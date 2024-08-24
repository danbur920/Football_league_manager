using Microsoft.AspNetCore.Components;

namespace System_do_zarządzania_ligą_piłkarską.Client.Extensions
{
    public class PaginationManager
    {
        public int PageNumber { get; set; } = 1;
        public int PageIndex { get; set; } = 0;

        public async Task GoToPage(int pageNumber, Func<Task> loadResources)
        {
            PageNumber = pageNumber;
            await loadResources.Invoke();
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

        public async Task NextPage(Func<Task> loadResources)
        {
            PageNumber++;
            if (PageNumber % 5 == 1)
                PageIndex += 5;

            await loadResources.Invoke();
        }
    }
}
