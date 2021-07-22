using System.Collections;
using UnityEngine;

public class CameraContrller : MonoBehaviour {
    public IEnumerator CameraShake(float _maxTime, float _amount)
    {
        Vector3 originalPos = transform.localPosition;
        float shakeTime = 0.0f;
        while (shakeTime < _maxTime)
        {
            float x = Random.Range(-0.3f, 0.3f) * _amount;
            float y = Random.Range(-0.3f, 0.3f) * _amount;

            transform.localPosition = new Vector3(x, y, originalPos.z);
            shakeTime += Time.deltaTime;
            yield return new WaitForSeconds(0f);
        }
    }
}
