using UnityEngine;

public class Level : MonoBehaviour {

    [SerializeField] private GameObject playerStartBlock;
    [SerializeField] private GameObject enemyStartBlock;

    public Vector3 PlayerStartPosition => playerStartBlock.transform.position;
    public Vector3 EnemyStartPostion => enemyStartBlock.transform.position;
}
