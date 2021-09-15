using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGGameManager : MonoBehaviour
{
    public static RPGGameManager sharedInstance = null;
    //static 변수인 sharedInstance는 싱글톤 오브젝트에 접근할 때 사용한다.
    //싱글톤은 이 속성을 통해서만 접근할 수 있다.
    //static 변수가 클래스의 특정 인스턴스가 아닌 RPGGameManager 클래스 자체에 속한다는 점이 중요하다.
    //클래스 자체에 속하므로 RPGGameManager.sharedInstance의 복사본은 메모리에 단 하나만 존재한다.

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
        //계층 구조창에 RPGGameManager 오브젝트를 2개 만들면 두 번째 RPGGameManager는 첫 번째와 같은 sharedInstance를 공유한다.
        //이를 위한 조치가 필요하다.
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
