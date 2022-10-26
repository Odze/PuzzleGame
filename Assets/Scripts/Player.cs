using UnityEngine;

public class Player : Opponent {

    public bool Victory => currentLevelBlock.isVictoryBlock;


    public void Skip() {
        moves.Add(transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag.Equals("Block")) {
            currentLevelBlock = collision.gameObject.GetComponent<LevelBlock>();
        }
    }
}
