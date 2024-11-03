using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] PlayerInfo player;
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    void Update()
    {
        slider.value = player.Health;
    }
}
