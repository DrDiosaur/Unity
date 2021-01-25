using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ways : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Up;
    public bool Right;
    public bool Down;
    public bool Left;

    public bool ReturnUp()
    {
        return Up;
    }
    public bool ReturnRight()
    {
        return Right;
    }
    public bool ReturnDown()
    {
        return Down;
    }
    public bool ReturnLeft()
    {
        return Left;
    }
}
