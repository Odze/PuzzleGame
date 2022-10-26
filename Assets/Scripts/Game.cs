using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    [SerializeField] private Levels levels;
    [SerializeField] private Transform levelSpawn;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform playerSpawn;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform enemySpawn;

    [Space (10)]
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private TextMeshProUGUI levelLabel;
    [SerializeField] private Button UndoButton;
    [SerializeField] private TextMeshProUGUI levelInfo;
    [SerializeField] private GameObject tipHide;
    [SerializeField] private TextMeshProUGUI levelsTip;

    [Space(10)]
    [SerializeField] private InputReader input;

    private Level level;
    private Player player;
    private Enemy enemy;

    private BaseGameState currentState;
    private PlayerTurnState playerTurnState = new PlayerTurnState();
    private EnemyTurnState enemyTurnState = new EnemyTurnState();

    public Player Player => player;
    public Enemy Enemy => enemy;
    public PlayerTurnState PlayerTurnState => playerTurnState;
    public EnemyTurnState EnemyTurnState => enemyTurnState;
    public Levels Levels => levels;
    public InputReader Input => input;
    
    public bool GameEnded { get; private set; }

    private void Start() {
        LoadLevel();
    }

    private void Update() {
        currentState.BaseUpdate(this);

        if (!GameEnded) return;
        if (input.AnyKeyDown) {
            LoadLevel();
            GameEnded = false;
        }
    }

    private void FixedUpdate() {
        currentState.BaseFixedUpdate();
    }

    public void LoadLevel() {
        currentState = playerTurnState;
        losePanel.SetActive(false);
        victoryPanel.SetActive(false);
        SetTipActive(true);

        levelSpawn.DestroyAllChildren();
        playerSpawn.DestroyAllChildren();
        enemySpawn.DestroyAllChildren();

        level = levels.LoadLevel(levelSpawn);
        player = Instantiate(playerPrefab, level.PlayerStartPosition, Quaternion.identity, playerSpawn).GetComponent<Player>();
        enemy = Instantiate(enemyPrefab, level.EnemyStartPostion, Quaternion.identity, enemySpawn).GetComponent<Enemy>();

        levelLabel.text = $"Level {levels.currentLevel}";
        levelInfo.text = levels.LoadInfo();
        levelsTip.text = levels.LoadTip();

        currentState.BaseStart(this);
    }

    public void ChangeState(BaseGameState state) {
        currentState.BaseExit(this);
        currentState = state;
        currentState.BaseStart(this);
    }

    public void EndGame(bool victory) {
        losePanel.SetActive(!victory);
        victoryPanel.SetActive(victory);
        GameEnded = true;
    }

    public void LevelUp() {
        if (levels.levels.Length - 1 > levels.currentLevel) levels.currentLevel++;
    }

    public void LoadNextLevel() {
        LevelUp();
        LoadLevel();
    }

    public void LoadPreviusLevel() {
        if (levels.currentLevel > 0) levels.currentLevel--;
        LoadLevel();
    }

    public void UndoMove() {
        enemy.UndoMove(false);
        player.UndoMove(true);
    }

    public void SetUndoButtonActive(bool active) {
        UndoButton.interactable = active;
    }

    public void SetTipActive(bool isActive) {
        tipHide.SetActive(isActive);
    }
}
