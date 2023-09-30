using ComicShop.Core;
using SQLite;

namespace ComicShopBox.Database;

internal static class ComicShopBoxDatabase
{
    public static string FileName = "ComicShopBox.db";
    public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, FileName);
    public const SQLite.SQLiteOpenFlags Flags =
       // open the database in read/write mode
       SQLite.SQLiteOpenFlags.ReadWrite |
       // create the database if it doesn't exist
       SQLite.SQLiteOpenFlags.Create |
       // enable multi-threaded database access
       SQLite.SQLiteOpenFlags.SharedCache;
}

internal static class ComicShopBoxDatabaseService
{
    static SQLiteAsyncConnection db;
    static async Task Init()
    {
        try
        {
            if (db != null)
                return;
            db = new SQLiteAsyncConnection(ComicShopBoxDatabase.DatabasePath, ComicShopBoxDatabase.Flags);

            await db.CreateTableAsync<ComicMetaData>();
            await db.CreateTableAsync<Comic>();
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }

    }

    public static async Task<int> NumberOfComics()
    {
        await Init();
        return await db.Table<Comic>().CountAsync();
    }

    public static async Task<List<Comic>> GetComics()
    {
        await Init();
        return await db.Table<Comic>().ToListAsync();
    }

    public static async Task SaveComic(List<Comic> comics)
    {
        var number =  await db.InsertAllAsync(comics);
        return;
    }
}