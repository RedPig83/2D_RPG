using UnityEngine;

public abstract class Character : MonoBehaviour
//C#�� abstract �����ڸ� ����ؼ� �ν��Ͻ�ȭ�� �� ���� Ŭ������ ���� Ŭ�������� ����ؾ� �ϴ� Ŭ�������� ��Ÿ����.
{
    public HitPoint hp;
    public float fMaxHp;
    public float fStartHp;

    public virtual void KillCharacter()
    {
        Destroy(gameObject);
    }
}
