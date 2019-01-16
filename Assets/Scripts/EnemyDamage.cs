using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider collisionMesh;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip hitSFX;
    [SerializeField] AudioClip deathSFX;

    AudioSource audioSource;
    int hitPoints = 10;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        var prop = FindObjectOfType<Properties>();
        hitPoints = prop.EnemyHealth;
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        hitParticlePrefab.Play();
        hitPoints = hitPoints - 1;
        audioSource.PlayOneShot(hitSFX);
    }

    private void KillEnemy()
    {
        createDeathvfx();
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, audioSource.volume);
        Destroy(gameObject,deathSFX.length);
    }

    private void createDeathvfx()
    {
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.transform.parent = gameObject.transform.parent;
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);

    }
}
