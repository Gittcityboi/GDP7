using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Buttondeactivator : MonoBehaviour
{
    // 인스펙터에서 관리할 버튼들을 드래그해서 넣어줄 배열입니다.
    [Header("UI Settings")]
    public GameObject[] rewardButtons;

    // 버튼의 On Click() 이벤트에 연결할 함수입니다.
    public void DisableAllButtons()
    {
        // 배열에 있는 모든 버튼을 하나씩 검사하며 비활성화합니다.
        for (int i = 0; i < rewardButtons.Length; i++)
        {
            if (rewardButtons[i] != null)
            {
                rewardButtons[i].SetActive(false);
            }
        }

        // (선택 사항) 로그를 찍어 확인합니다.
        Debug.Log("보상을 선택하여 모든 버튼이 비활성화되었습니다.");
    }
}