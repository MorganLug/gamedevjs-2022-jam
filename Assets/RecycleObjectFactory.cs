using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RecycleObjectFactory : MonoBehaviour
{
    public static GameObject generateObject()
    {
        GameObject[] gameObjects = Resources.LoadAll<GameObject>("");
        return gameObjects[Random.Range(0, gameObjects.Length)];
    }
}
