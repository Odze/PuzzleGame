public class EnemyTurnState : BaseGameState {

    private Player player;
    private Enemy enemy;
    private int moves = 0;
    private int maxMoves = 2;

    public override void BaseStart(Game game) {
        this.player = game.Player;
        this.enemy = game.Enemy;
        enemy.moveEnded = false;
    }

    public override void BaseUpdate(Game game) {
        if (enemy.IsMoving || game.GameEnded) return;
        if (enemy.IsPlayerFinded) game.EndGame(false);

        if(moves < maxMoves) {
            MovePlayer();
            return;
        }

        if (moves >= maxMoves) game.ChangeState(game.PlayerTurnState);
    }

    public override void BaseFixedUpdate() {
        enemy.Move();
        enemy.Undo();
    }

    public override void BaseExit(Game game) {
        moves = 0;
    }

    private void MovePlayer() {
        var playerPosition = player.Position;
        var enemyPosition = enemy.Position;

        if (playerPosition == enemyPosition) return;

        if (playerPosition.x != enemyPosition.x) {

            if (enemyPosition.x < playerPosition.x) {
                enemy.MoveRight();
            } else {
                enemy.MoveLeft();
            }
        } else {
            if (enemyPosition.y < playerPosition.y) {
                enemy.MoveUp();
            } else {
                enemy.MoveDown();
            }
        }

        moves++;
    }
}
