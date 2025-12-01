using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemySpawn : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    [Header("Wave Settings")]
    public TMP_Text waveText;
    public float spawnRadius = 10f; // 카메라 밖으로 보낼 거리 (적절히 조절 필요)

    // Start is called before the first frame update
    void Start()
    {
        // 시작 시 텍스트는 안 보이게 설정
        if (waveText != null) waveText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // M키: 적 1마리 랜덤 스폰
        // GetKey 대신 GetKeyDown을 써야 한 번만 실행됩니다.
        if (Input.GetKeyDown(KeyCode.M))
        {
            SpawnRandomEnemy();
        }

        // N키: 웨이브 경고 후 10마리 스폰
        if (Input.GetKeyDown(KeyCode.N))
        {
            StartCoroutine(WaveRoutine());
        }
    }

    // 적을 랜덤하게 선택하여 스폰하는 함수
    void SpawnRandomEnemy()
    {
        // 1. 랜덤한 적 프리팹 선택
        GameObject selectedEnemy = null;
        int rand = Random.Range(0, 3); // 0, 1, 2 중 하나

        if (rand == 0) selectedEnemy = enemy1;
        else if (rand == 1) selectedEnemy = enemy2;
        else selectedEnemy = enemy3;

        // 2. 카메라 위치 기준으로 랜덤한 방향(원형) 좌표 계산
        // Random.insideUnitCircle.normalized는 반지름 1짜리 원의 테두리 방향을 줍니다.
        Vector2 randomDir = Random.insideUnitCircle.normalized;
        Vector3 spawnPos = Camera.main.transform.position + (Vector3)(randomDir * spawnRadius);
        spawnPos.z = 0; // 2D 게임이라면 Z축 고정

        // 3. 적 생성
        if (selectedEnemy != null)
        {
            Instantiate(selectedEnemy, spawnPos, Quaternion.identity);
        }
    }

    // 웨이브 경고 효과 및 10마리 스폰 코루틴
    IEnumerator WaveRoutine()
    {
        if (waveText == null) yield break; // 텍스트 없으면 중단

        waveText.text = "Wave incoming!";
        waveText.gameObject.SetActive(true);

        float duration = 3.0f;     // 총 지속 시간
        float blinkInterval = 0.5f;// 깜빡임 간격
        float timer = 0f;

        // 3초 동안 반복
        while (timer < duration)
        {
            // 투명하게 (Fade Out)
            waveText.color = new Color(waveText.color.r, waveText.color.g, waveText.color.b, 0);
            yield return new WaitForSeconds(blinkInterval / 2); // 0.25초 대기

            // 다시 보이게 (Fade In)
            waveText.color = new Color(waveText.color.r, waveText.color.g, waveText.color.b, 1);
            yield return new WaitForSeconds(blinkInterval / 2); // 0.25초 대기

            timer += blinkInterval;
        }

        // 경고 끝난 후 텍스트 끄기
        waveText.gameObject.SetActive(false);

        // 10마리 적 스폰
        for (int i = 0; i < 10; i++)
        {
            SpawnRandomEnemy();
        }
    }
}