﻿using UnityEngine;

public class Rocket : MonoBehaviour {
    public float Speed;

    private void Start() {
        Invoke("DestroyRocket", 10f);
    }
    private void Update() {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    private void DestroyRocket() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == 12) Destroy(gameObject); //Destroying on entered to static objects
    }
}