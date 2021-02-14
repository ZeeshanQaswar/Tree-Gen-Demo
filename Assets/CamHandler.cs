using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamHandler : MonoBehaviour
{

    public Transform defaultPivot;
    public Transform currentPivot;
    public Vector3 treeOffset;
    public Vector3 branchOffset;

    CinemachineVirtualCamera _cineMachine;

    private void Start()
    {
        
    }

    public void UpdatePivot(Transform pivot)
    {
        _cineMachine.Follow = pivot;
        _cineMachine.LookAt = pivot;
    }

}
