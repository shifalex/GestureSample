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
            conn= new SQLiteConnection(_dbPath);
            conn.CreateTable<State>();
        }

        public List<State> GetStates()
        {
            conn = new SQLiteConnection(_dbPath);
            return conn.Table<State>().ToList();
        }

        public void Add(State s)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Insert(s);
        }
    }
}
