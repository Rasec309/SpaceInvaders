using UnityEngine;
using System.Collections;

public class DestroyInSeconds : MonoBehaviour
{
    [SerializeField]
    private float secondsToDetroy = 2f;
    private void OnEnable()
    {
        StartCoroutine(DestroyAfterSeconds());
    }
    private IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(secondsToDetroy);
        gameObject.SetActive(false);
    }
}
