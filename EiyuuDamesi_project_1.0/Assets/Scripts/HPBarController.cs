using UnityEngine;
using UnityEngine.UI;

public class HPBarController : MonoBehaviour
{
    public Slider hpSlider; // HPバー（Slider）
    public CharacterStatus characterStatus; // キャラのHPデータ

    void Start()
    {
        if (characterStatus != null && hpSlider != null)
        {
            hpSlider.maxValue = characterStatus.maxHP;
            hpSlider.value = characterStatus.currentHP;
        }
    }

    void Update()
    {
        if (characterStatus != null && hpSlider != null)
        {
            hpSlider.value = characterStatus.currentHP; // HPを反映
        }
    }
}
