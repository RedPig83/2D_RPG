using UnityEngine;
using Cinemachine;
//시네머신 가상 카메라를 추가할 확장 컴포넌트를 만드려면 Cinemachine 프레임워크를 임포트해야 한다.

public class RoundCameraPos : CinemachineExtension
//시네머신의 프로세싱 파이프라인과 연결할 컴포넌트는 CinemachineExtension을 상속해야 한다.
{

    public float fPixelsPerUnit = 32;
    //단위당 픽셀, 즉 PPU다. 앞서 카메라를 이야기할 때 설명했듯이 하나의 월드 단위에 픽셀 32개를 표시한다.

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    //CinemachineExtension을 상속한 클래스라면 반드시 구현해야 하는 메서드로 제한자의 처리가 끝나고 시네머신이 호출하는 메서드다.
    {
        if (stage == CinemachineCore.Stage.Body)
        //시네머신 가상 카메라는 여러 단계로 이루어진 포스트 프로세싱 파이프라인을 지니고 있다.
        //이 코드는 현재 카메라의 포스트 프로세싱 단계가 Body인지 확인한다.
        //맞으면 가상 카메라의 공간 위치를 설정할 수 있다.
        {
            Vector3 v3pos0 = state.FinalPosition;
            //가상 카메라의 최종 위치를 얻는다.

            Vector3 v3pos1 = new Vector3(Round(v3pos0.x), Round(v3pos0.y),v3pos0.z);
            //위치를 반올림하고 새로운 벡터를 생성한다.
            //이 벡터는 새로운 픽셀 단위 위치다.

            state.PositionCorrection += v3pos1 - v3pos0;
            //원래 위치와 방금 반올림해서 계산한 위치의 차이를 가상 카메라의 위치에 반영한다.
        }
        
        float Round(float f)
        {
            return Mathf.Round(f * fPixelsPerUnit) / fPixelsPerUnit;
        }        
    }

}
