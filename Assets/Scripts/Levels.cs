using UnityEngine;

[CreateAssetMenu(fileName = "Levels", menuName = "Scriptable Objects/Levels", order = 10000)]
public class Levels : ScriptableObject {

    public int currentLevel;

    [Space(10)]
    public GameObject[] levels;

    [Space (10)]
    [SerializeField] private string[] levelsInfo;

    [Space(10)]
    [SerializeField] private string[] levelsTip;

    public Level LoadLevel(Transform spawnArea) {
        return Instantiate(levels[currentLevel],  spawnArea).GetComponent<Level>();
    }

    public string LoadInfo() {
        return levelsInfo[currentLevel];
    }

    public string LoadTip() {
        return levelsTip[currentLevel];
    }
}
