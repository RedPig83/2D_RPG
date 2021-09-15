using UnityEngine;
using Cinemachine;
//�ó׸ӽ� ���� ī�޶� �߰��� Ȯ�� ������Ʈ�� ������� Cinemachine �����ӿ�ũ�� ����Ʈ�ؾ� �Ѵ�.

public class RoundCameraPos : CinemachineExtension
//�ó׸ӽ��� ���μ��� ���������ΰ� ������ ������Ʈ�� CinemachineExtension�� ����ؾ� �Ѵ�.
{

    public float fPixelsPerUnit = 32;
    //������ �ȼ�, �� PPU��. �ռ� ī�޶� �̾߱��� �� �����ߵ��� �ϳ��� ���� ������ �ȼ� 32���� ǥ���Ѵ�.

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    //CinemachineExtension�� ����� Ŭ������� �ݵ�� �����ؾ� �ϴ� �޼���� �������� ó���� ������ �ó׸ӽ��� ȣ���ϴ� �޼����.
    {
        if (stage == CinemachineCore.Stage.Body)
        //�ó׸ӽ� ���� ī�޶�� ���� �ܰ�� �̷���� ����Ʈ ���μ��� ������������ ���ϰ� �ִ�.
        //�� �ڵ�� ���� ī�޶��� ����Ʈ ���μ��� �ܰ谡 Body���� Ȯ���Ѵ�.
        //������ ���� ī�޶��� ���� ��ġ�� ������ �� �ִ�.
        {
            Vector3 v3pos0 = state.FinalPosition;
            //���� ī�޶��� ���� ��ġ�� ��´�.

            Vector3 v3pos1 = new Vector3(Round(v3pos0.x), Round(v3pos0.y),v3pos0.z);
            //��ġ�� �ݿø��ϰ� ���ο� ���͸� �����Ѵ�.
            //�� ���ʹ� ���ο� �ȼ� ���� ��ġ��.

            state.PositionCorrection += v3pos1 - v3pos0;
            //���� ��ġ�� ��� �ݿø��ؼ� ����� ��ġ�� ���̸� ���� ī�޶��� ��ġ�� �ݿ��Ѵ�.
        }
        
        float Round(float f)
        {
            return Mathf.Round(f * fPixelsPerUnit) / fPixelsPerUnit;
        }        
    }

}
