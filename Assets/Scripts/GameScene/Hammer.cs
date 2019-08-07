using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public GameObject particle;
    AudioSource audioSource;
    public AudioClip hitSound;

    void Start()
    {
        Destroy(this.gameObject, 0.5f);//0.5f
        audioSource = GetComponent<AudioSource>();

    }

    public void CollisionDetected(Collider col)
    { //child collisionına çarpan objeyi alıyoruz.

        particle.SetActive(true); //efect on
        audioSource.PlayOneShot(hitSound);
        col.transform.parent.GetComponent<Mole>().moleHealth--;// mole nin canını bir düşür
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().score++; //vurulma gerçeklşirse GameManagerdeki score değerini artırıyoruz.
        GameObject.FindGameObjectWithTag("Player").GetComponent<CameraController>().Shake();

    }

}
