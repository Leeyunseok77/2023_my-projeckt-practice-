using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;              //Tween을 쓰기 위해 선언

public class TweenTest : MonoBehaviour
{
    public bool isPunch = false;                //상자가 펀칭 중인지 확인하는
    Sequence sequence;


    // Start is called before the first frame update
    void Start()
    {
        //transform.DOMoveX(5, 2);    //물체가 X방향으로 5만큼 2초 동안 가겠다 트윈은 물체를 부드럽게 이동시켜준다.
        //transform.DORotate(new Vector3(0, 0, 180), 2);      //180초 2초 회전
        //transform.DOScale(new Vector3(3, 3, 3), 2);         //2초 동안 3배 크기

        //sequence = DOTween.Sequence();
        //sequence.Append(transform.DOMoveX(5, 2).SetEase(Ease.OutBounce));
        //sequence.Append(transform.DORotate(new Vector3(0, 0, 180), 2).OnComplete(SequnceEnd));
        //sequence.Append(transform.DOScale(new Vector3(3, 3, 3), 2));
        //sequence.SetLoops(-1, LoopType.Yoyo);



    }
    void SequnceEnd()
    {
        Debug.Log("회전 완료");
    }
    
    void EndPunch()
    {
        isPunch = false;        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isPunch == false)
            {
                isPunch = true;        //펀칭 중이 아닐때
                transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 0.1f, 10, 1).OnComplete(EndPunch);

                Color color = new Color(Random.value, Random.value, Random.value);
                Renderer renderer = GetComponent<Renderer>();
                renderer.material.DOColor(color, 0.1f);
            }
        }
    }
}
