using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Danh sách cây/vật phẩm
    public Terrain terrain; // Địa hình
    public int numberOfObjects = 10; // Số lượng cần spawn

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 spawnPosition = GetRandomPosition();
            GameObject obj = Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)], spawnPosition, Quaternion.identity);
            obj.transform.parent = this.transform; // Gán vào cha để dễ quản lý
        }
    }

    Vector3 GetRandomPosition()
    {
        float terrainWidth = terrain.terrainData.size.x;
        float terrainLength = terrain.terrainData.size.z;
        float terrainPosX = terrain.transform.position.x;
        float terrainPosZ = terrain.transform.position.z;

        float x = Random.Range(terrainPosX, terrainPosX + terrainWidth);
        float z = Random.Range(terrainPosZ, terrainPosZ + terrainLength);
        float y = terrain.SampleHeight(new Vector3(x, 0, z)) + terrain.transform.position.y; // Lấy độ cao địa hình

        return new Vector3(x, y, z);
    }
}
