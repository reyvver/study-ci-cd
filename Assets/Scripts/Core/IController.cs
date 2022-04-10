namespace Core
{
    public interface IController
    {
        public void OnGameStarted();
        public void OnGameFinished();
        public void OnGameRestart();
    }
}