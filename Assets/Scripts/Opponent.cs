using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class Opponent : MonoBehaviour {

    [SerializeField] private float movementSpeed;

    private Vector3 movePosition;
    private bool isUndoing;
    private Vector3 undoPosition;

    [NonSerialized] public bool moveEnded;
    [NonSerialized] public LevelBlock currentLevelBlock;
    [NonSerialized] public List<Vector3> moves = new List<Vector3>();

    public Vector3 Position => transform.position;
    public bool IsMoving { get; private set; }

    public void MoveUp() {
        if (currentLevelBlock.BorderUp) return;
        SetMovingPosition(0f, 1f);
    }

    public void MoveDown() {
        if (currentLevelBlock.BorderDown) return;
        SetMovingPosition(0f, -1f);
    }

    public void MoveLeft() {
        if (currentLevelBlock.BorderLeft) return;
        SetMovingPosition(-1f, 0f);
    }

    public void MoveRight() {
        if (currentLevelBlock.BorderRight) return;
        SetMovingPosition(+1f, 0f);
    }

    public void Move() {
        if (!IsMoving) return;

        transform.position = Vector3.MoveTowards(transform.position, movePosition, movementSpeed * Time.deltaTime);

        if (transform.position != movePosition) return;

        IsMoving = false;
        moveEnded = true;
    }

    public void Undo() {
        if (!isUndoing) return;
        transform.position = Vector3.MoveTowards(transform.position, undoPosition, movementSpeed * Time.deltaTime);

        if (transform.position != undoPosition) return;
        isUndoing = false;
    }

    public void UndoMove(bool isPlayer) {
        var removeIndex = isPlayer ? 1 : 2;
        var moveIndex = moves.Count - removeIndex;
        if (moveIndex < 0) return;

        undoPosition = moves[moveIndex];
        moves.RemoveRange(moves.Count - removeIndex, removeIndex);
        isUndoing = true;
    }

    private void SetMovingPosition(float x, float y) {
        var position = transform.position;
        moves.Add(position);
        position.x += x;
        position.y += y;
        movePosition = position;

        IsMoving = true;
    }
}
