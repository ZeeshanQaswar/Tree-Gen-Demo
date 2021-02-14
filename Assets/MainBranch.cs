using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBranch : MonoBehaviour
{
    public float animSpeed = 5f;
    public float leavesScale = 3f;
    public Transform pivot;

    // References to Sub Components
    [SerializeField] private List<Transform> leaves;
    [SerializeField] private List<SkinnedMeshRenderer> animatedBranches;
    [SerializeField] private List<Transform> wasteBranches;

    private SkinnedMeshRenderer _meshRend;

    private void Awake()
    {
        foreach (Transform obj in transform)
        {
            if (obj.CompareTag("Animated Branch"))
            {
                animatedBranches.Add(obj.GetComponent<SkinnedMeshRenderer>());
            }
            if (obj.CompareTag("Waste Branch"))
            {
                wasteBranches.Add(obj);
            }
            if (obj.CompareTag("Leaves"))
            {
                leaves.Add(obj);
            }
            if (obj.CompareTag("Pivot"))
            {
                pivot = obj;
            }
        }

        _meshRend = GetComponent<SkinnedMeshRenderer>();
    }


    #region HANDLE ANIMATIONS

    public void DoAnimate()
    {
        StartCoroutine(AnimateMainBranch());
    }

    private IEnumerator AnimateMainBranch()
    {
        float startTrasnsition = 0;
        while (!Mathf.Approximately(startTrasnsition, 1))
        {
            // Evaluate Animations
            startTrasnsition = Mathf.MoveTowards(startTrasnsition, 1, animSpeed * Time.deltaTime);

            // Apply animations
            _meshRend.SetBlendShapeWeight(0, startTrasnsition * 100f);

            yield return null;
        }

        yield return StartCoroutine(AnimateSubBranches());
    }

    private IEnumerator AnimateSubBranches()
    {
        float startTrasnsition = 0;
        while (!Mathf.Approximately(startTrasnsition,1))
        {
            // Evaluate Animations
            startTrasnsition = Mathf.MoveTowards(startTrasnsition, 1, animSpeed * Time.deltaTime);

            // Apply animations
            foreach (var item in animatedBranches)
            {
                item.SetBlendShapeWeight(0, startTrasnsition * 100f);
            }

            yield return null;
        }
    }

    #endregion

}
