using System.Collections;
using UnityEngine;

public class CameraShakeEffect
{
    private Vector3 originalPosition;
    private Transform sourceTransform;
    private float shakeTime;
    private bool isShaking;
    
    private float shakeDuration = 0.5f;
    private float shakeAmplitude = 0.5f;
    private float shakeFrequency = 1f;

    public CameraShakeEffect(Transform sourceTransform)
    {
        originalPosition = sourceTransform.localPosition;
        this.sourceTransform = sourceTransform;
    }

    public void StartShake()
    {
        if (!isShaking)
            ShakeCoroutine();
        else
            shakeTime = 0;
    }

    private void ShakeCoroutine()
    {
        isShaking = true;
        shakeTime = 0;

        while (shakeTime < shakeDuration)
        {
            shakeTime += Time.deltaTime;
            float progress = shakeTime / shakeDuration;

            // Reduce shake intensity over time
            float currentAmplitude = shakeAmplitude * (1f - progress);

            // Generate perlin noise for more natural camera movement
            float offsetX = (Mathf.PerlinNoise(Time.time * shakeFrequency, 0) * 2 - 1) * currentAmplitude;
            float offsetY = (Mathf.PerlinNoise(0, Time.time * shakeFrequency) * 2 - 1) * currentAmplitude;

            // Apply the shake offset
            sourceTransform.localPosition = originalPosition + new Vector3(offsetX, offsetY, 0);
        }

        // Return to original position
        sourceTransform.localPosition = originalPosition;
        isShaking = false;
    }
}
