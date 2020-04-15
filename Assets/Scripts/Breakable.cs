using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public GameObject cratePieces;
    public float explosionForce = 50f;
    public float explosionRange = 2f;
    public static bool broken;

    private void Start()
    {
        broken = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            broken = true;
            Transform currentCrate = gameObject.transform;

            Destroy(gameObject);

            GameObject pieces = Instantiate(cratePieces, currentCrate.position, currentCrate.rotation);

            Rigidbody[] rbPieces = pieces.GetComponentsInChildren<Rigidbody>();

            foreach (Rigidbody rb in rbPieces)
            {
                rb.AddExplosionForce(explosionForce, currentCrate.position, explosionRange);
            }
        }
    }
}
