using UnityEngine;

public class MouseAreaTriggerOnce : MonoBehaviour
{
    public Rect area = new Rect(100, 100, 200, 150);

    private bool isInside = false; // 마우스가 영역 안에 있는지 상태 추적
    public GameObject textBox;
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;

        if (area.Contains(mousePos))
        {
            if (!isInside)
            {
                // 들어왔을 때 한 번만 호출
                OnEnter();
                isInside = true;
            }
        }
        else
        {
            if (isInside)
            {
                // 나갔을 때 한 번만 호출
                OnExit();
                isInside = false;
            }
        }
    }

    void OnEnter()
    {
        //Debug.Log("영역에 들어왔습니다!");
        // 들어왔을 때 실행할 동작
        textBox.SetActive(true);
    }

    void OnExit()
    {
        //Debug.Log("영역에서 나갔습니다!");
        // 나갔을 때 실행할 동작
        textBox.SetActive(false);
    }
}
