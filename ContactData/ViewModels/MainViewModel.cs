using Microsoft.Phone.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactData.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private IList<Contact> contacts;

        /// <summary>
        /// Gets a list of the contacts.
        /// </summary>
        public IList<Contact> Contacts
        {
            get { return contacts; }
            private set { this.SetProperty(ref this.contacts, value); }
        }

        /// <summary>
        /// Loads the view model data.
        /// </summary>
        /// <returns></returns>
        public async Task LoadDataAsync()
        {
            var contactResult = await this.GetContactsAsync();
            this.Contacts = new List<Contact>(contactResult);
        }

        /// <summary>
        /// Returns a list of all contacts of the phone.
        /// </summary>
        /// <returns></returns>
        private Task<IEnumerable<Contact>> GetContactsAsync()
        {
            var tcs = new TaskCompletionSource<IEnumerable<Contact>>();
            Contacts contacts = new Contacts();

            EventHandler<ContactsSearchEventArgs> search = null;
            search = (s, e) =>
            {
                contacts.SearchCompleted -= search;
                tcs.TrySetResult(e.Results);
            };

            contacts.SearchCompleted += search;

            // Empty search filter for all contacts.
            contacts.SearchAsync(string.Empty, FilterKind.None, null);
            return tcs.Task;
        }
    }
}
