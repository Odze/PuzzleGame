using UnityEngine;

public class LevelBlock : MonoBehaviour {

    [SerializeField] private bool victoryBlock;
    [SerializeField] private bool borderUp;
    [SerializeField] private bool borderDown;
    [SerializeField] private bool borderLeft;
    [SerializeField] private bool borderRight;

    [Space(10)]
    [SerializeField] private GameObject victoryBlockIcon;
    [SerializeField] private GameObject borderUpLine;
    [SerializeField] private GameObject borderDownLine;
    [SerializeField] private GameObject borderRightLine;
    [SerializeField] private GameObject borderLeftLine;

    public bool isVictoryBlock => victoryBlock;
    public bool BorderUp => borderUp;
    public bool BorderDown => borderDown;
    public bool BorderLeft => borderLeft;
    public bool BorderRight => borderRight;

    private void Start() {
        victoryBlockIcon.SetActive(victoryBlock);
        borderUpLine.SetActive(BorderUp);
        borderDownLine.SetActive(BorderDown);
        borderRightLine.SetActive(BorderRight);
        borderLeftLine.SetActive(BorderLeft);
    }
}
