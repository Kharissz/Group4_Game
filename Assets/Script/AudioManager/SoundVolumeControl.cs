using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVolumeControl : MonoBehaviour
{
    public Transform playerTransform; // Transform dari player atau objek yang menjadi pendengar
    private AudioSource audioSource;
    public float maxVolumeDistance = 10f; // Jarak maksimum di mana suara akan terdengar maksimal
    public float minVolumeDistance = 1f; // Jarak minimum di mana suara akan terdengar minimal

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (playerTransform == null)
        {
            // Jika playerTransform tidak ditetapkan, gunakan posisi kamera sebagai default
            playerTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        if (audioSource != null && playerTransform != null)
        {
            // Hitung jarak antara player dan sumber suara
            float distance = Vector3.Distance(transform.position, playerTransform.position);

            // Hitung volume berdasarkan jarak dengan fungsi Attenuation
            float volume = 1f - Mathf.Clamp01((distance - minVolumeDistance) / (maxVolumeDistance - minVolumeDistance));
            volume = Mathf.Clamp01(volume); // Pastikan volume tidak melebihi 1 atau kurang dari 0

            // Atur volume AudioSource
            audioSource.volume = volume;
        }
    }
}
