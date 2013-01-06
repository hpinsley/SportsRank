using System.Collections.Generic;

namespace ScoreParser {
    public interface IGameManager {
        int Count { get; }
        void AddMultiple(string[] lines);
        IEnumerable<Game> GetGames();
    }
}