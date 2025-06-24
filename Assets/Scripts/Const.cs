using UnityEngine;

public static class Const
{
    public static float camHeight => Camera.main.orthographicSize * 2f;
    public static float camWidth => camHeight * Camera.main.aspect;
    public static float rightEdge => Camera.main.transform.position.x + camWidth / 2f;

    public static float POS_MAX_X => rightEdge - 0.8f;
    public static float POS_MIN_X => -rightEdge + 0.8f;

    public const float SPEED_SCROLL = 0.1f;
    public const float SPEED_MOVE = 7f;
    public const float SPEED_MOVE_BULLET = 10f;
    public const float POS_MAX_Y = 6.2f;
    public const float POS_MIN_Y = -6.2f;
}