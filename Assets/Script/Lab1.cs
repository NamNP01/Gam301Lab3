using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab1 : MonoBehaviour
{
    public GameObject cubePrefab;
    public int maxCubes = 10;
    private int currentCubeCount = 0;
    private List<GameObject> cubes = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnCubesAndMove());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(FadeOutAllCubes());
        }
    }

    IEnumerator SpawnCubesAndMove()
    {
        while (currentCubeCount < maxCubes)
        {
            yield return new WaitForSeconds(2);
            float x = Random.Range(-5f, 5f);
            float y = Random.Range(-5f, 5f);
            float z = Random.Range(-5f, 5f);
            Vector3 randomPosition = new Vector3(x, y, z);

            GameObject newCube = Instantiate(cubePrefab, randomPosition, Quaternion.identity);
            currentCubeCount++;
            cubes.Add(newCube);

            StartCoroutine(MoveObject(newCube, Vector3.zero));
        }
    }

    IEnumerator FadeOutAllCubes()
    {
        foreach (GameObject cube in cubes)
        {
            Renderer cubeRenderer = cube.GetComponent<Renderer>();
            if (cubeRenderer != null)
            {
                StartCoroutine(FadeOut(cubeRenderer));
            }
        }
        yield return null;
    }

    IEnumerator FadeOut(Renderer cubeRenderer)
    {
        Material material = cubeRenderer.material;
        Color color = material.color;
        float duration = 5f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            color.a = Mathf.Lerp(1f, 0f, elapsedTime / duration);
            material.color = color;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        color.a = 0f;
        material.color = color;
    }

    IEnumerator MoveObject(GameObject obj, Vector3 targetPosition)
    {
        float duration = 2f;
        float elapsedTime = 0f;
        Vector3 startPosition = obj.transform.position;

        while (elapsedTime < duration)
        {
            obj.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.transform.position = targetPosition;
    }
}
