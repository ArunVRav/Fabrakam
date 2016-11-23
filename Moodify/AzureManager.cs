using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moodify.DataModels;

namespace Moodify
{
    public class AzureManager
    {
        private static AzureManager instance;
        private MobileServiceClient client;
        private IMobileServiceTable<Orders> ordersTable;
        private IMobileServiceTable<logins> loginsTable;

        private AzureManager()
        {
            this.client = new MobileServiceClient("http://fabrikamarun1.azurewebsites.net");
            this.ordersTable = this.client.GetTable<Orders>();
            this.loginsTable = this.client.GetTable<logins>();
        }

        public MobileServiceClient AzureClientOrders
        {
            get { return client; }
        }

        public MobileServiceClient AzureClientLogins
        {
            get { return client; }
        }

        public static AzureManager AzureManagerInstanceOrders
        {
            get
            {
                if(instance == null)
                {
                    instance = new AzureManager();
                }

                return instance;
            }
        }

        public static AzureManager AzureManagerInstanceLogins
        {
            get
            {
                if (instance == null)
                {
                    instance = new AzureManager();
                }

                return instance;
            }
        }

        public async Task AddOrder(Orders order)
        {
            await this.ordersTable.InsertAsync(order);
        }

        public async Task AddLogin(logins login)
        {
            await this.loginsTable.InsertAsync(login);
        }

        public async Task<List<Orders>> GetOrders()
        {
            return await this.ordersTable.ToListAsync();
        }

        public async Task<List<logins>> GetLogins()
        {
            return await this.loginsTable.ToListAsync();
        }

        public async Task UpdateOrder(Orders order)
        {
            await this.ordersTable.UpdateAsync(order);
        }
    }

    
}
