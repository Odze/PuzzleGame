using UnityEngine;

public class InputReader : MonoBehaviour {

    public bool Up { get; private set; }
    public bool Down { get; private set; }
    public bool Left { get; private set; }
    public bool Right { get; private set; }

    public bool Skip { get; private set; }

    public bool AnyKeyDown => Input.anyKeyDown;

    public void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            Up = true;
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            Down = true;
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            Left = true;
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            Right = true;
        } else if (Input.GetKeyDown(KeyCode.S)) {
            Skip = true;
        }
    }

    public void Reset() {
        Up = false;
        Down = false;
        Left = false;
        Right = false;
        Skip = false;
    }
}
