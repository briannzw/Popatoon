using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaMovement : MonoBehaviour
{
    private Character character;

    [Header("Movement")]
    public float moveSpeed = 2;
    public float moveRange = 5;

    int moveDirection = 0;

    private void Start()
    {
        character = GetComponent<Character>();
    }

    #region Methods

    public void Move(int _moveDirection)
    {
        //if still moving
        if (moveDirection == 0)
        {
            moveDirection = _moveDirection;
            character.SetCharaAnimationState(CharaState.Walk);
            StartCoroutine(ToPosition(transform.position + new Vector3(moveDirection * moveRange, 0f, 0f), moveSpeed));
        }
    }

    public void MoveTo(Vector2 target)
    {
        if (moveDirection == 0)
        {
            character.SetCharaAnimationState(CharaState.Walk);
            StartCoroutine(ToPosition(target, moveSpeed));
        }
    }

    private void ResetMovement()
    {
        character.SetCharaAnimationState(CharaState.Idle);
        moveDirection = 0;
        character.MoveDone();
    }
    #endregion

    #region IEnumerators
    IEnumerator ToPosition(Vector3 targetPosition, float speed)
    {
        Vector3 startPosition = transform.position;
        float step = (speed / (startPosition - targetPosition).magnitude) * Time.fixedDeltaTime;
        float t = 0;
        while (t < 1.0f)
        {
            t += step;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return new WaitForFixedUpdate();
        }
        transform.position = targetPosition;

        ResetMovement();
    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;

        ResetMovement();
    }
    #endregion
}
