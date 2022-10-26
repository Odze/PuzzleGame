public abstract class BaseGameState {
    public abstract void BaseStart(Game game);
    public abstract void BaseUpdate(Game game);
    public abstract void BaseFixedUpdate();
    public abstract void BaseExit(Game game);
}
