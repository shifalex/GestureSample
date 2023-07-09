using GestureSample.Maui.Models;
using SQLite;
namespace GestureSample.Maui.Data
{
    public class StateConnection
    {
        string _dbPath;
        private SQLiteConnection conn;

        public StateConnection(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void Init()
        {
            if (conn is not null) return;
            conn= new SQLiteConnection(_dbPath);
            conn.CreateTable<State>();
        }

        public List<State> GetStates()
        {
            Init();
            return conn.Table<State>().ToList();
        }

        public void Add(State s)
        {
            Init();
            conn.Insert(s);
        }
    }
}
