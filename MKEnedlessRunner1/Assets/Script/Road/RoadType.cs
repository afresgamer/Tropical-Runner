using UnityEngine;

[CreateAssetMenu(fileName = "RoadType")]
public class RoadType : ScriptableObject {

    /// <summary>
    /// コースを難易度ごとに設定するため
    /// </summary>
    public GameObject[] RoadTypes;
}
