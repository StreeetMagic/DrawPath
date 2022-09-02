using System;
using System.Collections;
using UnityEngine;

public class TestPush : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private void Start()
    {
        //StartCoroutine(Kek());
    }

    private IEnumerator Kek()
    {
        yield return new WaitForSeconds(1);
        Push();
    }

    private void Push()
    {
        _rigidbody.AddForce(Vector3.up * 1000f,ForceMode.Acceleration);
    }
}
