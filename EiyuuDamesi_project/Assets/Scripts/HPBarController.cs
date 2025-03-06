using UnityEngine;
using UnityEngine.UI;

public class HPBarController : MonoBehaviour
{
    public Slider hpSlider; // HP�o�[�iSlider�j
    public CharacterStatus characterStatus; // �L������HP�f�[�^

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
            hpSlider.value = characterStatus.currentHP; // HP�𔽉f
        }
    }
}
