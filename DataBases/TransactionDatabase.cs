using SQLite;

using Proyecto3_pago.DataBases.Models;

namespace Proyecto3_pago.DataBases;

public class TransactionDatabase
  
    SQLiteAsyncConnection database;

    async Task Init()
    {
        if (database is not null)
            return;

        database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        var result = await database.CreateTableAsync<User>();
        var result2 = await database.CreateTableAsync<Transaction>();
    }

    public async Task<List<User>> GetUsersAsync()
    {
        await Init();
        return await database.Table<User>().ToListAsync();
    }

    public async Task<User> GetUserAsync(int id)
    {
        await Init();
        return await database.Table<User>().Where(i => i.ID == id).FirstOrDefaultAsync();
    }

    public async Task<int> SaveUserAsync(User user)
    {
        await Init();
        if (user.ID != 0)
        {
            return await database.UpdateAsync(user);
        }
        else
        {
            return await database.InsertAsync(user);
        }
    }

    public async Task<int> DeleteUserAsync(User user)
    {
        await Init();
        return await database.DeleteAsync(user);
    }

    public async Task<List<Transaction>> GetTransactionsAsync()
    {
        await Init();
        return await database.Table<Transaction>().ToListAsync();
    }

    public async Task<Transaction> GetTransactionAsync(int id)
    {
        await Init();
        return await database.Table<Transaction>().Where(i => i.ID == id).FirstOrDefaultAsync();
    }

    public async Task<List<Transaction>> GetTransactionsByUserAsync(int userId)
    {
        await Init();
        return await database.Table<Transaction>().Where(i => i.UserId == userId).ToListAsync();
    }
    public async Task<int> SaveTransactionAsync(Transaction transaction)
    {
        await Init();
        if (transaction.ID != 0)
        {
            var result = await database.UpdateAsync(transaction);
            if (result == 0) return result;

            var user = await database
                .Table<User>()
                .Where(u => u.ID == transaction.UserId)
                .FirstOrDefaultAsync();
            if (user != null)
            {
                if (transaction.IsEarning) user.Earnings += transaction.Amount;
                else user.Spending += transaction.Amount;
                var amountUpdateResult = await database.UpdateAsync(user);
                return amountUpdateResult;
            }
            return 0;
        }
        else
        {
            var result = await database.InsertAsync(transaction);
            if (result == 0) return result;

            var user = await database
                .Table<User>()
                .Where(u => u.ID == transaction.UserId)
                .FirstOrDefaultAsync();
            if (user != null)
            {
                if (transaction.IsEarning) user.Earnings += transaction.Amount;
                else user.Spending += transaction.Amount;
                var amountUpdateResult = await database.UpdateAsync(user);
                return amountUpdateResult;
            }
            return 0;
        }
    }

    public async Task<int> DeleteTransactionAsync(Transaction transaction)
    {
        await Init();
        return await database.DeleteAsync(transaction);
    }
}
