using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public HitPoint hp;

    [HideInInspector]
    public Player character;
    public Image meterImage;
    public Text hpText;

    private float fMaxHp;

    // Start is called before the first frame update
    void Start()
    {
        fMaxHp = character.fMaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (character != null)
        {
            meterImage.fillAmount = hp.fValue / fMaxHp;

            hpText.text = "HP: " + (meterImage.fillAmount * 100);
        }
    }
}
