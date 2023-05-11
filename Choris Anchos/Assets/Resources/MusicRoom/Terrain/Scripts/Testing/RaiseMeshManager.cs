using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Place this script on a Gameobject that has multiple Raise Mesh scripts on it to change the height off all children at once
/// </summary>
public class RaiseMeshManager : MonoBehaviour
{
    [SerializeField]
    [Min(0)]
    public float childHeight = 0.5f;
    [SerializeField]
    public Transform playerPos;
    [SerializeField]
    Vector3 posOld = new(0, 0, 0);
    [SerializeField]
    RaiseMesh[] raiseMeshes;
    // Start is called before the first frame update
    void Start()
    {
        if (raiseMeshes.Length == 0)
        {
            raiseMeshes = GetComponentsInChildren<RaiseMesh>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool updateHeight = false;
        if (posOld != playerPos.position)
        {
            updateHeight = true;
            print("posOld != playerPos.position");
        }
        else
        {
            foreach (RaiseMesh raiseMesh in raiseMeshes)
            {
                if (raiseMesh.raiseAmount != childHeight)
                {
                    updateHeight = true;
                    break;
                }
            }
        }



        if (updateHeight)
        {
            //childHeight = raiseMeshes[0].raiseAmount;
            foreach (RaiseMesh raiseMesh in raiseMeshes)
            {
                raiseMesh.raiseAmount = childHeight;
                raiseMesh.playerPos = playerPos;
                posOld = playerPos.position;
            }
        }

    }

}