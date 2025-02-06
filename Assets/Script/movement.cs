using System.Collections;
using UnityEngine;
using Unity.Cinemachine;

public class Movement : MonoBehaviour
{
    public float speed = 5.0f;
    public CinemachineCamera virtualCamera1;
    public CinemachineCamera virtualCamera2;
    public Transform targetPosition;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        virtualCamera1.Priority = 10;
        virtualCamera2.Priority = 0;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontal, 0, vertical);
        controller.Move(move * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            virtualCamera1.Priority = 0;
            virtualCamera2.Priority = 10;
            StartCoroutine(MoveToTarget());
        }
    }

    private IEnumerator MoveToTarget()
    {
        Vector3 startPosition = transform.position;
        float time = 0;
        while (time < 1)
        {
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, targetPosition.position, time);
            yield return null;
        }
    }
}
