using UnityEngine;

public class Enemy : Opponent {

    public bool IsPlayerFinded { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag.Equals("Block")) currentLevelBlock = collision.gameObject.GetComponent<LevelBlock>();
        if (collision.gameObject.tag.Equals("Player")) IsPlayerFinded = true;
    }
}
