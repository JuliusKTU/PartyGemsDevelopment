using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public IEnumerator CameraShake(float duration, float magnitude)
    {
        gameObject.GetComponent<Animator>().enabled = false;

        Vector3 orignalPos = transform.localPosition;
        Debug.Log(orignalPos);

        float elapse = 0.0f;
        while (elapse < duration)
        {
            Debug.Log("Shake");
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, orignalPos.z);
            Debug.Log(transform.localPosition);

            elapse += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = orignalPos;
    }
}
