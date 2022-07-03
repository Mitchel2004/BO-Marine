using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterTurnUI : MonoBehaviour
{
    public int _rotationSpeed = 15;

    void Update()
    {

        // Rotation on y axis
        // be sure to capitalize Rotate or you'll get errors
        transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
    }
}
