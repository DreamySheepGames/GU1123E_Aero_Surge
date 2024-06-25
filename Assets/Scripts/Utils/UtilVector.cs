using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilVector : MonoBehaviour
{
    public static Vector2 RotateVector2(Vector2 originalVector, float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        float cos = Mathf.Cos(radian);
        float sin = Mathf.Sin(radian);

        float newX = originalVector.x * cos - originalVector.y * sin;
        float newY = originalVector.x * sin + originalVector.y * cos;

        return new Vector2(newX, newY);
    }
}
