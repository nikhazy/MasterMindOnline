using DatabaseProject;

namespace DatabaseProject
{
    public class DatabaseHandler
    {
        private readonly DatabaseContext _dbContext;

        public DatabaseHandler(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
            CreateDefaulPlayers();
        }

        private void CreateDefaulPlayers()
        {
            if(_dbContext.Players.Count() == 0)
            {
                Player marci = new Player()
                {
                    PlayerName = "Márk"
                };
                Player dorka = new Player()
                {
                    PlayerName = "Dorka"
                };
                _dbContext.Players.Add(marci);
                _dbContext.Players.Add(dorka);
                _dbContext.SaveChanges();
            }
        }

        public void AddNewStep(MasterMindGameStep step)
        {
            _dbContext.GameSteps.Add(step);
            _dbContext.SaveChanges();
        }

        public List<MasterMindGameStep> LoadCurrentGame(string playerName, int gameIndex)
        {
            var result = _dbContext.GameSteps.Where(x => x.PlayerName == playerName && x.CurrentGameIndex == gameIndex);
            return result.ToList();
        }




        public List<Player> GetAllPlayers()
        {
            return _dbContext.Players.ToList();
        }
        public void UpdatePlayer(Player player)
        {
            _dbContext.Players.Update(player);
            _dbContext.SaveChanges();
        }

    }
}
