using UnityEngine;
using DG.Tweening;

public class RoadTrap : MonoBehaviour {

    //ランダムに道を設置するギミック用
    [SerializeField,Header("設置ポイント")]
    private Transform[] AttachPoints;
    [SerializeField, Header("設置オブジェクト")]
    private GameObject RoadPrefab;
    //上下する橋ギミック用
    [SerializeField, Header("上下する橋")]
    private GameObject Bridge;
    private Sequence sequence;

    void Start () {
        //ランダム道設置用
		if(AttachPoints.Length > 1 && RoadPrefab != null)
        {
            int randomNum = Random.Range(0, AttachPoints.Length);
            RoadPrefab.transform.position = AttachPoints[randomNum].position;
        }

        //上下する橋ギミック用
        if(Bridge != null)
        {
            sequence = DOTween.Sequence();
            sequence.Append(Bridge.transform.DOMoveY(-1, 2.0f));
            sequence.Append(Bridge.transform.DOMoveY(1, 2.0f));
            sequence.SetLoops(-1);
        }
	}

    private void OnDestroy()
    {
        sequence.Kill();
    }
}
