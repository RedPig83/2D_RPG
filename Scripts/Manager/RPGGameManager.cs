using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGGameManager : MonoBehaviour
{
    public static RPGGameManager sharedInstance = null;
    //static ������ sharedInstance�� �̱��� ������Ʈ�� ������ �� ����Ѵ�.
    //�̱����� �� �Ӽ��� ���ؼ��� ������ �� �ִ�.
    //static ������ Ŭ������ Ư�� �ν��Ͻ��� �ƴ� RPGGameManager Ŭ���� ��ü�� ���Ѵٴ� ���� �߿��ϴ�.
    //Ŭ���� ��ü�� ���ϹǷ� RPGGameManager.sharedInstance�� ���纻�� �޸𸮿� �� �ϳ��� �����Ѵ�.

    public SpawnPoint playerSpawnPoint;
    public RPGCameraManager cameraManager;

    public void SpawnPlayer()
    {
        if (playerSpawnPoint != null)
        {
            GameObject player = playerSpawnPoint.SpawnObject();

            cameraManager.virtualCamera.Follow = player.transform;
        }
    }

    private void Awake()
    {
        if (sharedInstance != null && sharedInstance != this)
        //���� ����â�� RPGGameManager ������Ʈ�� 2�� ����� �� ��° RPGGameManager�� ù ��°�� ���� sharedInstance�� �����Ѵ�.
        //�̸� ���� ��ġ�� �ʿ��ϴ�.
        {
            Destroy(gameObject);
        }
        else
        {
            sharedInstance = this;
        }
    }

    private void Start()
    {
        SetupScene();
    }

    public void SetupScene()
    {
        SpawnPlayer();
    }
}
