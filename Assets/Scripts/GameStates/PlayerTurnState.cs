public class PlayerTurnState : BaseGameState {

    private Player player;
    private Enemy enemy;
    private InputReader input;

    public override void BaseStart(Game game) {
        player = game.Player;
        enemy = game.Enemy;
        input = game.Input;

        game.SetUndoButtonActive(true);
        player.moveEnded = false;
    }

    public override void BaseUpdate(Game game) {
        if (game.GameEnded) return;

        if (player.moveEnded) {
            if (player.Victory) {
                game.LevelUp();
                game.EndGame(true);
                input.Reset();
            } else {
                game.ChangeState(game.EnemyTurnState);
            }
        }
        
        if (player.IsMoving) return;

        if (input.Up) {
            player.MoveUp();
        } else if (input.Down) {
            player.MoveDown();
        } else if (input.Left) {
            player.MoveLeft();
        } else if (input.Right) {
            player.MoveRight();
        } else  if (input.Skip) {
            player.Skip();
            game.ChangeState(game.EnemyTurnState);
        }

        input.Reset();

    }

    public override void BaseFixedUpdate() {
        player.Move();
        player.Undo();
        enemy.Undo();
    }

    public override void BaseExit(Game game) {
        input.Reset();
        game.SetUndoButtonActive(false);
    }
}
