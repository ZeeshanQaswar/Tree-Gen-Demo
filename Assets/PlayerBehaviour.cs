using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public float animSpeed = 1;
    public bool enableInteraction;
    public SkinnedMeshRenderer trunk;

    private MainBranch[] mainBranches;

    private void Awake()
    {
        mainBranches = transform.GetComponentsInChildren<MainBranch>();
    }

    private void Update()
    {
        
    }

    #region ANIMATE TREE ### TASK ###

    private void AnimateTree()
    {
        StartCoroutine(AnimateWholeTree());
    }

    private IEnumerator AnimateWholeTree()
    {
        float startTrasnsition = 0;
        while (!Mathf.Approximately(startTrasnsition, 1))
        {
            // Evaluate Animations
            startTrasnsition = Mathf.MoveTowards(startTrasnsition, 1, animSpeed * Time.deltaTime);

            // Apply animations
            trunk.SetBlendShapeWeight(0, startTrasnsition * 100f);

            yield return null;
        }

        // Run Animations on Branches
        foreach (var item in mainBranches)
        {
            item.DoAnimate();
        }
    }

    #endregion

}
