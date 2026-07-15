using UnityEngine;

[CreateAssetMenu(fileName = "Drop", menuName = "Scriptable Objects/Drop")]
public class Drop : ScriptableObject
{
    [SerializeField] private string name;
    [TextArea(5, 10)] 
    [SerializeField] private string description;
    [SerializeField] private Sprite sprite;
}