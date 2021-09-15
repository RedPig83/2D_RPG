using UnityEngine;

public abstract class Character : MonoBehaviour
//C#의 abstract 한정자를 사용해서 인스턴스화할 수 없는 클래스고 하위 클래스에서 상속해야 하는 클래스임을 나타낸다.
{
    public HitPoint hp;
    public float fMaxHp;
    public float fStartHp;

    public virtual void KillCharacter()
    {
        Destroy(gameObject);
    }
}
